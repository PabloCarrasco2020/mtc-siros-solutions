using Application.Dto;
using Application.Interface;
using AutoMapper;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class CoordenadaRutaApplication : ICoordenadaRutaApplication
    {
        private readonly ICoordenadaRutaDomain _coordenadaRutaDomain;
        private readonly IMapper _mapper;

        public CoordenadaRutaApplication(ICoordenadaRutaDomain coordenadaRutaDomain, IMapper mapper)
        {
            this._coordenadaRutaDomain = coordenadaRutaDomain;
            this._mapper = mapper;
        }
  
        public Task<Response<int>> Delete(CoordenadaRutaDto.RQDelete input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CoordenadaRutaDto.RSGet>> Get(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                var responseGetAllByFilter = new Response<IndexTableModelDto>();
                var result = await this._coordenadaRutaDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public Task<Response<int>> Insert(CoordenadaRutaDto.RQInsert input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> Update(CoordenadaRutaDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
