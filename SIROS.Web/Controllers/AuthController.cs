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
        [HttpGet]
        public async Task<Response<int>> Get()
        {
            

            //string headerToken = this._sSOApplication.AuthMiddleWare().ToString();
            String headerToken = await _sSOApplication.AuthMiddleWare();
            if (string.IsNullOrEmpty(headerToken))
            {
                return new Response<int>();
            }

            var resultModel = await this._sSOApplication.Login(headerToken, "74073994", "SebasCataPad@s3");
            return new Response<int>();
        }

    }
}
