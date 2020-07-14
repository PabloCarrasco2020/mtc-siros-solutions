using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_CONTRATOES : COMMON_EXTENSION
    {
       public int? NUM_IDESTSERVICIOXENT { get; set; }
       public int? NUM_IDESTSERVICIO { get; set; }
       public int? NUM_IDENTIDAD { get; set; }
       public string STR_NUMCONTRATO { get; set; }
       public DateTime? DTE_FECCONTRATO { get; set; }
       public DateTime? DTE_FECINIVIG { get; set; }
       public DateTime? DTE_FECVENVIG { get; set; }
       public int? NUM_IDSESION { get; set; }
       public string STR_ELIMINAR { get; set; }

        public string STR_NUMRUC { get; set; }
        public string STR_RAZONSOCIAL { get; set; }
    }
}
