using Business.Abstract;
using Business.Constants;
using Core.Utilities;
using Core.Utilities.Abstract;
using Core.Utilities.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;

namespace Business.Concrete
{
    public class BrandManager : IBrandService
    {
        IBrandDal _brandDal;

        public BrandManager(IBrandDal brandDal)
        {
            _brandDal = brandDal;
        }

        public IResult Add(Brand brand)
        {
            if (brand.BrandName.Length >= 2)
            {
                _brandDal.Add(brand);
                return new SuccessResult(Messages.SuccessMessage);
            }
            else
            {
                return new ErrorResult(Messages.ErrorMessage);

            }


        }


        public IResult Delete(Brand brand)
        {
            _brandDal.Delete(brand);
            return new SuccessResult(Messages.SuccessMessage);
        }
        public IResult Update(Brand brand)
        {
            _brandDal.Update(brand);
            return new SuccessResult(Messages.SuccessMessage);

        }

        public IDataResult<List<Brand>> GetAll()
        {
            return new SuccessDataResult<List<Brand>>(_brandDal.GetAll(),Messages.SuccessDataMessage);
        }

        public IDataResult<Brand> GetByID(int brandID)
        {
            return new SuccessDataResult<Brand>(_brandDal.Get(b => b.BrandId == brandID),Messages.SuccessDataMessage);
        }
    }

}

