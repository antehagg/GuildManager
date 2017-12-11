using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameObjects.Characters;
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
                BaseUrl = new Uri("http://guildmanagerapi.azurewebsites.net/api/playercharacter/1")
            };

            var request = new RestRequest();
            var response = client.Execute(request);

            var player = JsonConvert.DeserializeObject<DbPlayerCharacter>(response.Content);
        }
    }
}
