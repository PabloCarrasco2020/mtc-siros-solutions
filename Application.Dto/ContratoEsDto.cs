using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ContratoEsDto
    {
        public class RSGet
        {
            public int nIdEstServicioEnt { get; set; }
            public int nIdEstServicio { get; set; }
            public int nIdEntidad { get; set; }
            public string sNumContrato { get; set; }
            public string sFecContrato { get; set; }
            public string sFecIniVigencia { get; set; }
            public string sFecFinVigencia { get; set; }
        }

        public class RQInsert
        {
            public int? nIdEstServicio { get; set; }
            public int? nIdEntidad { get; set; }
            public string sNumContrato { get; set; }
            public string sFecContrato { get; set; }
            public string sFecIniVigencia { get; set; }
            public string sFecFinVigencia { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQUpdate
        {
            public int? nIdEstServicioEnt { get; set; }
            public string sNumContrato { get; set; }
            public string sFecContrato { get; set; }
            public string sFecIniVigencia { get; set; }
            public string sFecFinVigencia { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQDelete
        {
            public int? nIdEstServicioEnt { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
