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
    public class OperadorESApplication : IOperadorESApplication
    {
        private readonly IOperadorESDomain _operadorESDomain;
        private readonly IMapper _mapper;

        public OperadorESApplication(IOperadorESDomain operadorESDomain, IMapper mapper)
        {
            this._operadorESDomain = operadorESDomain;
            this._mapper = mapper;
        }
        public async Task<Response<int>> Delete(OperadorESDto.RQDelete input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<OperadorESDto.RSGet>> Get(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<Response<List<ComboModelDto.XId>>> GetCombo(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Insert(OperadorESDto.RQInsert input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Update(OperadorESDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
