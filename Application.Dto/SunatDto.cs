using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class SunatDto
    {
        #region Response Models

        public class ConsultaRucResponseModel
        {
            public string sTipoPersona { get; set; }
            public string sNombre { get; set; }
            public string sCodDepartamento { get; set; }
            public string sCodProvincia { get; set; }
            public string sCodDistrito { get; set; }
            public string sUbigeo { get; set; }
            public string sDireccion { get; set; }
            public string sReferencia { get; set; }
            public string sEstado { get; set; }
            public bool bEstado { get; set; }
        }

        #endregion
    }
}
