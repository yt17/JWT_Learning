using CORE.Classes;
using System;
using System.Collections.Generic;
using System.Text;

namespace CORE.Jwt
{
    public interface ITokenHelper
    {
        AccessToken CreateToken(User user, List<OperationClaims> operationClaims);
    }
}
