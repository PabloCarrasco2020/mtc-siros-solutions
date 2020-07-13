using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Authorize]
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class EstacionServicioController : ControllerBase
    {
        private readonly IEstacionServicioApplication _estacionServicioApplication;
        private readonly ISSOApplication _sSOApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public EstacionServicioController(
            IEstacionServicioApplication estacionServicioApplication,
            ISSOApplication sSOApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication
            )
        {
            this._estacionServicioApplication = estacionServicioApplication;
            this._sSOApplication = sSOApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }
        [HttpGet]
        public async Task<Response<EstacionServicioDto.RSGet>> Get(string sInput)
        {
            try
            {
                return await _estacionServicioApplication.Get(sInput);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "EstacionServicio-Get", ex, sInput);
                return new Response<EstacionServicioDto.RSGet>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int nPagina, string sFilter)
        {
            try
            {
                int nCantidadXPagina = 10;
                return await _estacionServicioApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "EstacionServicio-GetAllByFilter", ex, nPagina, sFilter);
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpPost]
        public async Task<Response<int>> Insert([FromBody]EstacionServicioDto.RQInsert input)
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
                if (rEnterpriseNew.Data.IdPersona == 0)
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
                return await _estacionServicioApplication.Insert(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "EstacionServicio-Insert", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Update([FromBody]EstacionServicioDto.RQUpdate input)
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
                return await _estacionServicioApplication.Update(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "EstacionServicio-Update", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Delete([FromBody]EstacionServicioDto.RQDelete input)
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
                return await _estacionServicioApplication.Delete(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "EstacionServicio-Delete", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
    }
}
