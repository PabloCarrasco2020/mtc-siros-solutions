using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class RutaDomain : IRutaDomain
    {
        private readonly IRutaRepository _rutaRepository;

        public RutaDomain(IRutaRepository rutaRepository)
        {
            this._rutaRepository = rutaRepository;
        }

        public async Task<TM_RUTA> Delete(TM_RUTA input)
        {
            try
            {
                return await this._rutaRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_RUTA> Get(TM_RUTA input)
        {
            try
            {
                return await this._rutaRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_RUTA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._rutaRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TM_RUTA>> GetCombo(TM_RUTA input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_RUTA> Insert(TM_RUTA input)
        {
            try
            {
                return await this._rutaRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_RUTA> Update(TM_RUTA input)
        {
            try
            {
                return await this._rutaRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
