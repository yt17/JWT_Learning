using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Jwt
{
    public class AccessToken
    {
        public string Token { get; set; }
        public DateTime ExpireDate { get; set; }
    }
}
