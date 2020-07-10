﻿using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Entities;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class EstacionServicioApplication : IEstacionServicioApplication
    {
        private readonly IEstacionServicioDomain _estacionServicioDomain;
        private readonly IMapper _mapper;

        public EstacionServicioApplication(IEstacionServicioDomain estacionServicioDomain,IMapper mapper)
        {
            this._estacionServicioDomain = estacionServicioDomain;
            this._mapper = mapper;
        }
        public async Task<Response<int>> Delete(EstacionServicioDto.RQDelete input)
        {
            try
            {
                var responseDelete = new Response<int>();
                var modelReq = this._mapper.Map<TM_ESTACIONSERVICIO>(input);
                var result = await this._estacionServicioDomain.Delete(modelReq);
                if (result.STR_ESTADOPROCESO == "1")
                {
                    responseDelete.IsSuccess = true;
                    responseDelete.Data = result.NUM_IDESTSERVICIO.Value;
                    responseDelete.Message = result.STR_MENSAJE;
                }
                else if (result.STR_ESTADOPROCESO == "-1")
                {
                    responseDelete.Message = result.STR_MENSAJE;
                }
                else if (result.STR_ESTADOPROCESO == "0")
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

        public async Task<Response<EstacionServicioDto.RSGet>> Get(string input)
        {
            try
            {
                var responseGet = new Response<EstacionServicioDto.RSGet>();
                var result = await this._estacionServicioDomain.Get(new TM_ESTACIONSERVICIO { NUM_IDESTSERVICIO = Int32.Parse(input) });
                if (result == null)
                {
                    responseGet.Message = "No se encontró registro";
                    return responseGet;
                }
                responseGet.IsSuccess = true;
                responseGet.Data = this._mapper.Map<EstacionServicioDto.RSGet>(result);
                return responseGet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                var responseGetAllByFilter = new Response<IndexTableModelDto>();
                var result = await this._estacionServicioDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public async Task<Response<int>> Insert(EstacionServicioDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_ESTACIONSERVICIO>(input);
                var result = await this._estacionServicioDomain.Insert(modelReq);
                if (result.NUM_IDESTSERVICIO == -1)
                {
                    responseInsert.Message = result.STR_MENSAJE;
                }
                else if (result.NUM_IDESTSERVICIO == 0)
                {
                    throw new Exception(result.STR_MENSAJE);
                }
                else
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result.NUM_IDESTSERVICIO.Value;
                    responseInsert.Message = result.STR_MENSAJE;
                }
                return responseInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<int>> Update(EstacionServicioDto.RQUpdate input)
        {
            try
            {
                var responseUpdate = new Response<int>();
                var modelReq = this._mapper.Map<TM_ESTACIONSERVICIO>(input);
                var result = await this._estacionServicioDomain.Update(modelReq);
                if (result.STR_ESTADOPROCESO == "1")
                {
                    responseUpdate.IsSuccess = true;
                    responseUpdate.Data = result.NUM_IDESTSERVICIO.Value;
                    responseUpdate.Message = result.STR_MENSAJE;
                }
                else if (result.STR_ESTADOPROCESO == "-1")
                {
                    responseUpdate.Message = result.STR_MENSAJE;
                }
                else if (result.STR_ESTADOPROCESO == "0")
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