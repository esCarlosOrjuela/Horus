using System;
using Horus.Entities;
using Horus.Interfaces;
using System.Threading.Tasks;
using System.Collections.Generic;
using Horus.Utilities.RestServices;
using Horus.Entities.AnswersService;
using Newtonsoft.Json;

namespace Horus.Services
{
    public class AutenticationUserService : IAutenticationUserService
    {
        private readonly HorusHttpClient _horusHttpClient;

        public AutenticationUserService() => _horusHttpClient = new HorusHttpClient();

        /// <summary>
        /// Method responsible for authenticating the data to start a session
        /// </summary>
        /// <param name="user">Email</param>
        /// <param name="pass">Password</param>
        /// <reference>
        /// Autor: Carlos.Orjuela | 23.Jan.2023
        /// </reference>
        public async Task<bool> UserSignIn(string user, string pass)
        {
            try
            {
                DataServiceSettings.Instance.ConfigurationParameters.UrlWebServices = "https://horuschallenges.azurewebsites.net/api/UserSignIn";
                DataServiceSettings.Instance.ConfigurationParameters.HttMethod = ConfigurationParameters.TypeHttMethod.POST;
                DataServiceSettings.Instance.DataServices = new UserAutentication() { Email = user, Password = pass };
                var serviceResponse = await _horusHttpClient.ExecuteApi(DataServiceSettings.Instance);

                if (!string.IsNullOrEmpty(serviceResponse))
                {
                    var userProfile = JsonConvert.DeserializeObject<UserProfileResponse>(serviceResponse);
                    App.Current.Properties["UserAuthorization"] = userProfile.authorizationToken;

                    if (!string.IsNullOrEmpty(userProfile.authorizationToken))
                        return true;
                    else
                        return false;
                }
                else
                    throw new ArgumentNullException("Respuesta del servicio no válida");
            }
            catch (Exception Exception)
            {
                throw Exception;
            }

        }

    }
}

