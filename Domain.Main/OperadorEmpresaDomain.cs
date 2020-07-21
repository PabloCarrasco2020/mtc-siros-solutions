using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class OperadorEmpresaDomain : IOperadorEmpresaDomain
    {
        private readonly IOperadorEmpresaRepository _operadorEmpresaRepository;

        public OperadorEmpresaDomain(IOperadorEmpresaRepository operadorEmpresaRepository)
        {
            this._operadorEmpresaRepository = operadorEmpresaRepository;
        }

        public async Task<TM_OPERADOR_EMPRESA> Delete(TM_OPERADOR_EMPRESA input)
        {
            try
            {
                return await this._operadorEmpresaRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_OPERADOR_EMPRESA> Get(TM_OPERADOR_EMPRESA input)
        {
            try
            {
                return await _operadorEmpresaRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<TM_OPERADOR_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._operadorEmpresaRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_OPERADOR_EMPRESA>> GetCombo(TM_OPERADOR_EMPRESA input)
        {
            try
            {
                return await this._operadorEmpresaRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_OPERADOR_EMPRESA> Insert(TM_OPERADOR_EMPRESA input)
        {
            try
            {
                return await _operadorEmpresaRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_OPERADOR_EMPRESA> Update(TM_OPERADOR_EMPRESA input)
        {
            try
            {
                return await _operadorEmpresaRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
