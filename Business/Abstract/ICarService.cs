using Core.Utilities;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface ICarService
    {
        IResult Add(Car car);
        IResult Update(Car car);
        IResult Delete(Car car);
        IDataResult<List<Car>> GetAll();
        IDataResult<Car> GetByID(int carID);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailsDto>> GetAllColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetAllBrandId(int brandId);
        IDataResult<CarDetailsDto> GetByIdForDto(int carID);
        IDataResult<CarImageDto> GetByIdForImageDto(int carID);
        IDataResult<List<CarImageDto>> GetCarImageDetails();


    }
}
