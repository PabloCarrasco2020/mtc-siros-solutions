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
    public class ContratoEsApplication : IContratoEsApplication
    {
        private readonly IContratoEsDomain _contratoEsDomain;
        private readonly IMapper _mapper;

        public ContratoEsApplication(IContratoEsDomain contratoEsDomain, IMapper mapper)
        {
            this._contratoEsDomain = contratoEsDomain;
            this._mapper = mapper;
        }

        public Task<Response<int>> Delete(ContratoEsDto.RQDelete input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<ContratoEsDto.RSGet>> Get(string input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ComboModelDto.XId>>> GetCombo(string input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> Insert(ContratoEsDto.RQInsert input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> Update(ContratoEsDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
