namespace Application.Dto
{
    public class OperadorESDto
    {
        public class RSGet
        {
            public int? nIdNominaXSucursal { get; set; }
            public int? nIdSucursalxES { get; set; }
            public int? nIdTpDocumento { get; set; }
            public string sNroDocumento { get; set; }
            public string sApePaterno { get; set; }
            public string sApeMaterno { get; set; }
            public string sNombre { get; set; }
            public int? nIdTipoOper { get; set; }
            public string sFecNacimiento { get; set; }
            public string sFoto { get; set; }
        }
        public class RQInsert
        {
            public int? nIdSucursalxES { get; set; }
            public int? nIdTpDocumento { get; set; }
            public string sNroDocumento { get; set; }
            public string sApePaterno { get; set; }
            public string sApeMaterno { get; set; }
            public string sNombre { get; set; }
            public int? nIdTipoOper { get; set; }
            public string sFecNacimiento { get; set; }
            public string sFoto { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQUpdate
        {
            public int? nIdNominaXSucursal { get; set; }
            public int? nIdTipoOper { get; set; }
            public string sFecNacimiento { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQDelete
        {
            public int? nIdNominaXSucursal { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RSGetXDoc
        {
            public string sApePaterno { get; set; }
            public string sApeMaterno { get; set; }
            public string sNombre { get; set; }
        }
    }
}
