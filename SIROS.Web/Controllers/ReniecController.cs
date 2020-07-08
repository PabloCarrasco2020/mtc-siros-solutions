using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReniecController : ControllerBase
    {
        private readonly IReniecApplication _reniecApplication;

        public ReniecController(IReniecApplication reniecApplication)
        {
            this._reniecApplication = reniecApplication;
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
                // Log
                return Ok(new Response<Object> { Message = "[RENIEC]: ERR-Fallo en el servidor" });
            }
        }
    }
}