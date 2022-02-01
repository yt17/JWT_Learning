using BL.Abstracts;
using CORE.Classes;
using CORE.Helper;
using CORE.Jwt;
using DAL.Abstracts;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Concrete
{
    public class AuthService : IAuthService
    {
        private IUserService IUserService;
        private ITokenHelper tokenHelper;
        public AuthService(IUserService IUserService, ITokenHelper tokenHelper)
        {
            this.IUserService = IUserService;
            this.tokenHelper = tokenHelper;
        }
        public Result<AccessToken> CreateAccessToken(User user)
        {
            var claims=IUserService.GetUserOperationClaims(user);
            var token=tokenHelper.CreateToken(user, claims);
            return new Result<AccessToken>(1, "token", token);
            
        }

        public Result<User> Login(LoginDTO loginDTO)
        {
            var check = IUserService.GetUserByMail(loginDTO.email);
            if (check==null)
            {
                return new Result<User>(0, "user not found", null);
            }
            if (!HashHelper.verifyPasswordHash(loginDTO.password, check.PasswordHash, check.PasswordSalt))
            {
                return new Result<User>(0, "wrong found", null);
            }
            return new Result<User>(1, "login successfull", check);
        }

        public Result<User> Register(RegisterDTO registerDTO, string password)
        {
            byte[] passwordhash, passwordsalt;
            HashHelper.CreatePasswordHash(password,out passwordhash,out passwordsalt);
            var user = new User()
            {
                Email = registerDTO.email,
                FirstName = registerDTO.Firstname,
                LastName = registerDTO.Lastname,
                Status = true,
                PasswordHash = passwordhash,
                PasswordSalt = passwordsalt,
            };
            IUserService.Add(user);
            return new Result<User>(1, "user found", user);
            
        }

        public Result<string> UserExists(string email)
        {
            var check = IUserService.GetUserByMail(email);
            if (check == null)
            {
                return new Result<string>(0, "user not found", null);
            }
            return new Result<string>(1, "user found", null);
        }
    }
}
