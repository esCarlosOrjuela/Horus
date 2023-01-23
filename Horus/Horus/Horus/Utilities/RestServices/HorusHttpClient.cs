using System;
using Horus.Entities;
using System.Threading.Tasks;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using static Horus.Entities.ConfigurationParameters;
using Newtonsoft.Json;
using StoreKit;

namespace Horus.Utilities.RestServices
{
    public class HorusHttpClient
    {
        /// <summary>
        /// Method in charge of sending a request to an API according to the technical specifications
        /// </summary>
        /// <param name="dataServiceSettings">Technical specifications</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public async Task<string> ExecuteApi(DataServiceSettings dataServiceSettings)
        {
            try
            {
                Uri uri = new Uri(dataServiceSettings.ConfigurationParameters.UrlWebServices);

                using (var httpClient = new HttpClient())
                {
                    httpClient.Timeout = new TimeSpan(0, 0, 5);
                    httpClient.DefaultRequestHeaders.Accept.Clear();
                    httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    if (dataServiceSettings.ConfigurationParameters.RequestHeaders?.Count > 0)
                        foreach (var header in dataServiceSettings.ConfigurationParameters.RequestHeaders)
                            httpClient.DefaultRequestHeaders.Add(header.Key, header.Value);



                    var httpResponseMessage = await GethttpResponseMessage(httpClient, dataServiceSettings);

                    if (httpResponseMessage.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                        throw new Exception("Estimado usuario carece de credenciales de autenticación válidas. Por favor validelos e intentelo nuevamente");

                    // on error throw a exception  
                    httpResponseMessage.EnsureSuccessStatusCode();

                    string responseString = await httpResponseMessage.Content.ReadAsStringAsync();
                    return responseString;
                }
            }
            catch (Exception Exception)
            {
                throw Exception;
            }


        }

        /// <summary>
        /// Method that gets the response from the api
        /// </summary>
        /// <param name="httpClient"></param>
        /// <param name="webServiceSettings"></param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        private async Task<HttpResponseMessage> GethttpResponseMessage(HttpClient httpClient, DataServiceSettings webServiceSettings)
        {
            HttpResponseMessage httpResponseMessage = null;
            switch (webServiceSettings.ConfigurationParameters.HttMethod)
            {
                case TypeHttMethod.GET:
                    httpResponseMessage = await httpClient.GetAsync(webServiceSettings.ConfigurationParameters.UrlWebServices);
                    break;
                case TypeHttMethod.POST:
                    var json = JsonConvert.SerializeObject(webServiceSettings.DataServices);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");
                    httpResponseMessage = await httpClient.PostAsync(webServiceSettings.ConfigurationParameters.UrlWebServices, content);
                    break;
            }
            return httpResponseMessage;
        }
    }
}

