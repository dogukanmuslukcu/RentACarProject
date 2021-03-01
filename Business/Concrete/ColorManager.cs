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
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class ColorManager : IColorService
    {
        IColorDal _colorDal;

        public ColorManager(IColorDal colorService)
        {
            _colorDal = colorService;
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Add(Color color)
        {
           
            _colorDal.Add(color);
                return new SuccessResult(Messages.SuccessMessage);
            

        }

        [ValidationAspect(typeof(ColorValidator))]
        public IResult Delete(Color color)
        {
            _colorDal.Delete(color);
            return new SuccessResult(Messages.SuccessMessage);
        }


        public IDataResult<List<Color>> GetAll()
        {
            if (DateTime.Now.Hour >= 20)
            {
                return new ErrorDataResult<List<Color>>(Messages.ErrorDataMessage);
            }
            else
            {
                return new SuccessDataResult<List<Color>>(_colorDal.GetAll(), Messages.SuccessDataMessage);

            }
        }

        public IDataResult<Color> GetByID(int colorID)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorId == colorID), Messages.SuccessDataMessage);
        }
        [ValidationAspect(typeof(ColorValidator))]
        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new ErrorResult(Messages.ErrorMessage);

        }
    }
}
