using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Horus.Entities;
using Horus.Entities.AnswersService;
using Horus.Interfaces;
using Horus.MVVM.Model;
using Horus.Utilities.RestServices;
using Newtonsoft.Json;

namespace Horus.Services
{
    public class ChallengesService : IChallengesService
    {
        private readonly HorusHttpClient _horusHttpClient;
        private readonly string _userAuthorization;

        public ChallengesService()
        {
            _horusHttpClient = new HorusHttpClient();

            if (App.Current.Properties.ContainsKey("UserAuthorization"))
                _userAuthorization = App.Current.Properties["UserAuthorization"].ToString();
            else
                throw new Exception("Contenido solo visible a usuarios registrados");

        }

        public async Task<List<ChallengeModel>> GetChallenges()
        {
            try
            {
                DataServiceSettings.Instance.ConfigurationParameters.UrlWebServices = "https://horuschallenges.azurewebsites.net/api/Challenges";
                DataServiceSettings.Instance.ConfigurationParameters.HttMethod = ConfigurationParameters.TypeHttMethod.GET;
                DataServiceSettings.Instance.ConfigurationParameters.RequestHeaders = new Dictionary<string, string>();
                DataServiceSettings.Instance.ConfigurationParameters.RequestHeaders.Add("Authorization", _userAuthorization);
                var serviceResponse = await _horusHttpClient.ExecuteApi(DataServiceSettings.Instance);

                if (!string.IsNullOrEmpty(serviceResponse))
                {
                    var challengesResponse = JsonConvert.DeserializeObject<List<ChallengeResponse>>(serviceResponse);

                    if (!challengesResponse.Any())
                        return null;

                    var collectionChallenges = new List<ChallengeModel>();
                    challengesResponse.ForEach(x => collectionChallenges.Add((ChallengeModel)x));
                    return collectionChallenges;
                }
                else
                    throw new ArgumentNullException($"Respuesta del servicio no válida");
            }
            catch (Exception Exception)
            {
                throw Exception;
            }
        }
    }
}

