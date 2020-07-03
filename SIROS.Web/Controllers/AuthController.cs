using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class AuthController : Controller
    {
        private readonly ISSOApplication _sSOApplication;

        public AuthController(ISSOApplication sSOApplication)
        {
            this._sSOApplication = sSOApplication;
        }
        // GET: api/values
        [HttpPost]
        public async Task<Response<int>> Login(CredencialModel input)
        {
            var responseLogin = new Response<int>();
            try
            {
                if (1 == 1)
                {
                    responseLogin.IsSuccess = true;
                    responseLogin.Data = 2;
                    return responseLogin;
                }
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
                return responseLogin;
            }
            catch (Exception ex)
            {
                // log
                responseLogin.Message = "ERR-Error en el servidor";
                return responseLogin;
            }
            



        }
        public class CredencialModel
        {
            public string Usuario { get; set; }
            public string Credencial { get; set; }
        }
    }
}
