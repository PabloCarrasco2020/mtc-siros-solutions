using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class ReniecDto
    {
        #region Response Models

        public class ConsultaNumDocResponseModel
        {
            public int nPersonId { get; set; }
            public string sNumDoc { get; set; }
            public string sApellidoPaterno { get; set; }
            public string sApellidoMaterno { get; set; }
            public string sNombres { get; set; }
            public string sDireccion { get; set; }
            public string sEstado { get; set; }
            public string sFoto { get; set; }
        }

        #endregion

        public class ReniecResult
        {
            public ReniecPerson result { get; set; }
            public float delay { get; set; }
            public string origin { get; set; }
        }

        public class ReniecPerson
        {
            public int personId { get; set; }
            public string dni { get; set; }
            public string lastNameDad { get; set; }
            public string lastNameMom { get; set; }
            public string name { get; set; }
            public string address { get; set; }
            public string status { get; set; }
            public string photo { get; set; }
            public DateTime inserted { get; set; }
        }
    }
}
