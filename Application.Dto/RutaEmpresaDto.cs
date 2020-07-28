using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class RutaEmpresaDto
    {
        public class RSGet
        {
            public int? nIdRutaXEmp { get; set; }
            public int? nIdEmpresa { get; set; }
            public int? nIdRuta { get; set; }
            public string sNumDocAuto { get; set; }
            public string sFecIniVig { get; set; }
            public string sFecVenVig { get; set; }
        }

        public class RQInsert
        {
            public int? nIdEmpresa { get; set; }
            public int? nIdRuta { get; set; }
            public string sNumDocAuto { get; set; }
            public string sFecIniVig { get; set; }
            public string sFecVenVig { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQUpdate
        {
            public int? nIdRutaXEmp { get; set; }
            public string sNumDocAuto { get; set; }
            public string sFecIniVig { get; set; }
            public string sFecVenVig { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQDelete
        {
            public int? nIdRutaXEmp { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
