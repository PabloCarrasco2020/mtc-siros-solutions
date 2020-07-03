using System;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Application.Interface;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using Transversal.Common;

namespace Application.Core
{
    public class SSOApplication:ISSOApplication
    {
        private readonly IConfiguration _configuration;


        public SSOApplication(IConfiguration configuration)
        {
            this._configuration = configuration;
        }

        public async Task<string> AuthMiddleWare()
        {
            try
            {
                string token = string.Empty;
                var httpClient = new HttpClient();
                var requestBody = new
                {
                    Username = _configuration.GetSection("CredencialesMiddleWare").GetSection("TokenUser").Value,
                    Password = _configuration.GetSection("CredencialesMiddleWare").GetSection("TokenPassword").Value
                };
                var contentRequest = new StringContent(
                    JsonConvert.SerializeObject(requestBody),
                    Encoding.UTF8,
                    "application/json");

                httpClient.BaseAddress = new Uri(_configuration.GetSection("Servicios").GetSection("MiddleWareAPI").Value);
                var urlMetodoValidacion = "api/v1/seguridad/authenticate";
                var resultApiService = await httpClient.PostAsync(urlMetodoValidacion, contentRequest);
                if (resultApiService.IsSuccessStatusCode)
                {
                    var readResultado = await resultApiService.Content.ReadAsStringAsync();
                    token = JsonConvert.DeserializeObject<String>(readResultado);
                }
                return token;
            }
            catch (Exception ex)
            {
                throw new Exception("(MiddleWareAPI) : " + ex.Message);
            }
        }

        public async Task<Response<int>> Login(string headerToken, string userName, string userPassword)
        {
            try
            {
                var responseLogin = new Response<int>();
                var httpClient = new HttpClient();
                var requestBody = new
                {
                    ApplicationId = _configuration.GetSection("CredencialesSSO").GetSection("ApplicationId").Value,
                    TokenUser = _configuration.GetSection("CredencialesSSO").GetSection("TokenUser").Value,
                    TokenPassword = _configuration.GetSection("CredencialesSSO").GetSection("TokenPassword").Value,
                    UserName = userName,
                    UserPassword = userPassword
                };
                var contentRequest = new StringContent(
                    JsonConvert.SerializeObject(requestBody),
                    Encoding.UTF8,
                    "application/json");

                httpClient.BaseAddress = new Uri(_configuration.GetSection("Servicios").GetSection("MiddleWareAPI").Value);
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", headerToken);

                var urlMetodoValidacion = "api/v1/sso/Login";
                var resultApiService = await httpClient.PostAsync(urlMetodoValidacion, contentRequest);
                if (!resultApiService.IsSuccessStatusCode)
                {
                    throw new Exception("IsNotSuccessStatusCode: "+ resultApiService.StatusCode);
                }
                var readResultado = await resultApiService.Content.ReadAsStringAsync();
                var ssoModel = JsonConvert.DeserializeObject<ResultModel>(readResultado);
                if (!ssoModel.Success)
                {
                    // vemos que hacemos
                    responseLogin.Message = ssoModel.Message;
                    return responseLogin;
                }
                responseLogin.IsSuccess = true;
                responseLogin.Data = ssoModel.Data.IdUsuario;
                return responseLogin;
            }
            catch (Exception ex)
            {
                throw new Exception("(MiddleWareAPI) : " + ex.Message);
            }
           
        }

    }


    #region SSO Model

    public class ResultModel
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public UsuarioSSO Data { get; set; }
    }

    public class UsuarioSSO
    {
        public int IdUsuario { get; set; }
    }

    #endregion

}