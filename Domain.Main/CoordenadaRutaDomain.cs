using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class CoordenadaRutaDomain: ICoordenadaRutaDomain
    {
        private readonly ICoordenadaRutaRepository _coordenadaRutaRepository;

        public CoordenadaRutaDomain(ICoordenadaRutaRepository coordenadaRutaRepository)
        {
            this._coordenadaRutaRepository = coordenadaRutaRepository;
        }

        public Task<TM_COORDENADA_RUTA> Delete(TM_COORDENADA_RUTA input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COORDENADA_RUTA> Get(TM_COORDENADA_RUTA input)
        {
            throw new NotImplementedException();
        }

        public async Task<List<TM_COORDENADA_RUTA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._coordenadaRutaRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public Task<List<TM_COORDENADA_RUTA>> GetCombo(TM_COORDENADA_RUTA input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COORDENADA_RUTA> Insert(TM_COORDENADA_RUTA input)
        {
            throw new NotImplementedException();
        }

        public Task<TM_COORDENADA_RUTA> Update(TM_COORDENADA_RUTA input)
        {
            throw new NotImplementedException();
        }
    }
}
