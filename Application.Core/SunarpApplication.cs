using Application.Dto;
using Application.Interface;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;
using Transversal.Common.Functions;

namespace Application.Core
{
    public class SunarpApplication : ISunarpApplication
    {
        private readonly IMapper _mapper;

        public SunarpApplication(IMapper mapper)
        {
            this._mapper = mapper;

            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<SunarpDto.Propietario, SunarpDto.PropietarioSunarpMtcModel>();
                cfg.CreateMap<SunarpDto.Vehiculo, SunarpDto.VehiculoSunarpMtcModel>();
            });
            this._mapper = config.CreateMapper();
        }

        public async Task<Response<SunarpDto.SunarpMtcResponseModel>> ConsultaPlaca(string sPlaca)
        {
            try
            {
                var oResponse = new Response<SunarpDto.SunarpMtcResponseModel>();
                oResponse.IsSuccess = false;

                var wsSunarp = new wsSoapSUNARP.WSVehicularMtcDelegateClient();
                var oResult = await wsSunarp.getConsultaxPlacaMTCAsync(sPlaca);

                if (oResult == null)
                {
                    oResponse.Message = "No se encontro información de la PLACA ingresada.";
                    return oResponse;
                }
                
                var sJson = FuncConvert.XmlToJson(oResult.Body.@return);

                // DEBIDO A QUE EL SERVICIO RESPONDE DE DOS MANERAS SE ESTA USANDO UN METODO QUE NOS AYUDA A CONVERTIR DE JSON A OBJETO
                var oData = FuncConvert.TryParseJsonToObject<SunarpDto.ConsultaxPLaca, SunarpDto.ConsultaxPlacav2>(sJson);

                var oInfo = new SunarpDto.SunarpMtcResponseModel();

                // VALIDAMOS QUE TIPO DE DATO RESPONDIO
                if (oData is SunarpDto.ConsultaxPLaca)
                {
                    // SE LLENA LA INFORMACION CUANDO TRAE SOLO UN PROPIETARIO
                    var oValue = (SunarpDto.ConsultaxPLaca)oData;
                    if (oValue != null)
                    {
                        oInfo.Propietarios.Add(this._mapper.Map<SunarpDto.Propietario, SunarpDto.PropietarioSunarpMtcModel>(oValue.placa_vigente.vehiculo.Propietarios.Propietario));
                        oInfo.Vehiculo = this._mapper.Map<SunarpDto.Vehiculo, SunarpDto.VehiculoSunarpMtcModel>(oValue.placa_vigente.vehiculo);
                    }                    
                }
                else if (oData is SunarpDto.ConsultaxPlacav2)
                {
                    // SE LLENA LA INFORMACION CUANDO TRAE MAS DE UN PROPIETARIO
                    var oValue = (SunarpDto.ConsultaxPlacav2)oData;
                    if (oValue != null)
                    {
                        oInfo.Vehiculo = this._mapper.Map<SunarpDto.Vehiculo, SunarpDto.VehiculoSunarpMtcModel>(oValue.placa_vigente.vehiculo[0]);
                        for (var i = 0; i < oValue.placa_vigente.vehiculo.Count; i++)
                        {
                            oInfo.Propietarios.Add(this._mapper.Map<SunarpDto.Propietario, SunarpDto.PropietarioSunarpMtcModel>(oValue.placa_vigente.vehiculo[i].Propietarios.Propietario));
                        }
                    }
                }

                oResponse.IsSuccess = true;
                oResponse.Data = oInfo;
                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
