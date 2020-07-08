using System;
namespace Domain.Entities
{
    public class COMMON_EXTENSION
    {
        // propiedades de tabla filtrada
        public int? NUM_FILA { get; set; }
        public int? NUM_REGISTROS { get; set; }
        public int? NUM_PAGINAS { get; set; }
        // propiedades de usuario
        public string STR_USUCREACION { get; set; }
        public string STR_USUACT { get; set; }
        // propiedades de respuesta de transacción de la bd
        public string STR_ESTADOPROCESO { get; set; }
        public string STR_MENSAJE { get; set; }
    }
}
