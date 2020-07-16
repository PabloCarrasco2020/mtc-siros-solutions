namespace Application.Dto
{
    public class OperadorESDto
    {
        public class RSGet
        {
            public int? nIdEntidad { get; set; }
            public string sRuc { get; set; }
            public string sRazonSocial { get; set; }
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
            public string sRepresentante { get; set; }
        }
        public class RQInsert
        {
            public string sRuc { get; set; }
            public string sRazonSocial { get; set; }
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
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
            public string sRepresentante { get; set; }
            public int? nIdentidadsso { get; set; }
            public int? nIdLocalsso { get; set; }
        }
        public class RQUpdate
        {
            public int? nIdEntidad { get; set; }
            public string sRuc { get; set; }
            public string sRazonSocial { get; set; }
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
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
            public string sRepresentante { get; set; }
        }
        public class RQDelete
        {
            public int? nIdEntidad { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
