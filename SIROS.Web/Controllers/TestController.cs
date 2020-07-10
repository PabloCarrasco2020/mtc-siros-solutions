using Application.Interface;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Transversal.Common.Enums;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestController : ControllerBase
    {
        private readonly ILogApplication _logApplication;

        public TestController(ILogApplication logApplication)
        {
            this._logApplication = logApplication;
        }

        [HttpGet("GetLog")]
        public async Task<IActionResult> GetLog()
        {
            try
            {
                int result = int.Parse("1") / int.Parse("0");
                return Ok("Todo OK!");
            }
            catch (Exception ex1)
            {
                try
                {
                    await this._logApplication.SetLogError("TestController-GetLog", ex1);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex1.Message);
                }
                catch (Exception ex2)
                {
                    await this._logApplication.SetLog(EnumLogType.TEXT,EnumLogCategory.ERROR,"TestController-GetLog-EX", ex2);
                    return StatusCode(StatusCodes.Status500InternalServerError, ex2.Message);
                }
            }
        }
    }
}