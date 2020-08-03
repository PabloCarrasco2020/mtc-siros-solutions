using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class OperadorESDomain : IOperadorESDomain
    {
        private readonly IOperadorESRepository _operadorESRepository;

        public OperadorESDomain(IOperadorESRepository operadorESRepository)
        {
            this._operadorESRepository = operadorESRepository;
        }
        public async Task<TM_OPERADOR_ES> Delete(TM_OPERADOR_ES input)
        {
            try
            {
                return await this._operadorESRepository.Delete(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_OPERADOR_ES> Get(TM_OPERADOR_ES input)
        {
            try
            {
                return await this._operadorESRepository.Get(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<TM_OPERADOR_ES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._operadorESRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public Task<List<TM_OPERADOR_ES>> GetCombo(TM_OPERADOR_ES input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_OPERADOR_ES> GetXDoc(TM_OPERADOR_ES input)
        {
            try
            {
                return await this._operadorESRepository.GetXDoc(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_OPERADOR_ES> Insert(TM_OPERADOR_ES input)
        {
            try
            {
                return await this._operadorESRepository.Insert(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_OPERADOR_ES> Update(TM_OPERADOR_ES input)
        {
            try
            {
                return await this._operadorESRepository.Update(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
