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
    [Route("api/[Controller]/[Action]")]
    public class ComboController : Controller
    {
        private readonly IMunicipalidadApplication _municipalidadApplication;
        private readonly IGeneralApplication _generalApplication;

        public ComboController(IMunicipalidadApplication municipalidadApplication, IGeneralApplication generalApplication)
        {
            this._municipalidadApplication = municipalidadApplication;
            this._generalApplication = generalApplication;
        }
        #region Ubigeo
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XCodigo>>> GetDepartamento()
        {
            try
            {
                return await this._generalApplication.GetDepartamento();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XCodigo>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XCodigo>>> GetProvincia(string sCodDepartamento)
        {
            try
            {
                return await this._generalApplication.GetProvincia(sCodDepartamento);
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XCodigo>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XCodigo>>> GetDistrito(string sCodDepartamento, string sCodProvincia)
        {
            try
            {
                return await this._generalApplication.GetDistrito(sCodDepartamento, sCodProvincia);
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XCodigo>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        #endregion

        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoVia()
        {
            try
            {
                return await this._generalApplication.GetTipoVia();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetCentroPoblado()
        {
            try
            {
                return await this._generalApplication.GetCentroPoblado();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetNumeroManzana()
        {
            try
            {
                return await this._generalApplication.GetNumeroManzana();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetLoteInterior()
        {
            try
            {
                return await this._generalApplication.GetLoteInterior();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoDocRepresentanteLegal()
        {
            try
            {
                return await this._generalApplication.GetTipoDocRepresentanteLegal();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
        [HttpGet]
        public async Task<Response<List<ComboModelDto.XId>>> GetCargoRepresentanteLegal()
        {
            try
            {
                return await this._generalApplication.GetCargoRepresentanteLegal();
            }
            catch (Exception ex)
            {
                // Log
                return new Response<List<ComboModelDto.XId>>
                {
                    Message = "ERR-Fallo en el servidor"
                };
            }
        }
    }
}
