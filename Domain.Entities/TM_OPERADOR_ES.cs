using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_OPERADOR_ES:COMMON_EXTENSION
    {
        public int? NUM_IDNOMINAXSUCURSAL { get; set; }
        public int? NUM_IDSUCURSALXES { get; set; }
        public int? NUM_IDTPDOCUMENTO { get; set; }
        public string STR_NUMDOCUMENTO { get; set; }
        public string STR_APEPATERNO { get; set; }
        public string STR_APEMATERNO { get; set; }
        public string STR_NOMBRE { get; set; }
        public int? NUM_IDTIPOOPER { get; set; }
        public string DTE_FECNACIMIENTO { get; set; }
        public string STR_FOTO { get; set; }
        public int? NUM_IDSESION { get; set; }
        public string STR_DSTIPOOPER { get; set; }
    }
}
