using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestSharp;

namespace GuildManager.Editor.ApiCalls
{
    public class BaseApiCall
    {
        protected RestClient Client;
        private string _baseUrl = "https://guildmanagerapi.azurewebsites.net/";
        public BaseApiCall()
        {
            Client = new RestClient {BaseUrl = new Uri(_baseUrl)};
        }
    }
}
