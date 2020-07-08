using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace Transversal.Common
{
    public class WebApiClient : HttpClient
    {
        public WebApiClient()
        {
            this.InitHeaders();
        }

        public WebApiClient(string sBearerToken)
        {
            this.InitHeaders(sBearerToken);
        }

        private void InitHeaders()
        {
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        private void InitHeaders(string sBearerToken)
        {
            this.InitHeaders();
            DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", sBearerToken);
        }

        private (HttpStatusCode StatusCode, TResponse Content) ProcessResponse<TResponse>(HttpResponseMessage res)
        {
            if (res.IsSuccessStatusCode)
            {
                var s = res.Content.ReadAsStringAsync().Result;
                var response = JsonConvert.DeserializeObject<TResponse>(s);
                return (res.StatusCode, response);
            }
            else
            {
                try
                {
                    if (res.Content != null)
                    {
                        var oTmpResult = res.Content.ReadAsStringAsync();
                        if (oTmpResult != null)
                        {
                            string sResult = oTmpResult.Result;
                            if (!string.IsNullOrEmpty(sResult))
                            {
                                var oResponse = JsonConvert.DeserializeObject<TResponse>(sResult);
                                return (res.StatusCode, oResponse);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    return (res.StatusCode, default(TResponse));
                }

                return (res.StatusCode, default(TResponse));
            }
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallGetAsync<TResponse>(string url)
        {
            var res = await GetAsync(url).ConfigureAwait(false);
            return ProcessResponse<TResponse>(res);
        }
        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPostAsync<TRequest, TResponse>(string url, TRequest req)
        {
            var res = await PostAsync(url, new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return ProcessResponse<TResponse>(res);
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPutAsync<TRequest, TResponse>(string url, TRequest req)
        {
            var res = await PutAsync(url, new StringContent(JsonConvert.SerializeObject(req), Encoding.UTF8, "application/json")).ConfigureAwait(false);
            return ProcessResponse<TResponse>(res);
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallDeleteAsync<TResponse>(string url)
        {
            var res = await DeleteAsync(url).ConfigureAwait(false);
            return ProcessResponse<TResponse>(res);
        }

        public async Task<(HttpStatusCode StatusCode, TResponse Content)> CallPostFileAsync<TResponse>(string url, byte[] file, string contentName, string fileName, string mediaType, HttpContent extraContent = null, string extraName = "")
        {
            //http://stackoverflow.com/questions/16416601/c-sharp-httpclient-4-5-multipart-form-data-upload
            var requestContent = new MultipartFormDataContent();
            var imageContent = new ByteArrayContent(file);
            imageContent.Headers.ContentType = MediaTypeHeaderValue.Parse(mediaType);
            requestContent.Add(imageContent, contentName, fileName);
            if (extraContent != null)
                requestContent.Add(extraContent, extraName);
            var res = await PostAsync(url, requestContent);
            return ProcessResponse<TResponse>(res);
        }
    }
}
