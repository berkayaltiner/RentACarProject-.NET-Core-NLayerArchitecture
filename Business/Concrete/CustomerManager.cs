using Business.Abstract;
using Business.Constants;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CustomerManager : ICustomerService
    {
        ICustomerDal _cutomerDal;

        public CustomerManager(ICustomerDal cutomerDal)
        {
            _cutomerDal = cutomerDal;
        }

        public IResult Add(Customer customer)
        {
            _cutomerDal.Add(customer);
            return new SuccessResult(Messages.CustomerAdded);
        }

        public IResult Delete(Customer customer)
        {
            _cutomerDal.Delete(customer);
            return new SuccessResult(Messages.CustomerDeleted);
        }

        public IDataResult<List<Customer>> GetAll()
        {
            return new SuccessDataResult<List<Customer>>(_cutomerDal.GetAll(), Messages.CustomersListed);
        }

        public IDataResult<Customer> GetById(int customerId)
        {
            return new SuccessDataResult<Customer>(_cutomerDal.Get(c => c.CustomerId == customerId), Messages.CustomersListed);
        }

        public IDataResult<List<CustomerDetailDto>> GetCustomerDetails()
        {
            return new SuccessDataResult<List<CustomerDetailDto>>(_cutomerDal.GetCustomerDetails(), Messages.CustomersListed);
        }

        public IResult Update(Customer customer)
        {
            _cutomerDal.Update(customer);
            return new SuccessResult(Messages.CustomerUpdated);

        }
    }
}
