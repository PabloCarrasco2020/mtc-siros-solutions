using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class CombustibleDto
    {
        public class RSGet
        {
            public int? nIdCombustible { get; set; }
            public string sDsCombustible { get; set; }
          
        }
        public class RQInsert
        {
            public string sDsCombustible { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
           
        }
        public class RQUpdate
        {
            public int? nIdCombustible { get; set; }
            public string sDsCombustible { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }

        }
        public class RQDelete
        {
            public int? nIdCombustible { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
