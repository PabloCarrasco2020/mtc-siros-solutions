using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_RUTA : COMMON_EXTENSION
    {
        public int? NUM_IDRUTA { get; set; }
        public string STR_NRORUTA { get; set; }
        public string STR_NOMBRERUTA { get; set; }
        public string STR_ITINERARIO { get; set; }
        public string STR_KILOMETRO { get; set; }
    }
}
