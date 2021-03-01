using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class CarManager : ICarService
    {
        ICarDal _carDal;
        public CarManager(ICarDal carDal)
        {
            _carDal = carDal;
        }

       [ValidationAspect(typeof(CarValidator))]
        public IResult Add(Car car)
        {
           
            _carDal.Add(car);
                return new SuccessResult(Messages.SuccessMessage);
           
        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Delete(Car car)
        {
            _carDal.Delete(car);
            return new SuccessResult(Messages.SuccessMessage);

        }

        [ValidationAspect(typeof(CarValidator))]
        public IResult Update(Car car)
        {
            _carDal.Update(car);
            return new SuccessResult(Messages.SuccessMessage);

        }

        public IDataResult<List<Car>> GetAll()
        {
            return new SuccessDataResult<List<Car>>(_carDal.GetAll(), Messages.SuccessDataMessage);
        }


        public IDataResult<Car> GetByID(int carID)
        {
            return new SuccessDataResult<Car>(_carDal.Get(c => c.CarId == carID), Messages.SuccessDataMessage);
        }

        public IDataResult<List<CarDetailsDto>> GetCarDetails()
        {
            return new SuccessDataResult<List<CarDetailsDto>>(_carDal.GetCarDetails(), Messages.SuccessDataMessage);
        }
    }
}
