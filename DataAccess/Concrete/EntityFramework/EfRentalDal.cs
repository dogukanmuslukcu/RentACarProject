using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfRentalDal : IEfEntityRepositoryBase<Rental, ReCapProjectDBContext>, IRentalDal
    {
        public List<RentalDetailsDto> GetRentalDetails()
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {

                var resultList = from c in context.Cars
                                 join b in context.Brands
                            on c.BrandId equals b.BrandId
                                 join r in context.Rentals on c.CarId equals r.CarId
                                 join cu in context.Customers on r.CustomerId equals cu.CustomerId
                                 select new RentalDetailsDto { RentId = r.RentId, BrandName = b.BrandName, CustomerName = cu.FirstName + " " + cu.LastName, RentDate = r.RentDate, ReturnDate = r.ReturnDate };

                return resultList.ToList();

            }
        }
    }
}
