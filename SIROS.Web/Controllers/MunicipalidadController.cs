using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIROS.Web.Controllers
{
    [Authorize]
    [Route("api/[Controller]/[Action]")]
    public class MunicipalidadController : ControllerBase
    {
        private readonly IMunicipalidadApplication _municipalidadApplication;
        private readonly ISSOApplication _sSOApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public MunicipalidadController(
            IMunicipalidadApplication municipalidadApplication,
            ISSOApplication sSOApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication
            )
        {
            this._municipalidadApplication = municipalidadApplication;
            this._sSOApplication = sSOApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }
        [HttpGet]
        public async Task<Response<MunicipalidadDto.RSGet>> Get(string sInput)
        {
            try
            {
                return await _municipalidadApplication.Get(sInput);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("MunicipalidadController-Get", ex);
                return new Response<MunicipalidadDto.RSGet>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int nPagina,string sFilter)
        {
            try
            {
                int nCantidadXPagina = 10;
                return await _municipalidadApplication.GetAllByFilter(nCantidadXPagina,nPagina,sFilter);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("MunicipalidadController-GetAllByFilter", ex);
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        
        [HttpPost]
        public async Task<Response<int>> Insert([FromBody]MunicipalidadDto.RQInsert input)
        {
            try
            {
                input.nIdSession = 0;
                input.sUsuario = "";
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    input.nIdSession = Int32.Parse(oUserInfo.Data.sIdSession);
                    input.sUsuario = oUserInfo.Data.sUsername;
                }
                var responseInsert = new Response<int>();
                // INSERTAR MUNICIPALIDAD EN EL SSO 58930 60288
                var rEnterpriseNew = await this._sSOApplication.EnterpriseNew(input.sRuc);
                if (!rEnterpriseNew.IsSuccess)
                {
                    responseInsert.Message = rEnterpriseNew.Message;
                    return responseInsert;
                }
                if(rEnterpriseNew.Data.IdPersona == 0)
                {
                    responseInsert.Message = "Ya se encuentra registrado.";
                    return responseInsert;
                }
                // ASIGNAR APLICATIVO A MUNICIPALIDAD EN EL SSO 75066
                var rEnterpriseAttachApp = await this._sSOApplication.EnterpriseAttachApp(
                    rEnterpriseNew.Data.IdPersona.ToString(),
                    input.sRuc);
                if (!rEnterpriseAttachApp.IsSuccess)
                {
                    responseInsert.Message = rEnterpriseAttachApp.Message;
                    return responseInsert;
                }
                // CREAR LOCAL DE MUNICIPALIDAD EN EL SSO 6213
                var rEnterpriseAddLocal = await this._sSOApplication.EnterpriseAddLocal(
                    rEnterpriseNew.Data.IdPersona.ToString(),
                    input.sRuc,
                    rEnterpriseAttachApp.Data.Value,
                    "LOCAL PRINCIPAL",
                    "-"
                    );
                if (!rEnterpriseAddLocal.IsSuccess)
                {
                    responseInsert.Message = rEnterpriseAddLocal.Message;
                    return responseInsert;
                }
                input.nIdentidadsso = rEnterpriseNew.Data.IdPersona;
                input.nIdLocalsso = Int32.Parse(rEnterpriseAddLocal.Data.Value);
                return await _municipalidadApplication.Insert(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("MunicipalidadController-Insert", ex);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Update([FromBody]MunicipalidadDto.RQUpdate input)
        {
            try
            {
                input.nIdSession = 0;
                input.sUsuario = "";
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    input.nIdSession = Int32.Parse(oUserInfo.Data.sIdSession);
                    input.sUsuario = oUserInfo.Data.sUsername;
                }
                return await _municipalidadApplication.Update(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("MunicipalidadController-Update", ex);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Delete([FromBody]MunicipalidadDto.RQDelete input)
        {
            try
            {
                input.nIdSession = 0;
                input.sUsuario = "";
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    input.nIdSession = Int32.Parse(oUserInfo.Data.sIdSession);
                    input.sUsuario = oUserInfo.Data.sUsername;
                }
                return await _municipalidadApplication.Delete(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("MunicipalidadController-Delete", ex);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
    }
}
