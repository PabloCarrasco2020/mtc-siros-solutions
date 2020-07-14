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
    public class ReniecController : ControllerBase
    {
        private readonly IReniecApplication _reniecApplication;
        private readonly ILogApplication _logApplication;
        private readonly IJwtApplication _jwtApplication;

        public ReniecController(IReniecApplication reniecApplication, ILogApplication logApplication, IJwtApplication jwtApplication)
        {
            this._reniecApplication = reniecApplication;
            this._logApplication = logApplication;
            this._jwtApplication = jwtApplication;
        }

        [HttpGet("ConsultaNumDoc")]
        public async Task<IActionResult> ConsultaNumDoc(string sNumDoc)
        {
            try
            {
                var oResponse = await this._reniecApplication.ConsultaNumDoc(sNumDoc);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLog(EnumLogType.TEXT_N_EMAIL, EnumLogCategory.ERROR, "Reniec-ConsultaNumDoc", ex, sNumDoc);
                return Ok(new Response<Object> { Message = "[RENIEC]: ERR-Fallo en el servidor" });
            }
        }
    }
}