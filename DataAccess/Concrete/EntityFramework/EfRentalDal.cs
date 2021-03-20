using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : IEfEntityRepositoryBase<Rental, ReCapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<Rental, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var resultList = from c in filter == null ? context.Rentals : context.Rentals.Where(filter)
                                 join r in context.Rentals on c.CarId equals r.CarId
                                 join cu in context.Customers on r.CustomerId equals cu.CustomerId
                                 join ca in context.Cars on r.CarId equals ca.CarId
                                 join b in context.Brands on ca.BrandId equals b.BrandId

                                 select new RentalDetailsDto { RentId = r.RentId, BrandName = b.BrandName, CustomerName = cu.FirstName + " " + cu.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return resultList.ToList();

            }
        }
    }
}
