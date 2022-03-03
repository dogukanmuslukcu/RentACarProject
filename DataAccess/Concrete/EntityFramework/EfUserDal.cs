using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using Core.Entity.Concrete;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Entities.DTOs;
using System.Linq.Expressions;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : IEfEntityRepositoryBase<User, ReCapProjectDBContext>, IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new ReCapProjectDBContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperationClaim in context.UserOperationClaims
                                 on operationClaim.Id equals userOperationClaim.OperationClaimId
                             where userOperationClaim.UserId == user.UserId
                             select new OperationClaim { Id = operationClaim.Id, Name = operationClaim.Name };
                return result.ToList();

            }
        }

        public List<UserForGetDto> GetUserDTO(Expression<Func<UserForGetDto, bool>> filter = null)
        {
            using (ReCapProjectDBContext context = new ReCapProjectDBContext())
            {
                var resultList = from user in context.Users
                                 
                                 select new UserForGetDto { UserId = user.UserId, Email=user.Email, FirstName=user.FirstName, LastName=user.LastName};

                return filter == null ? resultList.ToList() : resultList.Where(filter).ToList();


            }
        }
    }
}
