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
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaApplication _empresaApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public EmpresaController(
            IEmpresaApplication empresaApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._empresaApplication = empresaApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string sInput)
        {
            try
            {
                var oResult = await this._empresaApplication.Get(sInput);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Empresa-Get", ex, sInput);
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
                var oResult = await this._empresaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Empresa-GetAllByFilter", ex, nPagina, sFilter);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(EmpresaDto.RQInsert oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                oItem.nIdEntidadSSO = oUserInfo.Data.nIdEmpresa;

#if DEBUG
                // PARA PRUEBA
                // oItem.nIdEntidadSSO = 1166;
#endif

                var oResult = await this._empresaApplication.Insert(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Empresa-Insert", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(EmpresaDto.RQUpdate oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                oItem.nIdEntidadSSO = oUserInfo.Data.nIdEmpresa;
                var oResult = await this._empresaApplication.Update(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Empresa-Update", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(EmpresaDto.RQDelete oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                oItem.nIdEntidadSSO = oUserInfo.Data.nIdEmpresa;
                var oResult = await this._empresaApplication.Delete(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Empresa-Delete", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }
    }
}