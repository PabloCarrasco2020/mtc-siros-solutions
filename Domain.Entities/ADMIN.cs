using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class ADMIN
    {
        public class TM_SESION : COMMON_EXTENSION
        {
            public int NUM_IDSESION { get; set; }
            public string STR_USUARIO { get; set; }
            public string STR_USERSO { get; set; }
            public string STR_NUMEROIP { get; set; }
            public string STR_FLAGCR { get; set; }
            public DateTime? DTE_FECHAINICIO { get; set; }
            public DateTime? DTE_FECHAFIN { get; set; }
        }
    }
}
