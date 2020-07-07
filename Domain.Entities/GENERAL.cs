using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class GENERAL
    {
        public class TIPO_VIA
        {
            public int? NUM_IDTPVIA { get; set; }
            public string STR_DSTPVIA { get; set; }
        }
        public class CENTRO_POBLADO
        {
            public int? NUM_IDCCPP { get; set; }
            public string STR_DSCCPP { get; set; }
        }
        public class NUMERO_MANZANA
        {
            public int? NUM_IDNUMAKM { get; set; }
            public string STR_DSNUMAKM { get; set; }
        }
        public class LOTE_INTERIOR
        {
            public int? NUM_IDLOINDP { get; set; }
            public string STR_DSLOINDP { get; set; }
        }
        public class DEPARTAMENTO
        {
            public string STR_CDPTO { get; set; }
            public string STR_DSDPTO { get; set; }
        }
        public class PROVINCIA
        {
            public string STR_CDPROV { get; set; }
            public string STR_DSPROV { get; set; }
        }
        public class DISTRITO
        {
            public string STR_CDDIST { get; set; }
            public string STR_DSDIST { get; set; }
        }
        public class TIPO_DOCUMENTO_REPRESENTANTELEGAL
        {
            public int? NUM_IDTPDOCUMENTO { get; set; }
            public string STR_DSTPDOCUMENTO { get; set; }
        }
        public class CARGO_REPRESENTANTELEGAL
        {
            public int? NUM_IDCARGO { get; set; }
            public string STR_DSCARGO { get; set; }
        }
    }
}
