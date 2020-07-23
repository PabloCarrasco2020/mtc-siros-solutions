using Application.Dto;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class OngeiApplication : IOngeiApplication
    {
        public OngeiApplication()
        {

        }

        public async Task<Response<OngeiDto.OngeiResponseModel>> ConsultaCarnetExt(string sNumDoc)
        {
            try
            {
                var oResponse = new Response<OngeiDto.OngeiResponseModel>();
                oResponse.IsSuccess = false;

                var wsOngei = new wsSoapONGEI.ServiciosOngeiMTCClient();
                var oResult = await wsOngei.MigraciogetCarnetExtAsync(sNumDoc, "CE");

                if (oResult == null)
                {
                    oResponse.Message = "No se encontro información del NRO.DOCUMENTO ingresado.";
                    return oResponse;
                }
                if (oResult.CarnetExtranjeria == null)
                {
                    oResponse.Message = "No se encontro información del NRO.DOCUMENTO ingresado.";
                    return oResponse;
                }

                var oResp = new OngeiDto.OngeiResponseModel();
                oResp.sCalidadMigratoria = oResult.CarnetExtranjeria.calidadMigratoria;
                oResp.sNombres = oResult.CarnetExtranjeria.nombres;
                oResp.sPrimerApellido = oResult.CarnetExtranjeria.primerApellido;
                oResp.sSegundoApellido = oResult.CarnetExtranjeria.segundoApellido;
                oResp.sNumRespuesta = oResult.CarnetExtranjeria.numRespuesta;

                oResponse.IsSuccess = true;
                oResponse.Data = oResp;
                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
