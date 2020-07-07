﻿using System;
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
    [Route("api/[Controller]/[Action]")]
    public class MunicipalidadController : Controller
    {
        private readonly IMunicipalidadApplication _municipalidadApplication;

        public MunicipalidadController(IMunicipalidadApplication municipalidadApplication)
        {
            this._municipalidadApplication = municipalidadApplication;
        }
        [HttpGet]
        public async Task<Response<MunicipalidadDto.RSGet>> Get(string input)
        {
            try
            {
                return await _municipalidadApplication.Get(input);
            }
            catch (Exception ex)
            {
                // Log
                return new Response<MunicipalidadDto.RSGet>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int pagina,string filter)
        {
            try
            {
                return await _municipalidadApplication.GetAllByFilter(pagina,filter);
            }
            catch (Exception ex)
            {
                // Log
                return new Response<IndexTableModelDto>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpPost]
        public async Task<Response<int>> Insert([FromBody]MunicipalidadDto.RQInsert input)
        {
            try
            {
                input.nIdSession = 333;
                input.sUsuario = "SIROS_WEB";
                return await _municipalidadApplication.Insert(input);
            }
            catch (Exception ex)
            {
                // Log
                return new Response<int>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }

    }
}
