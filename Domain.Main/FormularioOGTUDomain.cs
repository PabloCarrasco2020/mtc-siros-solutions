using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class FormularioOGTUDomain : IFormularioOGTUDomain
    {
        private readonly IFormularioOGTURepository _formularioOGTURepository;

        public FormularioOGTUDomain(IFormularioOGTURepository formularioOGTURepository)
        {
            this._formularioOGTURepository = formularioOGTURepository;
        }
        public async Task<TM_FORMULARIO_OGTU> Delete(TM_FORMULARIO_OGTU input)
        {
            try
            {
                return await this._formularioOGTURepository.Delete(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_FORMULARIO_OGTU> Get(TM_FORMULARIO_OGTU input)
        {
            try
            {
                return await this._formularioOGTURepository.Get(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_FORMULARIO_OGTU>> GetAllByFilter(int cantidadXPagina, int pagina, string filter)
        {
            try
            {
                return await this._formularioOGTURepository.GetAllByFilter(cantidadXPagina,pagina,filter);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<List<TM_FORMULARIO_OGTU>> GetCombo(TM_FORMULARIO_OGTU input)
        {
            throw new NotImplementedException();
        }

        public async Task<TM_FORMULARIO_OGTU> Insert(TM_FORMULARIO_OGTU input)
        {
            try
            {
                return await this._formularioOGTURepository.Insert(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<TM_FORMULARIO_OGTU> Update(TM_FORMULARIO_OGTU input)
        {
            try
            {
                return await this._formularioOGTURepository.Update(input);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
