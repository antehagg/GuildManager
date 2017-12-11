using System;
using GuildManager.Data.GameData.Characters;
using Newtonsoft.Json;
using RestSharp;

namespace GuildManager.Server
{
    class Program
    {
        static void Main(string[] args)
        {
            var client = new RestClient
            {
                BaseUrl = new Uri("http://guildmanagerapi.azurewebsites.net/api/playercharacter")
            };

            var request = new RestRequest();
            var response = client.Execute(request);
        }
    }
}
