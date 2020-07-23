using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OngeiController : ControllerBase
    {
        private readonly IOngeiApplication _ongeiApplication;
        private readonly ILogApplication _logApplication;

        public OngeiController(IOngeiApplication ongeiApplication, ILogApplication logApplication)
        {
            this._ongeiApplication = ongeiApplication;
            this._logApplication = logApplication;
        }

        [HttpGet("ConsultaCarnetExt")]
        public async Task<IActionResult> ConsultaCarnetExt(string sNumDoc)
        {
            try
            {
                var oResponse = await this._ongeiApplication.ConsultaCarnetExt(sNumDoc);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "ONGEI-ConsultaCarnetExt", ex, sNumDoc);
                return Ok(new Response<Object> { Message = $"[ONGEI]: ERR-Fallo en el servidor" });
            }
        }
    }
}