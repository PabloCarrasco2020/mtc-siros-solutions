using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class FormularioOGTUDto
    {
        public class RSGet
        {
        }
        public class RQInsert
        {
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQUpdate
        {
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
        public class RQDelete
        {
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
