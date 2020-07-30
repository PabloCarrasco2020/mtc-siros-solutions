using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class SucursalESDomain : ISucursalESDomain
    {
        private readonly ISucursalESRepository _sucursalESRepository;

        public SucursalESDomain(ISucursalESRepository sucursalESRepository)
        {
            this._sucursalESRepository = sucursalESRepository;
        }
        public async Task<TM_SUCURSAL_ES> Delete(TM_SUCURSAL_ES input)
        {
            try
            {
                return await this._sucursalESRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_SUCURSAL_ES> Get(TM_SUCURSAL_ES input)
        {
            try
            {
                return await this._sucursalESRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_SUCURSAL_ES>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._sucursalESRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_SUCURSAL_ES>> GetCombo(TM_SUCURSAL_ES input)
        {
            try
            {
                return await this._sucursalESRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_SUCURSAL_ES> Insert(TM_SUCURSAL_ES input)
        {
            try
            {
                return await this._sucursalESRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_SUCURSAL_ES> Update(TM_SUCURSAL_ES input)
        {
            try
            {
                return await this._sucursalESRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
