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
    [Route("api/[controller]")]
    [ApiController]
    public class ContratoEsController : ControllerBase
    {
        private readonly IContratoEsApplication _contratoEsApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public ContratoEsController(
            IContratoEsApplication contratoEsApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._contratoEsApplication = contratoEsApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string sInput)
        {
            try
            {
                var oResult = await this._contratoEsApplication.Get(sInput);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "ContratoEs-Get", ex, sInput);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpGet("GetAllByFilter")]
        public async Task<IActionResult> GetAllByFilter(int nPagina, string sFilter)
        {
            try
            {
                int nCantidadXPagina = 10;
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                sFilter = $"{sFilter}@{oUserInfo.Data.nIdEmpresa}";
                var oResult = await this._contratoEsApplication.GetAllByFilter(nCantidadXPagina,nPagina,sFilter);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "ContratoEs-GetAllByFilter", ex, nPagina, sFilter);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(ContratoEsDto.RQInsert oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);
                
                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                oItem.nIdEntidad = oUserInfo.Data.nIdEmpresa;

#if DEBUG
                // PARA PRUEBA
                oItem.nIdEntidad = 1166;
#endif

                var oResult = await this._contratoEsApplication.Insert(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "ContratoEs-Insert", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(ContratoEsDto.RQUpdate oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._contratoEsApplication.Update(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "ContratoEs-Update", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(ContratoEsDto.RQDelete oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                var oResult = await this._contratoEsApplication.Delete(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "ContratoEs-Delete", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }
    }
}