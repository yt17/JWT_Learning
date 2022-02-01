using BL.Abstracts;
using CORE.Classes;
using DAL.Abstracts;
using Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Concrete
{
    public class UserService : IUserService
    {
        private IUserDAL userDAL;
        public UserService(IUserDAL userDAL)
        {
            this.userDAL = userDAL;
        }
        public void Add(User user)
        {
            userDAL.Insert(user);
        }

        public User GetUserByMail(string mail)
        {
            return userDAL.Get(w => w.Email == mail);//revize
        }

        public List<OperationClaims> GetUserOperationClaims(User user)
        {
            return userDAL.GetClaims(user);
        }
    }
}
