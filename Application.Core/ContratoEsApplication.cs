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
    public class ContratoEsApplication : IContratoEsApplication
    {
        private readonly IContratoEsDomain _contratoEsDomain;
        private readonly IMapper _mapper;

        public ContratoEsApplication(IContratoEsDomain contratoEsDomain, IMapper mapper)
        {
            this._contratoEsDomain = contratoEsDomain;
            this._mapper = mapper;
        }

        public async Task<Response<int>> Delete(ContratoEsDto.RQDelete input)
        {
            try
            {
                var responseDelete = new Response<int>();
                var modelReq = this._mapper.Map<TM_CONTRATOES>(input);
                var result = await this._contratoEsDomain.Delete(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseDelete.IsSuccess = true;
                    responseDelete.Data = result.NUM_IDESTSERVICIOXENT.Value;
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

        public async Task<Response<ContratoEsDto.RSGet>> Get(string input)
        {
            try
            {
                var responseGet = new Response<ContratoEsDto.RSGet>();
                var result = await this._contratoEsDomain.Get(new TM_CONTRATOES { NUM_IDESTSERVICIOXENT = Int32.Parse(input) });
                if (result == null)
                {
                    responseGet.Message = "No se encontró registro";
                    return responseGet;
                }
                responseGet.IsSuccess = true;
                responseGet.Data = this._mapper.Map<ContratoEsDto.RSGet>(result);
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
                var result = await this._contratoEsDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public async Task<Response<int>> Insert(ContratoEsDto.RQInsert input)
        {
            try
            {
                var responseInsert = new Response<int>();
                var modelReq = this._mapper.Map<TM_CONTRATOES>(input);
                var result = await this._contratoEsDomain.Insert(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseInsert.IsSuccess = true;
                    responseInsert.Data = result.NUM_IDESTSERVICIOXENT.Value;
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

        public async Task<Response<int>> Update(ContratoEsDto.RQUpdate input)
        {
            try
            {
                var responseUpdate = new Response<int>();
                var modelReq = this._mapper.Map<TM_CONTRATOES>(input);
                var result = await this._contratoEsDomain.Update(modelReq);
                var nestadoProceso = Int32.Parse(result.STR_ESTADOPROCESO);
                if (nestadoProceso == 1)
                {
                    responseUpdate.IsSuccess = true;
                    responseUpdate.Data = result.NUM_IDESTSERVICIOXENT.Value;
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
