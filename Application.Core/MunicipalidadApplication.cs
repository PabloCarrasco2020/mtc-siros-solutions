using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using Transversal.Common;

namespace Application.Core
{
    public class MunicipalidadApplication:IMunicipalidadApplication
    {
        private readonly IMunicipalidadDomain _municipalidadDomain;
        private readonly IMapper _mapper;

        public MunicipalidadApplication(IMunicipalidadDomain municipalidadDomain, IMapper mapper)
        {
            this._municipalidadDomain = municipalidadDomain;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Delete(MunicipalidadDto.RQDelete input)
        {
            try
            {
                var responseDelete = new Response<int>();
                var modelReq = this._mapper.Map<TM_MUNICIPALIDAD>(input);
                var result = await this._municipalidadDomain.Delete(modelReq);
                if (result.STR_ESTADO_PROCESO == "1")
                {
                    responseDelete.IsSuccess = true;
                    responseDelete.Data = result.NUM_IDENTIDAD.Value;
                    responseDelete.Message = result.STR_MENSAJE;
                }
                else if (result.STR_ESTADO_PROCESO == "-1")
                {
                    responseDelete.Message = result.STR_MENSAJE;
                }
                else if (result.STR_ESTADO_PROCESO == "0")
                {
                    throw new Exception(result.STR_MENSAJE);
                }
                return responseDelete;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<MunicipalidadDto.RSGet>> Get(string input)
        {
            try
            {
                var responseGet = new Response<MunicipalidadDto.RSGet>();
                var result = await this._municipalidadDomain.Get(new TM_MUNICIPALIDAD { NUM_IDENTIDAD = Int32.Parse(input) });
                if (result == null)
                {
                    responseGet.Message = "No se encontró registro";
                    return responseGet;
                }
                responseGet.IsSuccess = true;
                responseGet.Data = this._mapper.Map<MunicipalidadDto.RSGet>(result);
                return responseGet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina,int pagina, string filter)
        {
            try
            {
                var responseGetAllByFilter = new Response<IndexTableModelDto>();
                var result = await this._municipalidadDomain.GetAllByFilter(cantidadXPagina,pagina, filter);
                if (result.Count > 0)
                {
                    responseGetAllByFilter.IsSuccess = true;
                    responseGetAllByFilter.Data = new IndexTableModelDto();
                    responseGetAllByFilter.Data.ActualPage = pagina;
                    responseGetAllByFilter.Data.TotalPage = result[0].NUM_PAGINAS;
                    responseGetAllByFilter.Data.NroItems = result[0].NUM_REGISTROS;
                    responseGetAllByFilter.Data.Items = this._mapper.Map<List<TableModel>>(result);
                }
                else
                {
                    responseGetAllByFilter.Message = "No se encontró registros";
                }
                return responseGetAllByFilter;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetCombo(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Insert(MunicipalidadDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_MUNICIPALIDAD>(input);
                var result = await this._municipalidadDomain.Insert(modelReq);
                if(result.NUM_IDENTIDAD == -1)
                {
                    responseInsert.Message = result.STR_MENSAJE;
                }else if(result.NUM_IDENTIDAD == 0){
                    throw new Exception(result.STR_MENSAJE);
                }
                else
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result.NUM_IDENTIDAD.Value;
                    responseInsert.Message = result.STR_MENSAJE;
                }
                return responseInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<int>> Update(MunicipalidadDto.RQUpdate input)
        {
            try
            {
                var responseUpdate = new Response<int>();
                var modelReq = this._mapper.Map<TM_MUNICIPALIDAD>(input);
                var result = await this._municipalidadDomain.Update(modelReq);
                if (result.STR_ESTADO_PROCESO == "1")
                {
                    responseUpdate.IsSuccess = true;
                    responseUpdate.Data = result.NUM_IDENTIDAD.Value;
                    responseUpdate.Message = "Municipalidad ya se encuentra registrada";
                }
                else if (result.STR_ESTADO_PROCESO == "-1")
                {
                    responseUpdate.Message = result.STR_MENSAJE;
                }
                else if(result.STR_ESTADO_PROCESO == "0")
                {
                    throw new Exception(result.STR_MENSAJE);
                }
                return responseUpdate;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
