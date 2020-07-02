using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.AspNetCore.Mvc;
using Transversal.Common;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SIROS.Web.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ComboController : Controller
    {
        private readonly IMunicipalidadApplication _municipalidadApplication;

        public ComboController(IMunicipalidadApplication municipalidadApplication)
        {
            this._municipalidadApplication = municipalidadApplication;
        }
        
        [HttpGet]
        public async Task<Response<List<ComboModelDto>>> GetMunicipalidades()
        {
            try
            {
                return await _municipalidadApplication.GetCombo(null);
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
       
    }
}
