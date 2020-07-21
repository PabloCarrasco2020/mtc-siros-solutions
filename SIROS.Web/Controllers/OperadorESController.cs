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
    [Authorize]
    [Route("api/[Controller]/[Action]")]
    [ApiController]
    public class OperadorESController : ControllerBase
    {
        private readonly IOperadorESApplication _operadorESApplication;
        private readonly IReniecApplication _reniecApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public OperadorESController(
            IOperadorESApplication operadorESApplication,
            IReniecApplication reniecApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication
            )
        {
            this._operadorESApplication = operadorESApplication;
            this._reniecApplication = reniecApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }
        [HttpGet]
        public async Task<Response<OperadorESDto.RSGet>> Get(string sInput)
        {
            try
            {
                var ResultGetOperador = await this._operadorESApplication.Get(sInput);
                if (!ResultGetOperador.IsSuccess)
                {
                    return ResultGetOperador;
                }
                if (ResultGetOperador.Data.nIdTpDocumento.Value == 1)
                {
                    var ResultReniec = await this._reniecApplication.ConsultaNumDoc(ResultGetOperador.Data.sNroDocumento);
                    if (ResultReniec.IsSuccess)
                    {
                        ResultGetOperador.Data.sFoto = ResultReniec.Data.sFoto;
                    }
                }
                return ResultGetOperador;
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
                // AGREGANDO LINEA DE CODIGO HASTA QUE DEFINAN COMO GUARDARAN LA FOTO QUE VIENE EN BASE 64
                input.sFoto = "";
                // END
                var responseInsert = new Response<int>();
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
