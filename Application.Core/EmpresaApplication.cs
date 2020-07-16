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
    public class EmpresaApplication : IEmpresaApplication
    {
        private readonly IEmpresaDomain _empresaDomain;
        private readonly IMapper _mapper;

        public EmpresaApplication(IEmpresaDomain empresaDomain, IMapper mapper)
        {
            this._empresaDomain = empresaDomain;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Delete(EmpresaDto.RQDelete input)
        {
            try
            {
                var responseDelete = new Response<int>();
                var modelReq = this._mapper.Map<TM_EMPRESA>(input);
                var result = await this._empresaDomain.Delete(modelReq);
                if (result.STR_ESTADOPROCESO == "1")
                {
                    responseDelete.IsSuccess = true;
                    responseDelete.Data = result.NUM_IDEMPRESA;
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

        public async Task<Response<EmpresaDto.RSGet>> Get(string input)
        {
            try
            {
                var responseGet = new Response<EmpresaDto.RSGet>();
                var result = await this._empresaDomain.Get(new TM_EMPRESA { NUM_IDEMPRESA = Int32.Parse(input) });
                if (result == null)
                {
                    responseGet.Message = "No se encontró registro";
                    return responseGet;
                }
                responseGet.IsSuccess = true;
                responseGet.Data = this._mapper.Map<EmpresaDto.RSGet>(result);
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
                var result = await this._empresaDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public async Task<Response<int>> Insert(EmpresaDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_EMPRESA>(input);
                var result = await this._empresaDomain.Insert(modelReq);
                if (result.NUM_IDEMPRESA == -1)
                {
                    responseInsert.Message = result.STR_MENSAJE;
                }
                else if (result.NUM_IDEMPRESA == 0)
                {
                    throw new Exception(result.STR_MENSAJE);
                }
                else
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result.NUM_IDEMPRESA;
                    responseInsert.Message = result.STR_MENSAJE;
                }
                return responseInsert;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<Response<int>> Update(EmpresaDto.RQUpdate input)
        {
            try
            {
                var responseUpdate = new Response<int>();
                var modelReq = this._mapper.Map<TM_EMPRESA>(input);
                var result = await this._empresaDomain.Update(modelReq);
                if (result.STR_ESTADOPROCESO == "1")
                {
                    responseUpdate.IsSuccess = true;
                    responseUpdate.Data = result.NUM_IDEMPRESA;
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
