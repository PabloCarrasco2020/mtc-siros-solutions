using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SSOController : ControllerBase
    {
        private readonly ISSOApplication _sSOApplication;

        public SSOController(ISSOApplication sSOApplication)
        {
            this._sSOApplication = sSOApplication;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(SSODto.Login.RequestModel oItem)
        {
            try
            {
                var oResult = await this._sSOApplication.Login(oItem);
                return Ok(oResult);

                /*
                //string headerToken = this._sSOApplication.AuthMiddleWare().ToString();
                string headerToken = await _sSOApplication.AuthMiddleWare();
                if (string.IsNullOrEmpty(headerToken))
                {
                    responseLogin.Message = "No se generó token";
                    return responseLogin;
                }

                //var resultModel = await this._sSOApplication.Login(headerToken, "74073994", "SebasCataPad@s3");
                //Obteniendo Id
                var resultLoginSSO= await this._sSOApplication.Login(
                    headerToken,
                    input.Usuario,//"41403114",
                    input.Credencial//"123456"
                    );
                if (!resultLoginSSO.IsSuccess)
                {
                    responseLogin.Message = resultLoginSSO.Message;
                    return resultLoginSSO;
                }
                // Reniec

                responseLogin.IsSuccess = true;
                responseLogin.Data = 1;
                return responseLogin;*/
            }
            catch (Exception ex)
            {
                // log
                return Ok(new Response<Object> { Message = "[SSO]: ERR-Fallo en el servidor" });
            }
        }
    }
}
