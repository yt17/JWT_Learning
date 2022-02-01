using CORE.EF;
using DAL.Abstracts;
using DAL.EF;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using CORE.Classes;

namespace DAL.Concrete
{
    public class UserDAL : EFrepository<AppDbContext, User>, IUserDAL
    {
        public List<OperationClaims> GetClaims(User user)
        {
            using (var context=new AppDbContext())
            {
                var res=  from OperationClaims_ in context.operationClaims
                          join UserOperationClaims_ in context.userOperationClaims
                          on OperationClaims_.Id equals UserOperationClaims_.OperationClaimId
                          where UserOperationClaims_.UserId == user.Id
                          select new OperationClaims { Id = OperationClaims_.Id, Name = OperationClaims_.Name };
                return res.ToList();
            }
        }
    }
}
