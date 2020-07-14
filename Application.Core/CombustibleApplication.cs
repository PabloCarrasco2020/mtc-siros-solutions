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
    public class CombustibleApplication : ICombustibleApplication
    {
        private readonly ICombustibleDomain _combustibleDomain;
        private readonly IMapper _mapper;

        public CombustibleApplication(ICombustibleDomain combustibleDomain, IMapper mapper)
        {
            this._combustibleDomain = combustibleDomain;
            this._mapper = mapper;
        }
        public Task<Response<int>> Delete(CombustibleDto.RQDelete input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<CombustibleDto.RSGet>> Get(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                var responseGetAllByFilter = new Response<IndexTableModelDto>();
                var result = await this._combustibleDomain.GetAllByFilter(cantidadXPagina, pagina, filter);
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

        public Task<Response<int>> Insert(CombustibleDto.RQInsert input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> Update(CombustibleDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
