using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using Transversal.Common;

namespace Application.Core
{
    public class ReniecApplication : IReniecApplication
    {
        private readonly IConfiguration _configuration;
        private string _sReniecUrl;

        public ReniecApplication(IConfiguration configuration)
        {
            this._configuration = configuration;
            this._sReniecUrl = this._configuration.GetSection("Servicios").GetSection("ReniecAPI").Value + "Reniec/{0}";
        }

        public async Task<Response<ReniecDto.ConsultaNumDocResponseModel>> ConsultaNumDoc(string sNumDoc)
        {
            try
            {
                var oResponse = new Response<ReniecDto.ConsultaNumDocResponseModel>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient())
                {
                    string sUrl = string.Format(this._sReniecUrl, sNumDoc);
                    var oClientResponse = await oHttpClient.CallGetAsync<ReniecDto.ReniecResult>(sUrl);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        if (oClientResponse.Content != null)
                        {
                            if (oClientResponse.Content.result != null)
                            {
                                var oResult = new ReniecDto.ConsultaNumDocResponseModel();
                                oResult.nPersonId = oClientResponse.Content.result.personId;
                                oResult.sNumDoc = oClientResponse.Content.result.dni;
                                oResult.sApellidoPaterno = oClientResponse.Content.result.lastNameDad;
                                oResult.sApellidoMaterno = oClientResponse.Content.result.lastNameMom;
                                oResult.sNombres = oClientResponse.Content.result.name;
                                oResult.sDireccion = oClientResponse.Content.result.address;
                                oResult.sEstado = oClientResponse.Content.result.status;
                                oResult.sFoto = oClientResponse.Content.result.photo;

                                oResponse.IsSuccess = true;
                                oResponse.Data = oResult;
                            }
                        }
                    }
                    else if ((int)oClientResponse.StatusCode == 422) //es menor de edad o no se encuentra
                    {
                        oResponse.Message = "(RENIEC) Error, La persona es un menor de edad o el numero de documento no existe;";
                    }
                    else
                    {
                        oResponse.Message = "(RENIEC) Error al realizar la consulta;";
                    }
                }

                return oResponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
