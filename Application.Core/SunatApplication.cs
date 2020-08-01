using Application.Dto;
using Application.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class SunatApplication : ISunatApplication
    {
        public SunatApplication()
        {
            
        }

        public async Task<Response<SunatDto.ConsultaRucResponseModel>> ConsultaRuc(string sRuc)
        {
            try
            {
                var oResponse = new Response<SunatDto.ConsultaRucResponseModel>();
                oResponse.IsSuccess = false;

                if (string.IsNullOrEmpty(sRuc))
                {
                    oResponse.Message = "El RUC no puede estar vacio.";
                    return oResponse;
                }

                var wsSunat = new wsSoapSUNAT.DatosRucWSFacadeRemoteClient();
                var oResult = await wsSunat.getDatosPrincipalesAsync(sRuc);

                if (oResult == null)
                {
                    oResponse.Message = "No se encontro información del RUC ingresado.";
                    return oResponse;
                }

                var oResp = new SunatDto.ConsultaRucResponseModel();
                oResp.sTipoPersona = oResult.desc_identi ? .Trim();
                oResp.sNombre = oResult.ddp_nombre ? .Trim();
                oResp.sCodDepartamento = oResult.cod_dep ? .Trim();
                oResp.sCodProvincia = oResult.cod_prov ? .Trim();
                oResp.sCodDistrito = oResult.cod_dist ? .Trim();
                oResp.sUbigeo = oResult.ddp_ubigeo ? .Trim();
                oResp.sReferencia = oResult.ddp_refer1 ? .Trim();
                oResp.sEstado = oResult.desc_estado ? .Trim();
                oResp.bEstado = oResult.esActivo;
                oResp.sDireccion = "";

                List<string> lstDireccionValues = new List<string>();

                if (!string.IsNullOrEmpty(oResult.desc_tipvia))
                    if (!oResult.desc_tipvia.Trim().Equals("-"))
                        lstDireccionValues.Add(oResult.desc_tipvia ? .Trim());

                if (!string.IsNullOrEmpty(oResult.ddp_nomvia))
                    if (!oResult.ddp_nomvia.Trim().Equals("-"))
                        lstDireccionValues.Add(oResult.ddp_nomvia ? .Trim());

                if (!string.IsNullOrEmpty(oResult.desc_tipzon))
                    if (!oResult.desc_tipzon.Trim().Equals("-"))
                        lstDireccionValues.Add(oResult.desc_tipzon ? .Trim());

                if (!string.IsNullOrEmpty(oResult.ddp_nomzon))
                    if (!oResult.ddp_nomzon.Trim().Equals("-"))
                        lstDireccionValues.Add(oResult.ddp_nomzon ? .Trim());

                if (lstDireccionValues.Count > 0)
                {
                    StringBuilder sb = new StringBuilder();
                    foreach (string sValue in lstDireccionValues)
                    {
                        sb.Append(sValue);
                        sb.Append(" ");
                    }
                    oResp.sDireccion = sb.ToString().Trim();
                }

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
