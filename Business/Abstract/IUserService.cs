using Core.Entities.Concrete;
using Core.Entity.Concrete;
using Core.Utilities;
using Core.Utilities.Abstract;
using Entities.Concrete;
using Entities.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
     public interface IUserService
    {
        IResult Add(User user);
        IResult Update(UserForGetDto user);
        IResult Delete(User user);
        IDataResult<List<User>> GetAll();
        IDataResult<User> GetByID(int userID);
        List<OperationClaim> GetClaims(User user);
        User GetByMail(string email);
        IDataResult<List<UserForGetDto>> GetUserDTO(string email);

    }
}
