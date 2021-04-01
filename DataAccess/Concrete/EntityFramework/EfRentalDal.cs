using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : EfEntityRepositoryBase<Rental, RentACarContext>, IRentalDal
    {
        public List<RentalDetailDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from r in filter is null ? context.Rentals : context.Rentals.Where(filter)
                             join crs in context.Cars on r.CarId equals crs.Id
                             join b in context.Brands on crs.BrandId equals b.BrandId
                             join c in context.Colors on crs.ColorId equals c.ColorId
                             join cus in context.Customers on r.CustomerId equals cus.CustomerId
                             join u in context.Users on cus.UserId equals u.UserId
                             select new RentalDetailDto
                             {
                                 RentalId = r.RentalId,
                                 CustomerName = u.FirstName,
                                 CustomerLastName = u.LastName,
                                 CustomerCompanyName = cus.CompanyName,
                                 CarName = crs.Description,
                                 BrandName = b.BrandName,
                                 ColorName = c.ColorName,
                                 DailyPrice = crs.DailyPrice,
                                 RentDate = r.RentDate,
                                 ReturnDate = r.ReturnDate
                             };
                return result.ToList();

            }
        }
    }
}
