using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Transversal.Common;
using Transversal.Common.Functions;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SunarpController : ControllerBase
    {
        private readonly ISunarpApplication _sunarpApplication;

        public SunarpController(ISunarpApplication sunarpApplication)
        {
            this._sunarpApplication = sunarpApplication;
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
                // Log
                return Ok(new Response<Object> { Message = "[SUNARP]: ERR-Fallo en el servidor" });
            }
        }
    }
}