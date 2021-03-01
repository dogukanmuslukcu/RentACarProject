using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Business;
using Core.Utilities.Concrete;
using Core.Utilities.Helpers;
using DataAccess.Abstract;
using Entities.Concrete;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class CarImageManager : ICarImageService
    {
        ICarImageDal _carImageDal;

        public CarImageManager(ICarImageDal carImageDal)
        {
            _carImageDal = carImageDal;
        }

        [ValidationAspect(typeof(CarImageValidator))]
        public IResult Add(IFormFile file, CarImage carImage)
        {
            IResult result = BusinessRules.Run(CheckImageLimitExceeded(carImage.CarId));
            if (result != null)
            {
                return result;
            }
            carImage.ImagePath = FileHelper.Add(file);
            carImage.Date = DateTime.Now;
            _carImageDal.Add(carImage);
            return new SuccessResult();
        }

        
        public IResult Delete(CarImage carImage)
        {
            IResult result = BusinessRules.Run(CarImageDelete(carImage));
            if (result != null)
            {
                return result;
            }
            _carImageDal.Delete(carImage);
            return new SuccessResult();
        }

      
        public IResult Update(IFormFile file, CarImage carImage)
        {
            carImage.ImagePath = FileHelper.Update(_carImageDal.Get(p => p.CarImageId == carImage.CarImageId).ImagePath, file);
            carImage.Date = DateTime.Now;
            _carImageDal.Update(carImage);
            return new SuccessResult();
        }

        
        public IDataResult<CarImage> GetById(int carImageId)
        {
            return new SuccessDataResult<CarImage>(_carImageDal.Get(p =>p.CarImageId == carImageId),Messages.SuccessDataMessage);
        }

        public IDataResult<List<CarImage>> GetAll()
        {
            return new SuccessDataResult<List<CarImage>>(_carImageDal.GetAll());
        }


        public IDataResult<List<CarImage>> GetImagesByCarId(int carId)
        {
            return new SuccessDataResult<List<CarImage>>(CheckIfCarImageNull(carId));
        }

        private IResult CheckImageLimitExceeded(int carid)
        {
            var carImagecount = _carImageDal.GetAll(p => p.CarId == carid).Count;
            if (carImagecount >= 5)
            {
                return new ErrorResult(Messages.FailAddedImageLimit);
            }

            return new SuccessResult();
        }
        private List<CarImage> CheckIfCarImageNull(int id)
        {
            string path = @"C:\Users\doğukan\source\repos\ReCapProject\WebAPI\Images\logo.jpg";
            var result = _carImageDal.GetAll(c => c.CarId == id).Any();
            if (!result)
            {
                return new List<CarImage> { new CarImage { CarId = id, ImagePath = path, Date = DateTime.Now } };
            }
            return _carImageDal.GetAll(p => p.CarId == id);
        }

        private IResult CarImageDelete(CarImage carImage)
        {
            var result = _carImageDal.Get(c => c.CarImageId == carImage.CarImageId);
            if (result==null) 
            {
                return new ErrorResult(Messages.CarImageNotFound);
            }
            try
            {
                
                File.Delete(result.ImagePath);
            }
            catch (Exception exception)
            {

                return new ErrorResult(exception.Message);
            }

            return new SuccessResult();
        }
    }
}
