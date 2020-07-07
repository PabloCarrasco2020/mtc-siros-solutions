using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunatController : ControllerBase
    {
        private readonly ISunatApplication _sunatApplication;

        public SunatController(ISunatApplication sunatApplication)
        {
            this._sunatApplication = sunatApplication;
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
                // Log
                return Ok(new Response<Object> { Message = "[SUNAT]: ERR-Fallo en el servidor" });
            }
        }
    }
}