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
    public class VehiculoRutaEmpresaController : ControllerBase
    {
        private readonly IVehiculoRutaEmpresaApplication _vehiculoRutaEmpresaApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public VehiculoRutaEmpresaController(
            IVehiculoRutaEmpresaApplication vehiculoRutaEmpresaApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._vehiculoRutaEmpresaApplication = vehiculoRutaEmpresaApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string sInput)
        {
            try
            {
                var oResult = await this._vehiculoRutaEmpresaApplication.Get(sInput);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "VehiculoRutaEmpresa-Get", ex, sInput);
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
                var oResult = await this._vehiculoRutaEmpresaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "VehiculoRutaEmpresa-GetAllByFilter", ex, nPagina, sFilter);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(VehiculoRutaEmpresaDto.RQInsert oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;

                var oResult = await this._vehiculoRutaEmpresaApplication.Insert(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "VehiculoRutaEmpresa-Insert", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(VehiculoRutaEmpresaDto.RQUpdate oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._vehiculoRutaEmpresaApplication.Update(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "VehiculoRutaEmpresa-Update", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(VehiculoRutaEmpresaDto.RQDelete oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._vehiculoRutaEmpresaApplication.Delete(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "VehiculoRutaEmpresa-Delete", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }
    }
}