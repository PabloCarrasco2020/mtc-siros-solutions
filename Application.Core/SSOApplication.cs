using System;
using System.Collections.Generic;
using System.Net;
using System.Threading.Tasks;
using Application.Dto;
using Application.Interface;
using Microsoft.Extensions.Options;
using Transversal.Common;
using Transversal.Common.Helper;

namespace Application.Core
{
    public class SSOApplication : ISSOApplication
    {
        private readonly AppSettings.Servicios _settingsServicios;
        private readonly AppSettings.CredencialesMiddleWare _settingsMiddleware;
        private readonly AppSettings.CredencialesSSO _settingsSSO;

        private const string SERVICE_NAME = "MiddleWareAPI";

        public SSOApplication(
            IOptions<AppSettings.Servicios> settingsServicios, 
            IOptions<AppSettings.CredencialesMiddleWare> settingsMiddleware,
            IOptions<AppSettings.CredencialesSSO> settingsSSO)
        {
            this._settingsServicios = settingsServicios.Value;
            this._settingsMiddleware = settingsMiddleware.Value;
            this._settingsSSO = settingsSSO.Value;
        }
        
        public async Task<string> AuthMiddleWare()
        {
            const string METHOD_NAME = "AuthMiddleWare";

            try
            {
                string sResponse = null;

                using (WebApiClient oHttpClient = new WebApiClient())
                {
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/seguridad/authenticate";

                    var oRequest = new SSODto.Authenticate.Request();
                    oRequest.Username = this._settingsMiddleware.TokenUser;
                    oRequest.Password = this._settingsMiddleware.TokenPassword;

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

        public async Task<Response<SSODto.Login.Response>> Login(SSODto.Login.RequestModel oItem)
        {
            const string METHOD_NAME = "Login";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<SSODto.Login.Response>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/Login";

                    var oRequest = new SSODto.Login.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser =this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
                    oRequest.UserName = oItem.sUsername;
                    oRequest.UserPassword = oItem.sPassword;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.Login.Request, SSODto.SSOResponse<SSODto.Login.Response>>(sUrl, oRequest);
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

        public async Task<Response<SSODto.EnterpriseNew.Response>> EnterpriseNew(string sDocumentNumber)
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
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/EnterpriseNewRecord";

                    var oRequest = new SSODto.EnterpriseNew.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser = this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
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
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/EnterpriseAttachApplication";

                    var oRequest = new SSODto.EnterpriseAttachApp.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser =this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
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

        public async Task<Response<SSODto.EnterpriseAddLocal.Response>> EnterpriseAddLocal(
            string sIdEmpresa,
            string sDocumentNumber,
            string sIdAplicacionEmpresa,
            string sNombreLocal,
            string sDireccionLocal)
        {
            const string METHOD_NAME = "EnterpriseAddLocal";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<SSODto.EnterpriseAddLocal.Response>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/EnterpriseAddLocal";

                    var oRequest = new SSODto.EnterpriseAddLocal.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser =this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
                    oRequest.idEmpresa = sIdEmpresa;
                    oRequest.DocumentNumber = sDocumentNumber;
                    oRequest.IdAplicacionEmpresa = sIdAplicacionEmpresa;
                    oRequest.NombreLocal = sNombreLocal;
                    oRequest.DireccionLocal = sDireccionLocal;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.EnterpriseAddLocal.Request, SSODto.SSOResponse<SSODto.EnterpriseAddLocal.Response>>(sUrl, oRequest);
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

        public async Task<Response<List<SSODto.Empresas.Response>>> GetEmpresas(string sDocumentNumber)
        {
            const string METHOD_NAME = "GetEmpresas";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<List<SSODto.Empresas.Response>>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/Empresas";

                    var oRequest = new SSODto.Empresas.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser =this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
                    oRequest.DocumentNumber = sDocumentNumber;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.Empresas.Request, SSODto.SSOResponse<List<SSODto.Empresas.Response>>>(sUrl, oRequest);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        if (oClientResponse.Content != null)
                        {
                            oResponse.IsSuccess = oClientResponse.Content.Success;
                            oResponse.Data = oClientResponse.Content.Data;
                        }
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

        public async Task<Response<List<SSODto.Perfiles.Response>>> GetPerfiles(string sDocumentNumber, string sLocalId)
        {
            const string METHOD_NAME = "GetPerfiles";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<List<SSODto.Perfiles.Response>>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/Perfiles";

                    var oRequest = new SSODto.Perfiles.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser =this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
                    oRequest.PersonId = sDocumentNumber;
                    oRequest.LocalId = sLocalId;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.Perfiles.Request, SSODto.SSOResponse<List<SSODto.Perfiles.Response>>>(sUrl, oRequest);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        if (oClientResponse.Content != null)
                        {
                            oResponse.IsSuccess = oClientResponse.Content.Success;
                            oResponse.Data = oClientResponse.Content.Data;
                        }
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

        public async Task<Response<SSODto.GetUserInfo.Response>> GetUserInfo(int nUserId)
        {
            const string METHOD_NAME = "GetUserInfo";

            try
            {
                string sToken = await this.AuthMiddleWare();
                if (string.IsNullOrEmpty(sToken))
                    throw new Exception($"({SERVICE_NAME}-{METHOD_NAME}): Metodo Auth devolvio un token vacio o null.");

                var oResponse = new Response<SSODto.GetUserInfo.Response>();
                oResponse.IsSuccess = false;

                using (WebApiClient oHttpClient = new WebApiClient(sToken))
                {
                    string sUrl = this._settingsServicios.MiddleWareAPI + "api/v1/sso/UserInfo";

                    var oRequest = new SSODto.GetUserInfo.Request();
                    oRequest.ApplicationId = this._settingsSSO.ApplicationId;
                    oRequest.TokenUser =this._settingsSSO.TokenUser;
                    oRequest.TokenPassword = this._settingsSSO.TokenPassword;
                    oRequest.UserId = nUserId;

                    var oClientResponse = await oHttpClient.CallPostAsync<SSODto.GetUserInfo.Request, SSODto.SSOResponse<SSODto.GetUserInfo.Response>>(sUrl, oRequest);
                    if (oClientResponse.StatusCode == HttpStatusCode.OK)
                    {
                        if (oClientResponse.Content != null)
                        {
                            oResponse.IsSuccess = oClientResponse.Content.Success;
                            oResponse.Data = oClientResponse.Content.Data;
                        }
                    }
                    else if (oClientResponse.StatusCode == HttpStatusCode.BadRequest)
                    {
                        oResponse.Message = $"({SERVICE_NAME}-{METHOD_NAME}) [400] Petición Invalida.";
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