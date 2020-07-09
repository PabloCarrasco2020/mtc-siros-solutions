using Application.Dto;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Net;
using System.Threading.Tasks;
using Transversal.Common;

namespace SIROS.Test
{
    [TestClass]
    public class SSOTest
    {
        private string _sMiddlewareUrl = "http://mtc-dvmapas01/wsSSO/";
        private string _sTokenUserMiddleware = "developer";
        private string _sTokenPassMiddleware = "123456";
        private string _sApplicationIdSSO = "373";
        private string _sTokenUserSSO = "SIROS2020";
        private string _sTokenPassSSO = "SIROS2020$";

        private const string SERVICE_NAME = "MiddleWareAPI";

        [TestMethod]
        public async Task TestEnterpriseNew()
        {
            string sDocumentNumber = "20100113610";

            var oResult = await this.EnterpriseNew(sDocumentNumber);
            var oResult2 = await this.EnterpriseAttachApp(oResult.Data.IdPersona.ToString(), sDocumentNumber);

            Assert.IsTrue(true);
        }

        private async Task<string> AuthMiddleWare()
        {
            const string METHOD_NAME = "AuthMiddleWare";

            try
            {
                string sResponse = null;

                using (WebApiClient oHttpClient = new WebApiClient())
                {
                    string sUrl = this._sMiddlewareUrl + "api/v1/seguridad/authenticate";

                    var oRequest = new SSODto.Authenticate.Request();
                    oRequest.Username = this._sTokenUserMiddleware;
                    oRequest.Password = this._sTokenPassMiddleware;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.Authenticate.Request, string>(sUrl, oRequest);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        sResponse = oClientResponse.Content;
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        //oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [400] Petición Invalida.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        //oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [401] Acceso Denegado.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        //oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [404] Ruta Invalida.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        //oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [500] Error Interno.";
                    }
                    else
                    {
                        //oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [{(int)oClientResponse.StatusCode}] Error Desconocido.";
                    }
                }

                return sResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}) : " + ex.Message);
            }
        }

        private async Task<Response<SSODto.EnterpriseNew.Response>> EnterpriseNew(string sDocumentNumber)
        {
            const string METHOD_NAME = "EnterpriseNew";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<SSODto.EnterpriseNew.Response>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._sMiddlewareUrl + "api/v1/sso/EnterpriseNewRecord";

                    var oRequest = new SSODto.EnterpriseNew.Request();
                    oRequest.ApplicationId = this._sApplicationIdSSO;
                    oRequest.TokenUser = this._sTokenUserSSO;
                    oRequest.TokenPassword = this._sTokenPassSSO;
                    oRequest.DocumentNumber = sDocumentNumber;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.EnterpriseNew.Request, SSODto.SSOResponse<SSODto.EnterpriseNew.Response>>(sUrl, oRequest);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        oResponse.IsSuccess = oClientResponse.Content.Success;
                        oResponse.Data = oClientResponse.Content.Data;
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) {oClientResponse.Content.Message}";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [401] Acceso Denegado.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [404] Ruta Invalida.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [500] Error Interno.";
                    }
                    else
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [{(int)oClientResponse.StatusCode}] Error Desconocido.";
                    }
                }

                return oResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}) : " + ex.Message);
            }
        }

        public async Task<Response<SSODto.EnterpriseAttachApp.Response>> EnterpriseAttachApp(string sIdEmpresa, string sDocumentNumber)
        {
            const string METHOD_NAME = "EnterpriseAttachApp";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<SSODto.EnterpriseAttachApp.Response>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._sMiddlewareUrl + "api/v1/sso/EnterpriseAttachApplication";

                    var oRequest = new SSODto.EnterpriseAttachApp.Request();
                    oRequest.ApplicationId = this._sApplicationIdSSO;
                    oRequest.TokenUser = this._sTokenUserSSO;
                    oRequest.TokenPassword = this._sTokenPassSSO;
                    oRequest.idEmpresa = sIdEmpresa;
                    oRequest.DocumentNumber = sDocumentNumber;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.EnterpriseAttachApp.Request, SSODto.SSOResponse<SSODto.EnterpriseAttachApp.Response>>(sUrl, oRequest);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        oResponse.IsSuccess = oClientResponse.Content.Success;
                        oResponse.Data = oClientResponse.Content.Data;
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) {oClientResponse.Content.Message}";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.Unauthorized)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [401] Acceso Denegado.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.NotFound)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [404] Ruta Invalida.";
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.InternalServerError)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [500] Error Interno.";
                    }
                    else
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [{(int)oClientResponse.StatusCode}] Error Desconocido.";
                    }
                }

                return oResponse;
            }
            catch (Exception ex)
            {
                throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}) : " + ex.Message);
            }
        }
    }
}
