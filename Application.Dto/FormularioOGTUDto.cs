using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class FormularioOGTUDto
    {
        public class RSGet
        {
            public int? nIdFormularioTU { get; set; }
            public string sPlaca { get; set; }
            public int? nIdEmpresa { get; set; }
            public int? nIdSucursalXES { get; set; }
            public int? nIdVehXEmp { get; set; }
            public decimal? nMonto { get; set; }
            public string sFecSum { get; set; }
            public string sHoraSum { get; set; }
            public string sMinutoSum { get; set; }
            public string sNombreArchivo { get; set; }
            public int? nIdTpDocumentoOpeXEmp { get; set; }
            public string sNumDocumentoOpeXEmp { get; set; }
            public int? nIdTpDocumentoOpEXEst { get; set; }
            public string sNumDocumentoOpeXEst { get; set; }
        }
        public class RQInsert
        {
            public string sPlaca { get; set; }
            public int? nIdEmpresa { get; set; }
            public int? nIdSucursalXES { get; set; }
            public int? nIdVehXEmp { get; set; }
            public decimal? nMonto { get; set; }
            public string sFecSum { get; set; }
            public string sHoraSum { get; set; }
            public string sMinutoSum { get; set; }
            public string sNombreArchivo { get; set; }
            public int? nIdTpDocumentoOpeXEmp { get; set; }
            public string sNumDocumentoOpeXEmp { get; set; }
            public int? nIdTpDocumentoOpEXEst { get; set; }
            public string sNumDocumentoOpeXEst { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQUpdate
        {
            public int? nIdFormularioTU { get; set; }
            public string sPlaca { get; set; }
            public int? nIdEmpresa { get; set; }
            public int? nIdSucursalXES { get; set; }
            public decimal? nMonto { get; set; }
            public string sFecSum { get; set; }
            public string sHoraSum { get; set; }
            public string sMinutoSum { get; set; }
            public string sNombreArchivo { get; set; }
            public int? nIdTpDocumentoOpeXEmp { get; set; }
            public string sNumDocumentoOpeXEmp { get; set; }
            public int? nIdTpDocumentoOpEXEst { get; set; }
            public string sNumDocumentoOpeXEst { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQDelete
        {
            public int? nIdFormularioTU { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
