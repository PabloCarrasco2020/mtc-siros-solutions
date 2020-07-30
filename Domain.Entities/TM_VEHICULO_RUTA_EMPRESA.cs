using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_VEHICULO_RUTA_EMPRESA : COMMON_EXTENSION
    {
        public int? NUM_VEHXEMP { get; set; }
        public int? NUM_IDEMPRESA { get; set; }
        public int? NUM_IDRUTAXEMP { get; set; }
        public int? NUM_IDSUCURSALXES { get; set; }
        public int? NUM_IDCOMBUSTIBLE { get; set; }
        public int? NUM_IDESTSERVICIO { get; set; }
        public string STR_PLACA { get; set; }
        public string STR_ANOFAB { get; set; }
        public string STR_ANOMODELO { get; set; }
        public string STR_MARCA { get; set; }
        public int? NUM_ASIENTOS { get; set; }
        public string STR_COMBUSTIBLE { get; set; }
        public int? NUM_IDSESION { get; set; }
    }
}
