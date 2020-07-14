using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class JwtDto
    {
        public class Request
        {
            public string sUsername { get; set; }
            public string sUsernameSSO { get; set; }
            public string sProfile { get; set; }
            public string sIdSession { get; set; }
            public int nIdEmpresa { get; set; }
            public int nIdLocal { get; set; }
        }

        public class Response
        {
            public string sToken { get; set; }
            public DateTime dTokenExpiration { get; set; }
        }
    }
}
