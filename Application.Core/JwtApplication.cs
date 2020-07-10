using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Helper;

namespace Application.Core
{
    public class JwtApplication : IJwtApplication
    {
        private readonly AppSettings.JWT _settings;

        public JwtApplication(IOptions<AppSettings.JWT> settings)
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
                DateTime dTokenExpiration = dCurrentDate.AddMinutes(Convert.ToInt32(this._settings.MinutesExpiration));

                var oTokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = new ClaimsIdentity(new Claim[]
                    {
                        new Claim(ClaimTypes.Name, oItem.sUsername),
                        new Claim(ClaimTypes.Sid, oItem.sUsernameSSO),
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

        public async Task<Response<JwtDto.Request>> GetUserInfo(ClaimsPrincipal oUser)
        {
            var oResponse = new Response<JwtDto.Request>();
            oResponse.IsSuccess = false;

            try
            {
                if (!oUser.Identity.IsAuthenticated)
                {
                    oResponse.Message = "El Usuario no esta conectado.";
                    return oResponse;
                }

                if (oUser.Claims == null)
                {
                    oResponse.Message = "El Usuario no tiene datos.";
                    return oResponse;
                }

                if (oUser.Claims.Count() == 0)
                {
                    oResponse.Message = "El Usuario no tiene datos.";
                    return oResponse;
                }

                var oResult = new JwtDto.Request();
                oResult.sUsername = oUser.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Name)) ? .Value;
                oResult.sUsernameSSO = oUser.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Sid)) ? .Value;
                oResult.sProfile = oUser.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.Role)) ? .Value;
                oResult.sIdSession = oUser.Claims.FirstOrDefault(x => x.Type.Equals(ClaimTypes.NameIdentifier)) ? .Value;

                oResponse.IsSuccess = true;
                oResponse.Data = oResult;
                return oResponse;
            }
            catch (Exception ex)
            {
                return oResponse;
            }
        }
    }
}
