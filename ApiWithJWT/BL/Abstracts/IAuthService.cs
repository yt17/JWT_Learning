using CORE.Classes;
using CORE.Helper;
using CORE.Jwt;
using ModelsDTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace BL.Abstracts
{
    public interface IAuthService
    {
        Result<User> Register(RegisterDTO registerDTO, string password);
        Result<User> Login(LoginDTO loginDTO);
        Result<string> UserExists(string email);
        Result<AccessToken> CreateAccessToken(User user);

    }
}
