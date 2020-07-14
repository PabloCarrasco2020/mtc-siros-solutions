using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class EstacionServicioDomain : IEstacionServicioDomain
    {
        private readonly IEstacionServicioRepository _estacionServicioRepository;

        public EstacionServicioDomain(IEstacionServicioRepository estacionServicioRepository)
        {
            this._estacionServicioRepository = estacionServicioRepository;
        }
        public async Task<TM_ESTACIONSERVICIO> Delete(TM_ESTACIONSERVICIO input)
        {
            try
            {
                return await this._estacionServicioRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_ESTACIONSERVICIO> Get(TM_ESTACIONSERVICIO input)
        {
            try
            {
                return await this._estacionServicioRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_ESTACIONSERVICIO>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._estacionServicioRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_ESTACIONSERVICIO>> GetCombo(TM_ESTACIONSERVICIO input)
        {
            try
            {
                return await this._estacionServicioRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_ESTACIONSERVICIO> Insert(TM_ESTACIONSERVICIO input)
        {
            try
            {
                return await this._estacionServicioRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_ESTACIONSERVICIO> Update(TM_ESTACIONSERVICIO input)
        {
            try
            {
                return await this._estacionServicioRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
