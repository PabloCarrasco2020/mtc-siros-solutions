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
    public class OperadorEmpresaController : ControllerBase
    {
        private readonly IOperadorEmpresaApplication _operadorEmpresaApplication;
        private readonly IReniecApplication _reniecApplication;
        private readonly IOngeiApplication _ongeiApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public OperadorEmpresaController(
            IOperadorEmpresaApplication operadorEmpresaApplication,
            IOngeiApplication ongeiApplication,
            IReniecApplication reniecApplication,
            ILogApplication logApplication,
            IJwtApplication jwtApplication)
        {
            this._operadorEmpresaApplication = operadorEmpresaApplication;
            this._reniecApplication = reniecApplication;
            this._ongeiApplication = ongeiApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet("Get")]
        public async Task<IActionResult> Get(string sInput)
        {
            try
            {
                var oResult = await this._operadorEmpresaApplication.Get(sInput);
                if (!oResult.IsSuccess)
                    return Ok(oResult);
                
                if (oResult.Data.nIdTpDocumento.Value == (int)EnumTipoDocumento.DNI)
                {
                    var oResultReniec = await this._reniecApplication.ConsultaNumDoc(oResult.Data.sNroDocumento);
                    if (oResultReniec.IsSuccess)
                    {
                        oResult.Data.sFoto = oResultReniec.Data.sFoto;
                    }
                }
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorEmpresa-Get", ex, sInput);
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
                var oResult = await this._operadorEmpresaApplication.GetAllByFilter(nCantidadXPagina, nPagina, sFilter);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorEmpresa-GetAllByFilter", ex, nPagina, sFilter);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Insert")]
        public async Task<IActionResult> Insert(OperadorEmpresaDto.RQInsert oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                oItem.sFoto = "";

                var oResult = await this._operadorEmpresaApplication.Insert(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorEmpresa-Insert", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(OperadorEmpresaDto.RQUpdate oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._operadorEmpresaApplication.Update(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorEmpresa-Update", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }

        [HttpPost("Delete")]
        public async Task<IActionResult> Delete(OperadorEmpresaDto.RQDelete oItem)
        {
            try
            {
                var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                if (!oUserInfo.IsSuccess)
                    return Ok(oUserInfo);

                oItem.nIdSession = int.Parse(oUserInfo.Data.sIdSession);
                oItem.sUsuario = oUserInfo.Data.sUsername;
                var oResult = await this._operadorEmpresaApplication.Delete(oItem);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "OperadorEmpresa-Delete", ex, oItem);
                return Ok(new Response<string> { Message = "ERR-Fallo en el servidor" });
            }
        }
    }
}