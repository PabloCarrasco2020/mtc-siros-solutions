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
            public int nIdentidad { get; set; }
            public string sNumContrato { get; set; }
            public DateTime? dFecContrato { get; set; }
            public DateTime? dFecIniVigencia { get; set; }
            public DateTime? dFecFinVigencia { get; set; }
        }

        public class RQInsert
        {
            public int? nIdEstServicio { get; set; }
            public int? nIdentidad { get; set; }
            public string sNumContrato { get; set; }
            public DateTime? dFecContrato { get; set; }
            public DateTime? dFecIniVigencia { get; set; }
            public DateTime? dFecFinVigencia { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQUpdate
        {
            public int? nIdEstServicioEnt { get; set; }
            public string sNumContrato { get; set; }
            public DateTime? dFecContrato { get; set; }
            public DateTime? dFecIniVigencia { get; set; }
            public DateTime? dFecFinVigencia { get; set; }
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
