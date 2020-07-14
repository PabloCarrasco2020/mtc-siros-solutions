using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class ContratoEsDomain : IContratoEsDomain
    {
        private readonly IContratoEsRepository _contratoEsRepository;

        public ContratoEsDomain(IContratoEsRepository contratoEsRepository)
        {
            this._contratoEsRepository = contratoEsRepository;
        }

        public async Task<TM_CONTRATOES> Delete(TM_CONTRATOES input)
        {
            try
            {
                return await this._contratoEsRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_CONTRATOES> Get(TM_CONTRATOES input)
        {
            try
            {
                return await _contratoEsRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<TM_CONTRATOES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._contratoEsRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_CONTRATOES>> GetCombo(TM_CONTRATOES input)
        {
            try
            {
                return await this._contratoEsRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_CONTRATOES> Insert(TM_CONTRATOES input)
        {
            try
            {
                return await _contratoEsRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_CONTRATOES> Update(TM_CONTRATOES input)
        {
            try
            {
                return await _contratoEsRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
