using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class VehiculoRutaEmpresaDomain : IVehiculoRutaEmpresaDomain
    {
        private readonly IVehiculoRutaEmpresaRepository _vehiculoRutaEmpresaRepository;

        public VehiculoRutaEmpresaDomain(IVehiculoRutaEmpresaRepository vehiculoRutaEmpresaRepository)
        {
            this._vehiculoRutaEmpresaRepository = vehiculoRutaEmpresaRepository;
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Delete(TM_VEHICULO_RUTA_EMPRESA input)
        {
            try
            {
                return await this._vehiculoRutaEmpresaRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Get(TM_VEHICULO_RUTA_EMPRESA input)
        {
            try
            {
                return await _vehiculoRutaEmpresaRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<TM_VEHICULO_RUTA_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._vehiculoRutaEmpresaRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_VEHICULO_RUTA_EMPRESA>> GetCombo(TM_VEHICULO_RUTA_EMPRESA input)
        {
            try
            {
                return await this._vehiculoRutaEmpresaRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Insert(TM_VEHICULO_RUTA_EMPRESA input)
        {
            try
            {
                return await _vehiculoRutaEmpresaRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_VEHICULO_RUTA_EMPRESA> Update(TM_VEHICULO_RUTA_EMPRESA input)
        {
            try
            {
                return await _vehiculoRutaEmpresaRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
