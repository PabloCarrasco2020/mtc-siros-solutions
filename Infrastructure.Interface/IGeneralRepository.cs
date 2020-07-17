using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Interface
{
    public interface IGeneralRepository
    {
        Task<List<GENERAL.TIPO_VIA>> GetTipoVia();
        Task<List<GENERAL.CENTRO_POBLADO>> GetCentroPoblado();
        Task<List<GENERAL.NUMERO_MANZANA>> GetNumeroManzana();
        Task<List<GENERAL.LOTE_INTERIOR>> GetLoteInterior();
        Task<List<GENERAL.DEPARTAMENTO>> GetDepartamento();
        Task<List<GENERAL.PROVINCIA>> GetProvincia(string sCodDepartamento);
        Task<List<GENERAL.DISTRITO>> GetDistrito(string sCodDepartamento, string sCodProvincia);
        Task<List<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL>> GetTipoDoc(string sTipoConsulta);
        Task<List<GENERAL.TIPO_DOCUMENTO_REPRESENTANTELEGAL>> GetTipoOperador(string sTipoConsulta);
        Task<List<GENERAL.CARGO_REPRESENTANTELEGAL>> GetCargoRepresentanteLegal();
    }
}
