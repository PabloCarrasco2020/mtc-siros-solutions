using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class RutaEmpresaDomain : IRutaEmpresaDomain
    {
        private readonly IRutaEmpresaRepository _rutaEmpresaRepository;

        public RutaEmpresaDomain(IRutaEmpresaRepository rutaEmpresaRepository)
        {
            this._rutaEmpresaRepository = rutaEmpresaRepository;
        }

        public async Task<TM_RUTA_EMPRESA> Delete(TM_RUTA_EMPRESA input)
        {
            try
            {
                return await this._rutaEmpresaRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_RUTA_EMPRESA> Get(TM_RUTA_EMPRESA input)
        {
            try
            {
                return await _rutaEmpresaRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<TM_RUTA_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._rutaEmpresaRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_RUTA_EMPRESA>> GetCombo(TM_RUTA_EMPRESA input)
        {
            try
            {
                return await this._rutaEmpresaRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_RUTA_EMPRESA> Insert(TM_RUTA_EMPRESA input)
        {
            try
            {
                return await _rutaEmpresaRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_RUTA_EMPRESA> Update(TM_RUTA_EMPRESA input)
        {
            try
            {
                return await _rutaEmpresaRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
