using Domain.Entities;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Infrastructure.Repository
{
    public class OperadorESRepository : IOperadorESRepository
    {
        private readonly IConnectionFactory _connectionFactory;

        public OperadorESRepository(IConnectionFactory connectionFactory)
        {
            this._connectionFactory = connectionFactory;
        }
        public async Task<TM_OPERADOR_ES> Delete(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_OPERADOR_ES> Get(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TM_OPERADOR_ES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            throw new NotImplementedException();
        }

        public Task<List<TM_OPERADOR_ES>> GetCombo(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_OPERADOR_ES> Insert(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_OPERADOR_ES> Update(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }
    }
}
