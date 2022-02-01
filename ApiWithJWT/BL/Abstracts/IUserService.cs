using CORE.Classes;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstracts
{
    public interface  IUserService
    {
        List<OperationClaims> GetUserOperationClaims(User user);
        void Add(User user);
        User GetUserByMail(string mail);

    }
}
