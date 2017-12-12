using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameObjects.Characters;
using Newtonsoft.Json;
using RestSharp;
using GuildManager.Server.GameEngine.Combat.CombatObject;
using GuildManager.Server.GameEngine.Combat.Engine;

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

            var dbVexing = JsonConvert.DeserializeObject<DbPlayerCharacter>(response.Content);
            var vexing = new PlayerCharacter(dbVexing);

            client.BaseUrl = new Uri("http://guildmanagerapi.azurewebsites.net/api/playercharacter/2");
            request = new RestRequest();
            response = client.Execute(request);

            var dbCredit = JsonConvert.DeserializeObject<DbPlayerCharacter>(response.Content);
            var credit = new PlayerCharacter(dbCredit);

            client.BaseUrl = new Uri("http://guildmanagerapi.azurewebsites.net/api/monster/2");
            request = new RestRequest();
            response = client.Execute(request);

            var dbMonster = JsonConvert.DeserializeObject<DbMonster>(response.Content);
            var monster = new MonsterCharacter(dbMonster);

            var warriorPlayer = new Player(vexing, true);
            var roguePlayer = new Player(credit, true);

            var orcPawn = new Monster(monster, true);

            var playerList = new List<Actor>();
            var monsterList = new List<Actor>();

            playerList.Add(warriorPlayer);
            playerList.Add(roguePlayer);
            monsterList.Add(orcPawn);

            var combat = new Combat(playerList, monsterList);
        }
    }
}
