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
    public class EfCustomerDal : EfEntityRepositoryBase<Customer, RentACarContext>, ICustomerDal
    {
        public List<CustomerDetailDto> GetCustomerDetails(Expression<Func<Customer, bool>> filter = null)
        {
            using (RentACarContext context = new RentACarContext())
            {
                var result = from c in filter is null ? context.Customers : context.Customers.Where(filter)
                             join u in context.Users
                             on c.UserId equals u.UserId
                             select new CustomerDetailDto
                             {
                                 FirstName = u.FirstName,
                                 LastName = u.LastName,
                                 CustomerId = c.CustomerId,
                                 CompanyName = c.CompanyName
                             };
                return result.ToList();
            }
        }
    }
}
