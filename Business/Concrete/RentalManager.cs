using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class RentalManager : IRentalService
    {
        IRentalDal _rentalDal;

        public RentalManager(IRentalDal rentalDal)
        {
            _rentalDal = rentalDal;
        }

        public IResult Add(Rental rental)
        {
            if(CheckRentalAvailable(rental.CarId))
            {
                _rentalDal.Add(rental);
                return new SuccessResult(Messages.RentalAdded);
            }

            return new ErrorResult(Messages.RentalNotAdded);

        }

        public IResult Delete(Rental rental)
        {
            if(rental.RentalId == 0 && rental == null)
            {
                return new ErrorResult(Messages.RentalNotDeleted);
            }
            _rentalDal.Delete(rental);
            return new SuccessResult(Messages.RentalDeleted);
        }

        public IDataResult<List<Rental>> GetAll()
        {
            return new SuccessDataResult<List<Rental>>(_rentalDal.GetAll(), Messages.RentalListed);
        }

        public IDataResult<Rental> GetById(int rentId)
        {
            return new SuccessDataResult<Rental>(_rentalDal.Get(r=>r.RentalId == rentId), Messages.RentalListed);
        }

        public IDataResult<List<RentalDetailDto>> GetRentalDetails()
        {
            return new SuccessDataResult<List<RentalDetailDto>>(_rentalDal.GetRentalDetails(), Messages.RentalListed);
        }

        public IResult Update(Rental rental)
        {
            _rentalDal.Update(rental);
            return new SuccessResult(Messages.RentalUpdated);
        }

        public bool CheckRentalAvailable(int carId)
        {
            var result = ((_rentalDal.GetAll(x => x.CarId == carId)).OrderByDescending(x => x.RentDate)).FirstOrDefault();

            if (result == null)
            {
                return true;

            }
            else if ((result.ReturnDate.HasValue) && (DateTime.Compare(DateTime.Now, (DateTime)result.ReturnDate) > 0))
            {

                return true;

            }
            
            return false;

        }
    }
}
