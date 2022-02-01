using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Jwt
{
    public class TokenOptions
    {
        public string Audince { get; set; }
        public string Issuer { get; set; }
        public int AccesTokenExpiration { get; set; }
        public string SecurityKey { get; set; }
    }
}
