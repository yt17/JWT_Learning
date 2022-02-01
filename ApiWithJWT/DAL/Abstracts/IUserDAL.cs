using CORE.Classes;
using CORE.EF;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Abstracts
{
    public interface IUserDAL : IRepository<User>
    {
        List<OperationClaims> GetClaims(User user);
    }
}
