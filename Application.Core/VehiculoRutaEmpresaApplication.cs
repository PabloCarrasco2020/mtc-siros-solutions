using Application.Dto;
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
    public class VehiculoRutaEmpresaApplication : IVehiculoRutaEmpresaApplication
    {
        private readonly IVehiculoRutaEmpresaDomain _vehiculoRutaEmpresaDomain;
        private readonly IMapper _mapper;

        public VehiculoRutaEmpresaApplication(IVehiculoRutaEmpresaDomain vehiculoRutaEmpresaDomain, IMapper mapper)
        {
            this._vehiculoRutaEmpresaDomain = vehiculoRutaEmpresaDomain;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Delete(VehiculoRutaEmpresaDto.RQDelete input)
        {
            try
            {
                var responseDelete = new Response<int>();
                var modelReq = this._mapper.Map<TM_VEHICULO_RUTA_EMPRESA>(input);
                var result = await this._vehiculoRutaEmpresaDomain.Delete(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseDelete.IsSuccess = true;
                    responseDelete.Data = result.NUM_VEHXEMP.Value;
                    responseDelete.Message = result.STR_MENSAJE;
                }
                else if (nestadoProceso > 1)
                {
                    responseDelete.Message = result.STR_MENSAJE;
                }
                else if (nestadoProceso == 0)
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

        public async Task<Response<VehiculoRutaEmpresaDto.RSGet>> Get(string input)
        {
            try
            {
                var responseGet = new Response<VehiculoRutaEmpresaDto.RSGet>();
                var result = await this._vehiculoRutaEmpresaDomain.Get(new TM_VEHICULO_RUTA_EMPRESA { NUM_VEHXEMP = Int32.Parse(input) });
                if (result == null)
                {
                    responseGet.Message = "No se encontró registro";
                    return responseGet;
                }
                responseGet.IsSuccess = true;
                responseGet.Data = this._mapper.Map<VehiculoRutaEmpresaDto.RSGet>(result);
                return responseGet;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                var responseGetAllByFilter = new Response<IndexTableModelDto>();
                var result = await this._vehiculoRutaEmpresaDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public Task<Response<List<ComboModelDto.XId>>> GetCombo(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Insert(VehiculoRutaEmpresaDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_VEHICULO_RUTA_EMPRESA>(input);
                var result = await this._vehiculoRutaEmpresaDomain.Insert(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result.NUM_VEHXEMP.Value;
                    responseInsert.Message = result.STR_MENSAJE;
                }
                else if (nestadoProceso > 1)
                {
                    responseInsert.Message = result.STR_MENSAJE;
                }
                else if (nestadoProceso == 0)
                {
                    throw new Exception(result.STR_MENSAJE);
                }
                return responseInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<int>> Update(VehiculoRutaEmpresaDto.RQUpdate input)
        {
            try
            {
                var responseUpdate = new Response<int>();
                var modelReq = this._mapper.Map<TM_VEHICULO_RUTA_EMPRESA>(input);
                var result = await this._vehiculoRutaEmpresaDomain.Update(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseUpdate.IsSuccess = true;
                    responseUpdate.Data = result.NUM_VEHXEMP.Value;
                    responseUpdate.Message = result.STR_MENSAJE;
                }
                else if (nestadoProceso > 1)
                {
                    responseUpdate.Message = result.STR_MENSAJE;
                }
                else if (nestadoProceso == 0)
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
