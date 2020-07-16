using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class OperadorESController : ControllerBase
    {
        private readonly IOperadorESApplication _operadorESApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public OperadorESController(
            IOperadorESApplication operadorESApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication
            )
        {
            this._operadorESApplication = operadorESApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }
        [HttpGet]
        public async Task<Response<OperadorESDto.RSGet>> Get(string sInput)
        {
            try
            {
                return await this._operadorESApplication.Get(sInput);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorES-Get", ex, sInput);
                return new Response<OperadorESDto.RSGet>
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
                return await this._operadorESApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorES-GetAllByFilter", ex, nPagina, sFilter);
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpPost]
        public async Task<Response<int>> Insert([FromBody]OperadorESDto.RQInsert input)
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
                //var rEnterpriseNew = await this._sSOApplication.EnterpriseNew(input.sRuc);
                //if (!rEnterpriseNew.IsSuccess)
                //{
                //    responseInsert.Message = rEnterpriseNew.Message;
                //    return responseInsert;
                //}
                //if (rEnterpriseNew.Data.IdPersona == 0)
                //{
                //    responseInsert.Message = "Ya se encuentra registrado.";
                //    return responseInsert;
                //}
                // ASIGNAR APLICATIVO A MUNICIPALIDAD EN EL SSO 75066
                //var rEnterpriseAttachApp = await this._sSOApplication.EnterpriseAttachApp(
                //    rEnterpriseNew.Data.IdPersona.ToString(),
                //    input.sRuc);
                //if (!rEnterpriseAttachApp.IsSuccess)
                //{
                //    responseInsert.Message = rEnterpriseAttachApp.Message;
                //    return responseInsert;
                //}
                // CREAR LOCAL DE MUNICIPALIDAD EN EL SSO 6213
                //var rEnterpriseAddLocal = await this._sSOApplication.EnterpriseAddLocal(
                //    rEnterpriseNew.Data.IdPersona.ToString(),
                //    input.sRuc,
                //    rEnterpriseAttachApp.Data.Value,
                //    "LOCAL PRINCIPAL",
                //    "-"
                //    );
                //if (!rEnterpriseAddLocal.IsSuccess)
                //{
                //    responseInsert.Message = rEnterpriseAddLocal.Message;
                //    return responseInsert;
                //}
                //input.nIdentidadsso = rEnterpriseNew.Data.IdPersona;
                //input.nIdLocalsso = Int32.Parse(rEnterpriseAddLocal.Data.Value);
                return await this._operadorESApplication.Insert(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorES-Insert", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Update([FromBody]OperadorESDto.RQUpdate input)
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
                return await this._operadorESApplication.Update(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorES-Update", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Delete([FromBody]OperadorESDto.RQDelete input)
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
                return await this._operadorESApplication.Delete(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorES-Delete", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
    }
}
