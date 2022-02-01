using CORE.Classes;
using CORE.Extensions;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;

namespace CORE.Jwt
{
    public class TokenHelper : ITokenHelper
    {
        private IConfiguration configuration;
        private TokenOptions tokenOptions;
        private DateTime TokenExpirationTime;
        public TokenHelper(IConfiguration configuration)
        {
            this.configuration = configuration;
            this.tokenOptions = configuration.GetSection("TokenOptions").Get<TokenOptions>();
            TokenExpirationTime = DateTime.Now.AddMinutes(tokenOptions.AccesTokenExpiration);

        }
        public AccessToken CreateToken(User user, List<OperationClaims> operationClaims)
        {
            var SecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(tokenOptions.SecurityKey));
            var signinCredantial = new SigningCredentials(SecurityKey, SecurityAlgorithms.HmacSha256Signature);
            var jwt = CreatejwtSecurityToken(tokenOptions, user, signinCredantial, operationClaims);
            var jwtSecurity = new JwtSecurityTokenHandler();
            var token = jwtSecurity.WriteToken(jwt);
            return new AccessToken { Token = token, ExpireDate = TokenExpirationTime };
        }

        public JwtSecurityToken CreatejwtSecurityToken(TokenOptions tokenOptions, User user, SigningCredentials signingCredentials, List<OperationClaims> operationClaims)
        {
            var jwt = new JwtSecurityToken(
                issuer: tokenOptions.Issuer,
                audience: tokenOptions.Audince,
                expires: TokenExpirationTime,
                notBefore: DateTime.Now,
                claims: SetClaims(user,operationClaims),
                signingCredentials: signingCredentials
                );
            return jwt;
        }

        private IEnumerable<Claim> SetClaims(User user, List<OperationClaims> operationClaims)
        {
            var claims = new List<Claim>();
            claims.AddName(user.FirstName);
            claims.AddEmail(user.Email);
            claims.AddRoles(operationClaims.Select(q=>q.Name).ToArray()) ;
            claims.AddNameIdentifier(user.Id.ToString());
            return claims;
            //claims.Add(new Claim("email", user.Email));

        }
    }
}
