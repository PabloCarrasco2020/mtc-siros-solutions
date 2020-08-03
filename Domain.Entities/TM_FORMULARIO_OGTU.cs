using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Entities
{
    public class TM_FORMULARIO_OGTU:COMMON_EXTENSION
    {
        public int? NUM_IDFORMULARIOTU { get; set; }
        public string STR_PLACA { get; set; }  
        public int? NUM_IDEMPRESA {get;set;}    
        public int? NUM_IDSUCURSALXES {get;set;}  
        public int? NUM_IDVEHXEMP {get;set;}  
        public decimal? NUM_MONTO {get;set;}  
        public string DTE_FECSUM {get;set;}  
        public string STR_HORASUM {get;set;}      
        public string STR_MINUTOSUM {get;set;}  
        public string STR_NOMBREARCHIVO {get;set;}  
        public int? NUM_IDTPDOCUMENTOOPEXEMP {get;set;}  
        public string STR_NUMDOCUMENTOOPEXEMP {get;set;}  
        public int? NUM_IDTPDOCUMENTOOPEXEST {get;set;}  
        public string STR_NUMDOCUMENTOOPEXEST {get;set;}
        public int? NUM_IDSESION { get; set; }
        public int? NUM_IDENTIDADUSUARIO { get; set; }
        public string NOMBREOPEXEST { get; set; }
        public string NOMBREOPEXEMP { get; set; }
        public string NUM_IDCOMBUSTIBLE { get; set; }

    }
}
