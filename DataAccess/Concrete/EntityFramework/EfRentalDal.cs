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
        public List<RentalDetailsDto> GetRentalDetails(Expression<Func<RentalDetailsDto, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var resultList = from rental in context.Rentals
                             join customer in context.Customers
                                 on rental.CustomerId equals customer.CustomerId
                             join car in context.Cars
                                 on rental.CarId equals car.CarId
                             join brand in context.Brands
                                 on car.BrandId equals brand.BrandId

                             select new RentalDetailsDto { RentId = rental.RentId, BrandName = brand.BrandName, CustomerName = customer.FirstName + " " + customer.LastName, RentDate = rental.RentDate, ReturnDate = rental.ReturnDate };

                return filter == null ? resultList.ToList() : resultList.Where(filter).ToList();


            }
        }
    }
}
