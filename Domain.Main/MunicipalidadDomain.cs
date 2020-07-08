using System;
using System.Collections.Generic;
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

        public async Task<TM_MUNICIPALIDAD> Delete(TM_MUNICIPALIDAD input)
        {
            try
            {
                return await this._municipalidadRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
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

        
        public async Task<List<TM_MUNICIPALIDAD>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._municipalidadRepository.GetAllByFilter(cantidadXPagina,pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_MUNICIPALIDAD>> GetCombo(TM_MUNICIPALIDAD input)
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

        public async Task<TM_MUNICIPALIDAD> Insert(TM_MUNICIPALIDAD input)
        {
            try
            {
                return await _municipalidadRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_MUNICIPALIDAD> Update(TM_MUNICIPALIDAD input)
        {
            try
            {
                return await _municipalidadRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
