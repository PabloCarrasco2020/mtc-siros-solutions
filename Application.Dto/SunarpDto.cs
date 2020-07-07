using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Dto
{
    public class SunarpDto
    {
        #region Response Models

        public class SunarpMtcResponseModel
        {
            public VehiculoSunarpMtcModel Vehiculo { get; set; }
            public List<PropietarioSunarpMtcModel> Propietarios { get; set; }

            public SunarpMtcResponseModel()
            {
                this.Propietarios = new List<PropietarioSunarpMtcModel>();
            }
        }

        #endregion

        #region Consulta por chasis models
        public class ConsultaxChasis
        {
            public Chasis chasis { get; set; }
        }
        public class Chasis
        {
            public List<VehiculoChasis> vehiculo { get; set; }
        }
        public class VehiculoChasis
        {
            public string no_tarj_prop { get; set; }
            public string placa_nueva { get; set; }
            public string placa_antigua { get; set; }
            public string fecha_inscripcion { get; set; }
            public string ano_fabricacion { get; set; }
            public string vin { get; set; }
        }
        #endregion

        public class ConsultaxPLaca
        {
            public PlacaVigente placa_vigente { get; set; }
        }
        public class ConsultaxPlacav2
        {
            public PlacaVigentev2 placa_vigente { get; set; }
        }
        public class Propietario
        {
            public string tipo_documento { get; set; }
            public string documento { get; set; }
            public string razon_social { get; set; }
            public string paterno { get; set; }
            public string materno { get; set; }
            public string nombres { get; set; }
            public string direccion { get; set; }
            public string fecha_propiedad { get; set; }
        }

        public class Propietarios
        {
            public Propietario Propietario { get; set; }
        }

        public class Vehiculo
        {
            public string reparticion { get; set; }
            public string ubigeo { get; set; }
            public string placa_nueva { get; set; }
            public string placa_antigua { get; set; }
            public string an_titu { get; set; }
            public string no_titu { get; set; }
            public string fecha_inscripcion { get; set; }
            public string clase { get; set; }
            public string carroceria { get; set; }
            public string marca { get; set; }
            public string modelo { get; set; }
            public string ano_fabricacion { get; set; }
            public string combustible { get; set; }
            public string cilindros { get; set; }
            public string ejes { get; set; }
            public string colores { get; set; }
            public string motor { get; set; }
            public string serie { get; set; }
            public string vin { get; set; }
            public string tipo_uso { get; set; }
            public string categoria { get; set; }
            public string ruedas { get; set; }
            public string pasajeros { get; set; }
            public string asientos { get; set; }
            public string peso_seco { get; set; }
            public string carga_util { get; set; }
            public string peso_bruto { get; set; }
            public string longitud { get; set; }
            public string altura { get; set; }
            public string ancho { get; set; }
            public Propietarios Propietarios { get; set; }
        }

        public class PlacaVigente
        {
            public Vehiculo vehiculo { get; set; }
        }
        public class PlacaVigentev2
        {
            public List<Vehiculo> vehiculo { get; set; }
        }

        #region MTC response model
        public class PropietarioSunarpMtcModel
        {
            public string tipo_documento { get; set; }
            public string cod_tipo_documento
            {
                get
                {
                    var response = "";
                    if (tipo_documento.Contains("Registro Unico Contribuyente"))
                    {
                        response = "1";
                    }
                    else if (tipo_documento == "Documento Nacional de Identidad")
                    {
                        response = "2";
                    }
                    else if (tipo_documento.Contains("Carnet de Identidad") || tipo_documento == "Carnet Identidad Militar")
                    {
                        response = "3";
                    }
                    else if (tipo_documento.Contains("Carnet de Extranjer"))
                    {
                        response = "4";
                    }
                    else if (tipo_documento == "Permiso Temporal de Permanencia")
                    {
                        response = "14";
                    }
                    else
                    {
                        response = "6";
                    }

                    return response;
                }
            }
            public string documento { get; set; }
            public string razon_social { get; set; }
            public string paterno { get; set; }
            public string materno { get; set; }
            public string nombres { get; set; }
            public string direccion { get; set; }
            public string fecha_propiedad { get; set; }
        }
        
        public class VehiculoSunarpMtcModel
        {
            public string reparticion { get; set; }
            public string ubigeo { get; set; }
            public string placa_nueva { get; set; }
            public string placa_antigua { get; set; }
            public string an_titu { get; set; }
            public string no_titu { get; set; }
            public string fecha_inscripcion { get; set; }
            public string clase { get; set; }
            public string carroceria { get; set; }
            public string marca { get; set; }
            public string modelo { get; set; }
            public string ano_fabricacion { get; set; }
            public string combustible { get; set; }
            public string cilindros { get; set; }
            public string ejes { get; set; }
            public string colores { get; set; }
            public string motor { get; set; }
            public string serie { get; set; }
            public string vin { get; set; }
            public string tipo_uso { get; set; }
            public string categoria { get; set; }
            public string ruedas { get; set; }
            public string pasajeros { get; set; }
            public string asientos { get; set; }
            public string peso_seco { get; set; }
            public string carga_util { get; set; }
            public string peso_bruto { get; set; }
            public string longitud { get; set; }
            public string altura { get; set; }
            public string ancho { get; set; }
        }
        #endregion
    }
}
