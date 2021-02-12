using Business.Abstract;
using Business.Constants;
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

        public IResult Add(Color color)
        {
            if (color.ColorName.Length >= 2)
            {
                _colorDal.Add(color);
                return new SuccessResult(Messages.SuccessMessage);
            }
            else
            {
                return new ErrorResult(Messages.ErrorMessage);
            }

        }

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

        public IDataResult<Color> GetByID(int id)
        {
            return new SuccessDataResult<Color>(_colorDal.Get(c => c.ColorID == id), Messages.SuccessDataMessage);
        }

        public IResult Update(Color color)
        {
            _colorDal.Update(color);
            return new ErrorResult(Messages.ErrorMessage);

        }
    }
}
