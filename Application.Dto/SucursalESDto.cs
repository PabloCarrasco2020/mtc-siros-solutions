using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class SucursalESDto
    {
        public class RSGet
        {
            public int? nIdSucursalxES { get; set; }
            public int? nIdEstServicio { get; set; }
            public int? nTipoVia { get; set; }
            public string sVia { get; set; }
            public int? nCentroPoblado { get; set; }
            public string sCentroPoblado { get; set; }
            public int? nIdNumeroManzana { get; set; }
            public string sNumeroManzana { get; set; }
            public int? nIdLoteInterior { get; set; }
            public string sLoteInterior { get; set; }
            public string sReferencia { get; set; }
            public string sCodDepartamento { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDistrito { get; set; }
            public string sLatitud { get; set; }
            public string sLongitud { get; set; }
        }
        public class RQInsert
        {
            public int? nIdEstServicio { get; set; }
            public int? nTipoVia { get; set; }
            public string sVia { get; set; }
            public int? nCentroPoblado { get; set; }
            public string sCentroPoblado { get; set; }
            public int? nIdNumeroManzana { get; set; }
            public string sNumeroManzana { get; set; }
            public int? nIdLoteInterior { get; set; }
            public string sLoteInterior { get; set; }
            public string sReferencia { get; set; }
            public string sCodDepartamento { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDistrito { get; set; }
            public string sLatitud { get; set; }
            public string sLongitud { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
            public int? nIdentidadUsuario { get; set; }
            public int? nIdentidadsso { get; set; }
            public int? nIdLocalsso { get; set; }
            public string sRucEstacionServicio { get; set; }
            public string sDireccionSucursal { get; set; }
        }
        public class RQUpdate
        {
            public int? nIdSucursalxES { get; set; }
            public int? nTipoVia { get; set; }
            public string sVia { get; set; }
            public int? nCentroPoblado { get; set; }
            public string sCentroPoblado { get; set; }
            public int? nIdNumeroManzana { get; set; }
            public string sNumeroManzana { get; set; }
            public int? nIdLoteInterior { get; set; }
            public string sLoteInterior { get; set; }
            public string sReferencia { get; set; }
            public string sCodDepartamento { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDistrito { get; set; }
            public string sLatitud { get; set; }
            public string sLongitud { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQDelete
        {
            public int? nIdSucursalxES { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
