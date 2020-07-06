using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunatController : ControllerBase
    {
        [HttpGet("ConsultaRuc")]
        public async Task<IActionResult> ConsultaRuc(string sRuc)
        {
            try
            {
                var wsSunat = new wsSoapSUNAT.DatosRucWSFacadeRemoteClient();
                var oResult = await wsSunat.getDatosPrincipalesAsync(sRuc);
                return Ok(oResult);
            }
            catch (Exception ex)
            {
                // Log
                return Ok(new Response<Object> { Message = "[SUNAT]: ERR-Fallo en el servidor" });
            }
        }
    }
}