using CORE.Classes;
using CORE.EF;
using DAL.Abstracts;
using DAL.EF;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Concrete
{
    public class UserOperationClaimsDAL : EFrepository<AppDbContext, UserOperationClaims>, IUserOperationClaims
    {

    }
}
