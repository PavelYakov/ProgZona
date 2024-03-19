using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using JwtAuthManager.Models;
using Microsoft.IdentityModel.Tokens;

namespace JwtAuthManager
{
    public class JwtTokenHandler
    {
        public const string JWT_SECURITY_KEY = "5d+f4ZdXvShHk3wBUZSd5DbTGivwVEwSiE7sX3YxT6M";
        private const int JWT_TOKEN_VALIDITY_MINS = 20;
        private readonly List<UserAccount> _userAccountsList;

        public JwtTokenHandler()
        {
            _userAccountsList = new List<UserAccount>
            {
                new UserAccount { UserName = "admin", Password = "123", Role = "Administrator" },
                new UserAccount { UserName = "user1", Password = "333", Role = "User" }
            };
        }

        public AuthenticationResponse? GenerateJwtToken(AuthenticationRequest authenticationRequest)
        {
            if (string.IsNullOrWhiteSpace(authenticationRequest.UserName) ||
                string.IsNullOrWhiteSpace(authenticationRequest.Password))
                return null;
            /*Validation*/
            var userAccount = _userAccountsList.FirstOrDefault(x =>
                x.UserName == authenticationRequest.UserName && x.Password == authenticationRequest.Password);
            if (userAccount == null) return null;

            var tokenExpiryTimeStamp = DateTime.Now.AddMinutes(JWT_TOKEN_VALIDITY_MINS);
            var tokenKey = Encoding.ASCII.GetBytes(JWT_SECURITY_KEY);
            var claimsIdentity = new ClaimsIdentity(new List<Claim>
            {
                new Claim(JwtRegisteredClaimNames.Name, authenticationRequest.UserName),
                new Claim(ClaimTypes.Role, userAccount.Role)
            });

            var signingCredentials = new SigningCredentials
            (
                new SymmetricSecurityKey(tokenKey),
                SecurityAlgorithms.HmacSha256Signature
            );

            var securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claimsIdentity,
                Expires = tokenExpiryTimeStamp,
                SigningCredentials = signingCredentials

            };
            var jwtSecurityTokenHandler = new JwtSecurityTokenHandler();
            var securityToken = jwtSecurityTokenHandler.CreateToken(securityTokenDescriptor);
            var token = jwtSecurityTokenHandler.WriteToken(securityToken);

            return new AuthenticationResponse
            {
                UserName = userAccount.UserName,
                ExpiresIn = (int)tokenExpiryTimeStamp.Subtract(DateTime.Now).TotalSeconds,
                JwtToken = token
            };
        }
    }
}
