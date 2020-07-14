using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class CombustibleDomain : ICombustibleDomain
    {
        private readonly ICombustibleRepository _combustibleRepository;

        public CombustibleDomain(ICombustibleRepository combustibleRepository)
        {
            this._combustibleRepository = combustibleRepository;
        }

        public Task<TM_COMBUSTIBLE> Delete(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COMBUSTIBLE> Get(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TM_COMBUSTIBLE>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._combustibleRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TM_COMBUSTIBLE>> GetCombo(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COMBUSTIBLE> Insert(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COMBUSTIBLE> Update(TM_COMBUSTIBLE input)
        {
            throw new NotImplementedException();
        }
    }
}
