using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class VehiculoRutaEmpresaDto
    {
        public class RSGet
        {
            public int? nIdVehXEmp { get; set; }
            public int? nIdEstServicio { get; set; }
            public int? nIdSucursalXEs { get; set; }
            public int? nIdCombustible { get; set; }
            public string sPlaca { get; set; }
            public string sAnioFab { get; set; }
            public string sAnioModelo { get; set; }
            public string sMarca { get; set; }
            public int? nAsientos { get; set; }
        }

        public class RQInsert
        {
            public int? nIdEmpresa { get; set; }
            public int? nIdRutaXEmp { get; set; }
            public int? nIdSucursalXEs { get; set; }
            public int? nIdCombustible { get; set; }
            public string sPlaca { get; set; }
            public string sAnioFab { get; set; }
            public string sAnioModelo { get; set; }
            public string sMarca { get; set; }
            public int? nAsientos { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQUpdate
        {
            public int? nIdVehXEmp { get; set; }
            public int? nIdSucursalXEs { get; set; }
            public int? nIdCombustible { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }

        public class RQDelete
        {
            public int? nIdVehXEmp { get; set; }
            public string sUsuario { get; set; }
            public int? nIdSession { get; set; }
        }
    }
}
