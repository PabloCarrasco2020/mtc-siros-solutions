using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Transversal.Common;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSOController : ControllerBase
    {
        private readonly ISSOApplication _sSOApplication;
        private readonly IConfiguration _configuration;

        private List<string> _perfilesPermitidos;

        public SSOController(ISSOApplication sSOApplication, IConfiguration configuration)
        {
            this._sSOApplication = sSOApplication;
            this._configuration = configuration;

            string sPerfiles = this._configuration.GetSection("CredencialesSSO").GetSection("Perfiles").Value;
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
                oPerfiles.Data[0].NombreRol = "Promovilidad";
                oUser.Data.sToken = "TOKEN";
                oUser.Data.dTokenExpiration = DateTime.Now.AddHours(2);

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

                oResponse.IsSuccess = true;
                oResponse.Data = oUser.Data;
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                // log
                return Ok(new Response<Object> { Message = "[SSO]: ERR-Fallo en el servidor" });
            }
        }
    }
}
