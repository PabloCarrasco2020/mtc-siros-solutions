using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class AdminDto
    {
        public class RegistrarSesion
        {
            public string sUsuario { get; set; }
            public string sUsuarioSSO { get; set; }
            public string sIp { get; set; }
            public string sFlag { get; set; }
        }
    }
}
