﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_ESTACIONSERVICIO:COMMON_EXTENSION
    {
        public int? NUM_IDESTSERVICIO { get; set; }
        public string STR_NUMRUC { get; set; }
        public string STR_RAZONSOCIAL { get; set; }
        public int? NUM_IDTPVIA { get; set; }
        public string STR_NOMVIA { get; set; }
        public int? NUM_IDCCPP { get; set; }
        public string STR_NOMCCPP { get; set; }
        public int? NUM_IDNUMAKM { get; set; }
        public string STR_NUMMZKIL { get; set; }
        public int? NUM_IDLOINDP { get; set; }
        public string STR_INTLOTE { get; set; }
        public string STR_REFERENCIA { get; set; }
        public string STR_CDPTO { get; set; }
        public string STR_CDPROV { get; set; }
        public string STR_CDDIST { get; set; }
        public string STR_NROSUCURSALES { get; set; }
        public int? NUM_IDSESION { get; set; }
        public string STR_REPRESENTANTE { get; set; }
        public int? NUM_IDENTIDADSSO { get; set; }
        public int? NUM_IDLOCALSSO { get; set; }
        public string STR_DIRECCION { get; set; }
    }
}
