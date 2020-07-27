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
    public class RutaEmpresaController : ControllerBase
    {
        private readonly IRutaEmpresaApplication _rutaEmpresaApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public RutaEmpresaController(
            IRutaEmpresaApplication rutaEmpresaApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._rutaEmpresaApplication = rutaEmpresaApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string sInput)
        {
            try
            {
                var oResult = await this._rutaEmpresaApplication.Get(sInput);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaEmpresa-Get", ex, sInput);
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
                var oResult = await this._rutaEmpresaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaEmpresa-GetAllByFilter", ex, nPagina, sFilter);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(RutaEmpresaDto.RQInsert oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;

                var oResult = await this._rutaEmpresaApplication.Insert(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaEmpresa-Insert", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(RutaEmpresaDto.RQUpdate oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._rutaEmpresaApplication.Update(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaEmpresa-Update", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(RutaEmpresaDto.RQDelete oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._rutaEmpresaApplication.Delete(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "RutaEmpresa-Delete", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }
    }
}