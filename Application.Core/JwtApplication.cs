using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class JwtApplication : IJwtApplication
    {
        private readonly JwtDto.Settings _settings;

        public JwtApplication(IOptions<JwtDto.Settings> settings)
        {
            this._settings = settings.Value;
        }
        
        public async Task<Response<JwtDto.Response>> GenerateJwtToken(JwtDto.Request oItem)
        {
            try
            {
                var oTokenHandler = new JwtSecurityTokenHandler();
                var oSecretKey = Encoding.ASCII.GetBytes(this._settings.SecretKey);
                DateTime dCurrentDate = DateTime.Now;
                DateTime dTokenExpiration = dCurrentDate.AddHours(Convert.ToInt32(this._settings.HoursExpiration));

                var oTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, oItem.sUsername),
                        new Claim(ClaimTypes.Role, oItem.sProfile),
                        new Claim(ClaimTypes.NameIdentifier, oItem.sIdSession)
                    }),
                    NotBefore = dCurrentDate,
                    Expires = dTokenExpiration,
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(oSecretKey), SecurityAlgorithms.HmacSha256Signature)
                };
                var oToken = oTokenHandler.CreateToken(oTokenDescriptor);
                string sToken = oTokenHandler.WriteToken(oToken);

                var oResult = new JwtDto.Response();
                oResult.sToken = sToken;
                oResult.dTokenExpiration = dTokenExpiration;

                var oResponse = new Response<JwtDto.Response>();
                oResponse.IsSuccess = true;
                oResponse.Data = oResult;
                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
