using System;
using System.Threading.Tasks;
using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;

namespace Domain.Main
{
    public class MunicipalidadDomain:IMunicipalidadDomain
    {
        private readonly IMunicipalidadRepository _municipalidadRepository;

        public MunicipalidadDomain(IMunicipalidadRepository municipalidadRepository)
        {
            this._municipalidadRepository = municipalidadRepository;
        }

        public async Task<TM_MUNICIPALIDAD> Get(TM_MUNICIPALIDAD input)
        {
            try
            {
                return await _municipalidadRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<System.Collections.Generic.List<TM_MUNICIPALIDAD>> GetAllByFilter(int pagina, string filter)
        {
            try
            {
                return await this._municipalidadRepository.GetAllByFilter(pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<System.Collections.Generic.List<TM_MUNICIPALIDAD>> GetCombo(TM_MUNICIPALIDAD input)
        {
            try
            {
                return await this._municipalidadRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<int> Insert(TM_MUNICIPALIDAD input)
        {
            throw new NotImplementedException();
        }

        public Task<int> Update(TM_MUNICIPALIDAD input)
        {
            throw new NotImplementedException();
        }
    }
}
