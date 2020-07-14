using Application.Dto;
using Application.Interface;
using Domain.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class SucursalESApplication : ISucursalESApplication
    {
        private readonly ISucursalESDomain _sucursalESDomain;

        public SucursalESApplication(ISucursalESDomain sucursalESDomain)
        {
            this._sucursalESDomain = sucursalESDomain;
        }
        public Task<Response<int>> Delete(SucursalESDto.RQDelete input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<SucursalESDto.RSGet>> Get(string input)
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

        public Task<Response<int>> Insert(SucursalESDto.RQInsert input)
        {
            throw new NotImplementedException();
        }

        public Task<Response<int>> Update(SucursalESDto.RQUpdate input)
        {
            throw new NotImplementedException();
        }
    }
}
