using Domain.Entities;
using Domain.Interface;
using Infrastructure.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Main
{
    public class GeneralDomain : IGeneralDomain
    {
        private readonly IGeneralRepository _generalRepository;

        public GeneralDomain(IGeneralRepository generalRepository)
        {
            this._generalRepository = generalRepository;
        }
        public async Task<List<GENERAL.CARGO_REPRESENTANTELEGAL>> GetCargoRepresentanteLegal()
        {
            try
            {
                return await this._generalRepository.GetCargoRepresentanteLegal();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.CENTRO_POBLADO>> GetCentroPoblado()
        {
            try
            {
                return await this._generalRepository.GetCentroPoblado();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.DEPARTAMENTO>> GetDepartamento()
        {
            try
            {
                return await this._generalRepository.GetDepartamento();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.DISTRITO>> GetDistrito(string sCodDepartamento, string sCodProvincia)
        {
            try
            {
                return await this._generalRepository.GetDistrito(sCodDepartamento,sCodProvincia);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.LOTE_INTERIOR>> GetLoteInterior()
        {
            try
            {
                return await this._generalRepository.GetLoteInterior();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.NUMERO_MANZANA>> GetNumeroManzana()
        {
            try
            {
                return await this._generalRepository.GetNumeroManzana();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.PROVINCIA>> GetProvincia(string sCodDepartamento)
        {
            try
            {
                return await this._generalRepository.GetProvincia(sCodDepartamento);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL>> GetTipoDocRepresentanteLegal()
        {
            try
            {
                return await this._generalRepository.GetTipoDocRepresentanteLegal();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }

        public async Task<List<GENERAL.TIPO_VIA>> GetTipoVia()
        {
            try
            {
                return await this._generalRepository.GetTipoVia();
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
    }
}
