using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
   public class CoordenadaRutaDto
    {
        public class RSGet
        {
            public int? nIdRuta { get; set; }
            public string sNroRuta { get; set; }
            public string sNombreRuta { get; set; }
            public string sItinerario { get; set; }
            public string sKilometro { get; set; }
            public string sEstado { get; set; }


        }
        public class RQInsert
        {
            public string sNombreRuta { get; set; }
            public string sItinerario { get; set; }
            public string sKilometro { get; set; }
            public string sEstado { get; set; }
            public int? nIdentidadUsuario { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }

        }
        public class RQUpdate
        {
            public int? nIdRuta { get; set; }
            public string sItinerario { get; set; }
            public string sKilometro { get; set; }
            public string sEstado { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }

        }
        public class RQDelete
        {
            public int? nIdRuta { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
