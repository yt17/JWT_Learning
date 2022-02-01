using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Jwt
{
    public class HashHelper
    {
        public static void CreatePasswordHash(string Password,out byte[] passwordHash,out byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                passwordSalt = hmac.Key;
                passwordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(Password));
            }
        }

        public static bool verifyPasswordHash(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            using (var hmac=new System.Security.Cryptography.HMACSHA512())
            {
                var computehash = hmac.ComputeHash(Encoding.UTF8.GetBytes(password));
                for (int i = 0; i < computehash.Length; i++)
                {
                    if (computehash[i]!=passwordHash[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }

}
