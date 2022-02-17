﻿using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfCarDal : IEfEntityRepositoryBase<Car, ReCapProjectDBContext>, ICarDal
    {
        public CarDetailsDto GetCarDto(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext()) 
            {
                var resultList = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 

                                 select new CarDetailsDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear, Description = c.Description };

                return resultList.SingleOrDefault();
            }

        }

        public List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {

                var resultList = from c in filter == null ? context.Cars : context.Cars.Where(filter)
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                 join ca in context.Cars on b.BrandId equals ca.BrandId

                                 select new CarDetailsDto { CarId = ca.CarId, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = ca.DailyPrice, ModelYear = ca.ModelYear, Description = ca.Description };

                return resultList.ToList();

            } 
        }

        public List<CarImageDto> GetCarImageDetails(Expression<Func<CarImageDto, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext()) 
            {
                var resultList = from c in context.Cars 
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                
                                 
                                 select new CarImageDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear, Description = c.Description,
                                     ImagePath = (from i in context.CarImages where i.CarId == c.CarId select i).ToList()
                                 };
                return filter == null ? resultList.ToList() : resultList.Where(filter).ToList();
            }
        }

        public List<CarImageDto> GetCarImageDto(Expression<Func<CarImageDto, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var resultList = from c in context.Cars
                                 join b in context.Brands
                                 on c.BrandId equals b.BrandId
                                 join co in context.Colors
                                 on c.ColorId equals co.ColorId
                                
                                 select new CarImageDto { CarId = c.CarId, BrandName = b.BrandName, ColorName = co.ColorName, DailyPrice = c.DailyPrice, ModelYear = c.ModelYear, Description = c.Description,
                                     ImagePath = (from i in context.CarImages where i.CarId == c.CarId select i).ToList()
                                 };
                return filter == null ? resultList.ToList() : resultList.Where(filter).ToList();
            }
        }
    }
}