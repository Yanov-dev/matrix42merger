using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Web.Script.Serialization;
using JWT;
using Matrix42Merger.Dto;
using Matrix42Merger.Extensions;
using Matrix42Merger.Options.Auth;
using Microsoft.IdentityModel.Tokens;

namespace Matrix42Merger.Services.AuthService
{
    public class AuthService : IAuthService
    {
        private readonly IAuthOptions _authOptions;

        public AuthService(IAuthOptions authOptions)
        {
            _authOptions = authOptions;
        }

        public string GenerateJwtToken(UserInfoDto userInfoDto)
        {
            var identity = GetIdentity(userInfoDto);

            var now = DateTime.Now;

            var jwt = new JwtSecurityToken(
                _authOptions.Issuer,
                _authOptions.Audience,
                notBefore: now,
                claims: identity.Claims,
                expires: now.Add(_authOptions.Lifetime),
                signingCredentials: new SigningCredentials(GetSymmetricSecurityKey(_authOptions.EncryptKey),
                    SecurityAlgorithms.HmacSha256));

            return new JwtSecurityTokenHandler().WriteToken(jwt);
        }

        public bool IsTokenValid(string token)
        {
            var jsonSerializer = new JavaScriptSerializer();
            var decodedToken = JsonWebToken.Decode(token, _authOptions.EncryptKey);
            var data = jsonSerializer.Deserialize<Dictionary<string, object>>(decodedToken);
            if (!data.TryGetValue("exp", out var exp))
                return false;

            if (!long.TryParse(exp.ToString(), out var unixTime))
                return false;

            var validTo = unixTime.UnixTimeToDateTime();
            if (DateTime.Compare(validTo, DateTime.UtcNow) <= 0)
                return false;

            return true;
        }

        private ClaimsIdentity GetIdentity(UserInfoDto userInfoDto)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, userInfoDto.UserName),
                new Claim(ClaimsIdentity.DefaultRoleClaimType, userInfoDto.Role)
            };
            var claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }

        private SymmetricSecurityKey GetSymmetricSecurityKey(string encryptKey)
        {
            return new SymmetricSecurityKey(Encoding.ASCII.GetBytes(encryptKey));
        }
    }
}