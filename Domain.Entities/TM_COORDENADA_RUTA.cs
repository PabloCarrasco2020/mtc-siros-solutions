using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_COORDENADA_RUTA: COMMON_EXTENSION
    {
        public int? NUM_IDRUTA { get; set; }
        public string STR_LATITUD { get; set; }
        public string STR_LONGITUD { get; set; }
        public string STR_ESTADO { get; set; }
        public int? NUM_IDSESION { get; set; }
    }
}
