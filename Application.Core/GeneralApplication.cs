using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class GeneralApplication : IGeneralApplication
    {
        private readonly IGeneralDomain _generalDomain;
        private readonly IMapper _mapper;

        public GeneralApplication(IGeneralDomain generalDomain, IMapper mapper)
        {
            this._generalDomain = generalDomain;
            this._mapper = mapper;
        }
        public async Task<Response<List<ComboModelDto.XId>>> GetCargoRepresentanteLegal()
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetCargoRepresentanteLegal();
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetCentroPoblado()
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetCentroPoblado();
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XCodigo>>> GetDepartamento()
        {
            try
            {
                var response = new Response<List<ComboModelDto.XCodigo>>();
                var result = await this._generalDomain.GetDepartamento();
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XCodigo>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XCodigo>>> GetDistrito(string sCodDepartamento, string sCodProvincia)
        {
            try
            {
                var response = new Response<List<ComboModelDto.XCodigo>>();
                var result = await this._generalDomain.GetDistrito(sCodDepartamento,sCodProvincia);
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XCodigo>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetLoteInterior()
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetLoteInterior();
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetNumeroManzana()
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetNumeroManzana();
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XCodigo>>> GetProvincia(string sCodDepartamento)
        {
            try
            {
                var response = new Response<List<ComboModelDto.XCodigo>>();
                var result = await this._generalDomain.GetProvincia(sCodDepartamento);
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XCodigo>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetTipoDoc(string sTipoConsulta)
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetTipoDoc(sTipoConsulta);
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoOperador(string sTipoConsulta)
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetTipoOperador(sTipoConsulta);
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public async Task<Response<List<ComboModelDto.XId>>> GetTipoVia()
        {
            try
            {
                var response = new Response<List<ComboModelDto.XId>>();
                var result = await this._generalDomain.GetTipoVia();
                if (result.Count > 0)
                {
                    response.IsSuccess = true;
                    response.Data = this._mapper.Map<List<ComboModelDto.XId>>(result);
                }
                else
                {
                    response.Message = "0 Registros encontrados";
                }
                return response;
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
