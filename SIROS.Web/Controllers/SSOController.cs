using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Transversal.Common;
using Transversal.Common.Enums;
using Transversal.Common.Helper;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSOController : ControllerBase
    {
        private readonly ISSOApplication _sSOApplication;
        private readonly IAdminApplication _adminApplication;
        private readonly IJwtApplication _jwtApplication;
        private readonly ILogApplication _logApplication;
        private readonly ICaptchaApplication _captchaApplication;
        private readonly AppSettings.CredencialesSSO _settings;

        private List<string> _perfilesPermitidos;

        private string _sCaptchaHashKey = "C4PTCH4H4SH2020";
        private string CaptchaHash
        {
            get { return HttpContext.Session.GetString(_sCaptchaHashKey) as string; }
            set { HttpContext.Session.SetString(_sCaptchaHashKey, value); }
        }
        
        public SSOController(
            ISSOApplication sSOApplication,
            IAdminApplication adminApplication,
            IJwtApplication jwtApplication,
            ILogApplication logApplication,
            ICaptchaApplication captchaApplication,
            IOptions<AppSettings.CredencialesSSO> settings)
        {
            this._sSOApplication = sSOApplication;
            this._adminApplication = adminApplication;
            this._jwtApplication = jwtApplication;
            this._logApplication = logApplication;
            this._captchaApplication = captchaApplication;
            this._settings = settings.Value;

            string sPerfiles = this._settings.Profiles;
            this._perfilesPermitidos = new List<string>();
            this._perfilesPermitidos.AddRange(sPerfiles.Split(';'));
        }
        
        [AllowAnonymous]
        [HttpPost("Login")]
        public async Task<IActionResult> Login(SSODto.Login.RequestModel oItem)
        {
            try
            {
                var oResponse = new Response<SSODto.Login.Response>();
                oResponse.IsSuccess = false;

                #region VALIDACION DE CAPTCHA

                if (string.IsNullOrEmpty(oItem.sCode))
                {
                    oResponse.Message = Messages.SSO.Login.EX008;
                    return Ok(oResponse);
                }

                if (!this._captchaApplication.ComputeMd5Hash(oItem.sCode).Equals(CaptchaHash))
                {
                    HttpContext.Session.Remove(this._sCaptchaHashKey);
                    oResponse.Message = Messages.SSO.Login.EX009;
                    return Ok(oResponse);
                }

                if (CaptchaHash != null)
                    HttpContext.Session.Remove(this._sCaptchaHashKey);

                #endregion

                #region VALIDACION DE USUARIO

                var oUser = await this._sSOApplication.Login(oItem);
                if (!oUser.IsSuccess)
                {
                    oResponse.Message = Messages.SSO.Login.EX001;
                    return Ok(oResponse);
                }

                if (oUser.Data == null)
                {
                    oResponse.Message = Messages.SSO.Login.EX001;
                    return Ok(oResponse);
                }

                if (oUser.Data.IdUsuario == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX001;
                    return Ok(oResponse);
                }

                #endregion

                #region VALIDACION DE EMPRESAS

                var oEmpresas = await this._sSOApplication.GetEmpresas(oItem.sUsername);
                if (!oEmpresas.IsSuccess)
                {
                    oResponse.Message = Messages.SSO.Login.EX002;
                    return Ok(oResponse);
                }

                if (oEmpresas.Data == null)
                {
                    oResponse.Message = Messages.SSO.Login.EX002;
                    return Ok(oResponse);
                }

                if (oEmpresas.Data.Count == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX002;
                    return Ok(oResponse);
                }

                #endregion

                var oTmpEmpresa = oEmpresas.Data[0];

                #region VALIDACION DE LOCALES

                if (oTmpEmpresa.Locales == null)
                {
                    oResponse.Message = Messages.SSO.Login.EX003;
                    return Ok(oResponse);
                }

                if (oTmpEmpresa.Locales.Count == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX003;
                    return Ok(oResponse);
                }

                #endregion

                oUser.Data.nIdEmpresa = oTmpEmpresa.IdEmpresa;
                oUser.Data.sNombreEmpresa = oTmpEmpresa.NombreCentro;
                oUser.Data.nIdLocal = oTmpEmpresa.Locales[0].IdLocal;
                oUser.Data.sNombreLocal = oTmpEmpresa.Locales[0].NombreLocal;

                #region VALIDACION DE PERFILES

                var oPerfiles = await this._sSOApplication.GetPerfiles(oItem.sUsername, oUser.Data.nIdLocal.ToString());
                if (!oPerfiles.IsSuccess)
                {
                    oResponse.Message = Messages.SSO.Login.EX004;
                    return Ok(oResponse);
                }

                if (oPerfiles.Data == null)
                {
                    oResponse.Message = Messages.SSO.Login.EX004;
                    return Ok(oResponse);
                }

                if (oPerfiles.Data.Count == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX004;
                    return Ok(oResponse);
                }
               

#if DEBUG

                // ================================
                // ===== SECCION PARA PRUEBAS =====
                // ================================
                //oPerfiles.Data[0].NombreRol = "OGTU";
                //oPerfiles.Data[0].NombreRol = "Promovilidad";
#endif

                int nCantPerfilesValidos = 0;
                foreach (var item in oPerfiles.Data)
                {
                    nCantPerfilesValidos = this._perfilesPermitidos.Count(str => str.ToUpper().Equals(item.NombreRol.ToUpper()));
                    if (nCantPerfilesValidos > 0)
                    {
                        oUser.Data.nIdPerfil = item.IdRol;
                        oUser.Data.sNombrePerfil = item.NombreRol;
                        break;
                    }
                }

                if (nCantPerfilesValidos == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX005;
                    return Ok(oResponse);
                }

                #endregion

                #region VALIDACION INFORMACION DE USUARIO

                var oUserInfo = await this._sSOApplication.GetUserInfo(oUser.Data.IdUsuario);
                if (!oUserInfo.IsSuccess)
                {
                    oResponse.Message = Messages.SSO.Login.EX006;
                    return Ok(oResponse);
                }

                if (oUserInfo.Data == null)
                {
                    oResponse.Message = Messages.SSO.Login.EX006;
                    return Ok(oResponse);
                }

                if (oUserInfo.Data.PK_eIdUsuario == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX006;
                    return Ok(oResponse);
                }

                #endregion

                oUser.Data.sCorreo = oUserInfo.Data.uCorElectronico;
                oUser.Data.sNombreCompleto = oUserInfo.Data.NombreCompleto;

                #region VALIDACION DE REGISTRO DE SESION EN BD

                var oRequestRegistrarSesion = new AdminDto.RegistrarSesion();
                oRequestRegistrarSesion.sUsuario = oItem.sUsername.ToUpper();
                oRequestRegistrarSesion.sUsuarioSSO = null;
                oRequestRegistrarSesion.sIp = "0.0.0.0";
                oRequestRegistrarSesion.sFlag = "1";
                oRequestRegistrarSesion.nIdSessionSSO = oUser.Data.IdUsuario;

                var oRegistroSesion = await this._adminApplication.RegistrarSesion(oRequestRegistrarSesion);
                if (!oRegistroSesion.IsSuccess)
                {
                    oResponse.Message = Messages.SSO.Login.EX007;
                    return Ok(oResponse);
                }

                if (oRegistroSesion.Data == 0)
                {
                    oResponse.Message = Messages.SSO.Login.EX007;
                    return Ok(oResponse);
                }

                #endregion

                oUser.Data.nIdSession = oRegistroSesion.Data; //Obtiene Id Sesion del SIRO

                #region GENERAR JWT

                var oJwt = new JwtDto.Request();
                oJwt.sUsername = oItem.sUsername.ToUpper(); //Forzar mayuscula
                oJwt.sUsernameSSO = oUser.Data.IdUsuario.ToString();
                oJwt.sProfile = oUser.Data.sNombrePerfil;
                oJwt.sIdSession = oUser.Data.nIdSession.ToString();

                var oToken = await this._jwtApplication.GenerateJwtToken(oJwt);
                oUser.Data.sToken = oToken.Data.sToken;
                oUser.Data.dTokenExpiration = oToken.Data.dTokenExpiration;

                #endregion

                oResponse.IsSuccess = true;
                oResponse.Data = oUser.Data;
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "SSO-Login", ex, oItem);
                return Ok(new Response<Object> { Message = $"[SSO]: ERR-Fallo en el servidor: {ex.StackTrace}" });
            }
        }

        [AllowAnonymous]
        [Route("GetCaptcha")]
        [HttpGet]
        public ActionResult GetCaptcha()
        {
            var randomText = this._captchaApplication.GenerateRandomText(4);
            CaptchaHash = this._captchaApplication.ComputeMd5Hash(randomText);
            return File(this._captchaApplication.GenerateCaptchaImage(randomText), "image/gif");
        }
    }
}
