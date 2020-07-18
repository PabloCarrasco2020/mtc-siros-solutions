using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class EmpresaDto
    {
        public class RSGet
        {
            public int nIdEmpresa { get; set; }
            public string sRuc { get; set; }
            public string sRazonSocial { get; set; }
            public int nIdTipoVia { get; set; }
            public string sNombreVia { get; set; }
            public int nIdCcpp { get; set; }
            public string sNombreCcpp { get; set; }
            public int nIdNroMzKm { get; set; }
            public string sNroMzKm { get; set; }
            public int nIdLoteIntDpto { get; set; }
            public int sLoteIntDpto { get; set; }
            public string sReferencia { get; set; }
            public string sDireccion { get; set; }
            public string sCodDistrito { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDepartamento { get; set; }
            public string sTelefono { get; set; }
            public string sRepresentante { get; set; }
        }

        public class RQInsert
        {
            public string sRuc { get; set; }
            public string sRazonSocial { get; set; }
            public int nIdTipoVia { get; set; }
            public string sNombreVia { get; set; }
            public int nIdCcpp { get; set; }
            public string sNombreCcpp { get; set; }
            public int nIdNroMzKm { get; set; }
            public string sNroMzKm { get; set; }
            public int nIdLoteIntDpto { get; set; }
            public string sLoteIntDpto { get; set; }
            public string sReferencia { get; set; }
            // public string sDireccion { get; set; }
            public string sCodDistrito { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDepartamento { get; set; }
            public string sTelefono { get; set; }
            public string sRepresentante { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
            public int? nIdEntidadSSO { get; set; }
        }

        public class RQUpdate
        {
            public int nIdEmpresa { get; set; }
            public string sRuc { get; set; }
            public string sRazonSocial { get; set; }
            public int nIdTipoVia { get; set; }
            public string sNombreVia { get; set; }
            public int nIdCcpp { get; set; }
            public string sNombreCcpp { get; set; }
            public int nIdNroMzKm { get; set; }
            public string sNroMzKm { get; set; }
            public int nIdLoteIntDpto { get; set; }
            public int sLoteIntDpto { get; set; }
            public string sReferencia { get; set; }
            // public string sDireccion { get; set; }
            public string sCodDistrito { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDepartamento { get; set; }
            public string sTelefono { get; set; }
            public string sRepresentante { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
            public int? nIdEntidadSSO { get; set; }
        }

        public class RQDelete
        {
            public int nIdEmpresa { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
            public int? nIdEntidadSSO { get; set; }
        }
    }
}
