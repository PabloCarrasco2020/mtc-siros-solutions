using System;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SunarpController : ControllerBase
    {
        private readonly ISunarpApplication _sunarpApplication;
        private readonly ILogApplication _logApplication;

        public SunarpController(ISunarpApplication sunarpApplication, ILogApplication logApplication)
        {
            this._sunarpApplication = sunarpApplication;
            this._logApplication = logApplication;
        }

        [HttpGet("ConsultaPlaca")]
        public async Task<IActionResult> ConsultaPlaca(string sPlaca)
        {
            try
            {
                var oResponse = await this._sunarpApplication.ConsultaPlaca(sPlaca);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Sunarp-ConsultaPlaca", ex, sPlaca);
                return Ok(new Response<Object> { Message = "[SUNARP]: ERR-Fallo en el servidor" });
            }
        }
    }
}