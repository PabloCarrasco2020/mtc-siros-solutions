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
                //var oUserInfo = await this._jwtApplication.GetUserInfo(User);
                //if (oUserInfo.IsSuccess)
                //{
                //    //SI ES SUCCESS YA TIENES LA DATA
                //    Console.WriteLine($"Usuario Conectado: {oUserInfo.Data.sUsername}");
                //}

                //int x = int.Parse("1") / int.Parse("0"); //FORZAR ERROR PARA TEST LOG

                var oResponse = await this._reniecApplication.ConsultaNumDoc(sNumDoc);
                return Ok(oResponse);
            }
            catch (Exception ex)
            {
                _ = this._logApplication.SetLogError("ReniecController-ConsultaNumDoc", ex);
                return Ok(new Response<Object> { Message = "[RENIEC]: ERR-Fallo en el servidor" });
            }
        }
    }
}