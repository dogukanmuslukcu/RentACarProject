using Business.Abstract;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Validation;
using Core.CrossCuttingConcerns.Validation.FluentValidation;
using Core.Entities.Concrete;
using Core.Entity.Concrete;
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
   public class UserManager:IUserService
    {
        IUserDal _userDal;

        public UserManager(IUserDal userDal)
        {
            _userDal = userDal;
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Add(User user)
        {
          
            _userDal.Add(user);
            return new SuccessResult(Messages.SuccessMessage);
        }

        [ValidationAspect(typeof(UserValidator))]
        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult(Messages.SuccessMessage);
        }

        public IDataResult<List<User>> GetAll()
        {
            return new SuccessDataResult<List<User>>(_userDal.GetAll(), Messages.SuccessDataMessage);
        }

        public IDataResult<User> GetByID(int userID)
        {
            return new SuccessDataResult<User>(_userDal.Get(u=>u.UserId==userID),Messages.SuccessDataMessage);
        }

        public User GetByMail(string email)
        {
            return _userDal.Get(m => m.Email == email);
        }
        
        public List<OperationClaim> GetClaims(User user)
        {
            return _userDal.GetClaims(user);
        }

        public IDataResult<List<UserForGetDto>> GetUserDTO(string email)
        {
            return new SuccessDataResult<List<UserForGetDto>>(_userDal.GetUserDTO(m=>m.Email==email), Messages.SuccessDataMessage);
        }

       //[ValidationAspect(typeof(UserValidator))]
        public IResult Update(UserForGetDto user)
        {
            var userUpdate = _userDal.Get(u => u.UserId == user.UserId);
            userUpdate.FirstName = user.FirstName;
            userUpdate.LastName = user.LastName;
            userUpdate.Email = user.Email;
            _userDal.Update(userUpdate);
             return new SuccessResult(Messages.SuccessMessage);
        }
    }
}
