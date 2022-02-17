
using Core.DataAccess;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace DataAccess.Abstract
{
    public interface ICarDal : IEntityRepository<Car>
    {
        List<CarDetailsDto> GetCarDetails(Expression<Func<Car, bool>> filter = null);
        CarDetailsDto GetCarDto(Expression<Func<Car, bool>> filter = null);
        List<CarImageDto> GetCarImageDetails(Expression<Func<Car, bool>> filter = null);
        CarImageDto GetCarImageDto(Expression<Func<Car, bool>> filter = null);
    }
}
