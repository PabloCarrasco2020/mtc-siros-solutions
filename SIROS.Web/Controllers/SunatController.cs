using System;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

namespace SIROS.Web.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class SunatController : ControllerBase
    {
        private readonly ISunatApplication _sunatApplication;
        private readonly ILogApplication _logApplication;

        public SunatController(ISunatApplication sunatApplication, ILogApplication logApplication)
        {
            this._sunatApplication = sunatApplication;
            this._logApplication = logApplication;
        }

        [HttpGet("ConsultaRuc")]
        public async Task<IActionResult> ConsultaRuc(string sRuc)
        {
            try
            {
                var oResponse = await this._sunatApplication.ConsultaRuc(sRuc);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("SunatController-ConsultaRuc", ex);
                return Ok(new Response<Object> { Message = $"[SUNAT]: ERR-Fallo en el servidor" });
            }
        }
    }
}