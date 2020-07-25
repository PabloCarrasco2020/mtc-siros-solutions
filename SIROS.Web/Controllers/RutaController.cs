using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Authorize(Roles = "OGTU")]
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class RutaController : ControllerBase
    {
        private readonly IRutaApplication _rutaApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public RutaController(
            IRutaApplication rutaApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._rutaApplication = rutaApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }
        [HttpGet]
        public async Task<Response<RutaDto.RSGet>> Get(string sInput)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    sInput = $"{sInput}@{oUserInfo.Data.nIdEmpresa}";
                }
                return await _rutaApplication.Get(sInput);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaController-Get", ex, sInput);
                return new Response<RutaDto.RSGet>
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
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    sFilter = $"{sFilter}@{oUserInfo.Data.nIdEmpresa}";
                }
                return await _rutaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Ruta-GetAllByFilter", ex, nPagina, sFilter);
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpPost]
        public async Task<Response<int>> Insert([FromBody] RutaDto.RQInsert input)
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
                    input.nIdentidadUsuario = oUserInfo.Data.nIdEmpresa;
                }
                var responseInsert = new Response<int>();

                return await this._rutaApplication.Insert(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaController-Insert", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpPost]
        public async Task<Response<int>> Update([FromBody] RutaDto.RQUpdate input)
        {
            try
            {
                input.nIdSession = 0;
                input.sUsuario = "";
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    //input.nIdentidadUsuario = oUserInfo.Data.nIdEmpresa;
                    input.nIdentidadUsuario = 1166;
                    input.nIdSession = Int32.Parse(oUserInfo.Data.sIdSession);
                    input.sUsuario = oUserInfo.Data.sUsername;
                }
                return await _rutaApplication.Update(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaController-Update", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

        [HttpPost]
        public async Task<Response<int>> Delete([FromBody] RutaDto.RQDelete input)
        {
            try
            {
                input.nIdSession = 0;
                input.sUsuario = "";
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (oUserInfo.IsSuccess)
                {
                    //input.nIdentidadUsuario = oUserInfo.Data.nIdEmpresa;
                    input.nIdentidadUsuario = 1166;
                    input.nIdSession = Int32.Parse(oUserInfo.Data.sIdSession);
                    input.sUsuario = oUserInfo.Data.sUsername;
                }
                return await _rutaApplication.Delete(input);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaController-Delete", ex, input);
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
    }
}
