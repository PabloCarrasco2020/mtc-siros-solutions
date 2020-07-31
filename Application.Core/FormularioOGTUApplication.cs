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
    public class FormularioOGTUApplication : IFormularioOGTUApplication
    {
        private readonly IFormularioOGTUDomain _formularioOGTUDomain;
        private readonly IMapper _mapper;

        public FormularioOGTUApplication(IFormularioOGTUDomain formularioOGTUDomain,IMapper mapper)
        {
            this._formularioOGTUDomain = formularioOGTUDomain;
            this._mapper = mapper;
        }
        public async Task<Response<int>> Delete(FormularioOGTUDto.RQDelete input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<FormularioOGTUDto.RSGet>> Get(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<IndexTableModelDto>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<List<ComboModelDto.XId>>> GetCombo(string input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Insert(FormularioOGTUDto.RQInsert input)
        {
            throw new NotImplementedException();
        }

        public async Task<Response<int>> Update(FormularioOGTUDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
