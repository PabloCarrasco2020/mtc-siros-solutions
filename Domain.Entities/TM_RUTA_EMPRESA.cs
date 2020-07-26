using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_RUTA_EMPRESA : COMMON_EXTENSION
    {
        public int? NUM_IDRUTAXEMP { get; set; }
        public int? NUM_IDEMPRESA { get; set; }
        public int? NUM_IDRUTA { get; set; }
        public string DTE_FECINIVIG { get; set; }
        public string DTE_FECVENVIG { get; set; }
        public string STR_NUMDOCAUTO { get; set; }
        public string STR_ESTADO { get; set; }
        public int? NUM_IDSESION { get; set; }

        public string STR_NRORUTA { get; set; }
        public string STR_NOMBRERUTA { get; set; }
        public string STR_ITINERARIO { get; set; }
    }
}
