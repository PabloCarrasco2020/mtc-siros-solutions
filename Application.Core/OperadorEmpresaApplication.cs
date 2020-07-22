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
    public class OperadorEmpresaApplication : IOperadorEmpresaApplication
    {
        private readonly IOperadorEmpresaDomain _operadorEmpresaDomain;
        private readonly IMapper _mapper;

        public OperadorEmpresaApplication(IOperadorEmpresaDomain operadorEmpresaDomain, IMapper mapper)
        {
            this._operadorEmpresaDomain = operadorEmpresaDomain;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Delete(OperadorEmpresaDto.RQDelete input)
        {
            try
            {
                var responseDelete = new Response<int>();
                var modelReq = this._mapper.Map<TM_OPERADOR_EMPRESA>(input);
                var result = await this._operadorEmpresaDomain.Delete(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseDelete.IsSuccess = true;
                    responseDelete.Data = result.NUM_IDNOMINAXEMP.Value;
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

        public async Task<Response<OperadorEmpresaDto.RSGet>> Get(string input)
        {
            try
            {
                var responseGet = new Response<OperadorEmpresaDto.RSGet>();
                var result = await this._operadorEmpresaDomain.Get(new TM_OPERADOR_EMPRESA { NUM_IDNOMINAXEMP = Int32.Parse(input) });
                if (result == null)
                {
                    responseGet.Message = "No se encontró registro";
                    return responseGet;
                }
                responseGet.IsSuccess = true;
                responseGet.Data = this._mapper.Map<OperadorEmpresaDto.RSGet>(result);
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
                var result = await this._operadorEmpresaDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public async Task<Response<int>> Insert(OperadorEmpresaDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_OPERADOR_EMPRESA>(input);
                var result = await this._operadorEmpresaDomain.Insert(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result.NUM_IDNOMINAXEMP.Value;
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

        public async Task<Response<int>> Update(OperadorEmpresaDto.RQUpdate input)
        {
            try
            {
                var responseUpdate = new Response<int>();
                var modelReq = this._mapper.Map<TM_OPERADOR_EMPRESA>(input);
                var result = await this._operadorEmpresaDomain.Update(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseUpdate.IsSuccess = true;
                    responseUpdate.Data = result.NUM_IDNOMINAXEMP.Value;
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
