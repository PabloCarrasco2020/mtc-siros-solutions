using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class EmpresaDomain : IEmpresaDomain
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresaDomain(IEmpresaRepository empresaRepository)
        {
            this._empresaRepository = empresaRepository;
        }

        public async Task<TM_EMPRESA> Delete(TM_EMPRESA input)
        {
            try
            {
                return await this._empresaRepository.Delete(input);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<TM_EMPRESA> Get(TM_EMPRESA input)
        {
            try
            {
                return await _empresaRepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<List<TM_EMPRESA>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._empresaRepository.GetAllByFilter(cantidadXPagina, pagina, filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_EMPRESA>> GetCombo(TM_EMPRESA input)
        {
            try
            {
                return await this._empresaRepository.GetCombo(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_EMPRESA> Insert(TM_EMPRESA input)
        {
            try
            {
                return await _empresaRepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_EMPRESA> Update(TM_EMPRESA input)
        {
            try
            {
                return await _empresaRepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
