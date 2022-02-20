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
        IDataResult<Car> GetByID(int carId);
        IResult AddTransactionalTest(Car car);
        IDataResult<List<CarDetailsDto>> GetCarDetails();
        IDataResult<List<CarDetailsDto>> GetCarDetailByColorId(int colorId);
        IDataResult<List<CarDetailsDto>> GetCarDetailByBrandId(int brandId);
        IDataResult<List<CarDetailsDto>> GetCarDetailById(int carId);
        IDataResult<List<CarDetailsDto>> GetCarDetailByColorAndBrandId(int colorId, int brandId);
        IDataResult <List<CarImageDto>> GetCarImageDetailById(int carId);
        IDataResult<List<CarImageDto>> GetCarImageDetails();


    }
}
