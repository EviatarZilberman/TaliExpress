using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using TaliExpress.Server.SecuritySettings.Classes;
using TaliExpress.Server.SecuritySettings.Managers;
using TaliExpress.Server.SecuritySettings.SecuritySettingsModels;

namespace TaliExpress.Server.SecuritySettings.Handlers
{
    public static class JWTCreationHandler
    {
        public static string CreateJwt(JwtRequest request)
        {
            SecuritySettingsManager securitySettingsManager = new SecuritySettingsManager();
            securitySettingsManager.FindBySubjectId("Issuer", out SecuritySettingsDbModel securitySettingsDbModel1);
            securitySettingsManager.FindBySubjectId("Audience", out SecuritySettingsDbModel securitySettingsDbModel2);
            securitySettingsManager.FindBySubjectId("Key", out SecuritySettingsDbModel securitySettingsDbModel3);
            var keyInBytes = Encoding.UTF8.GetBytes(securitySettingsDbModel3.Value);
            var tokenHandler = new JwtSecurityTokenHandler();

            List<Claim> claims = new List<Claim>();
            foreach (KeyValuePair<string, string> pair in request.JwtPairs)
            {
                claims.Add(new Claim(pair.Key, pair.Value));
            }

            SecurityTokenDescriptor securityTokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(request.ExpireInSeconds),
                Issuer = securitySettingsDbModel1.Value,
                Audience = securitySettingsDbModel2.Value,
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(keyInBytes), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(securityTokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}