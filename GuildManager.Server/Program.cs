using System;
using System.Collections.Generic;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameObjects.Characters;
using Newtonsoft.Json;
using RestSharp;
using GuildManager.Server.GameEngine.Combat.Engine;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;

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
            var vexing = new Player(dbVexing);

            client.BaseUrl = new Uri("http://guildmanagerapi.azurewebsites.net/api/playercharacter/2");
            request = new RestRequest();
            response = client.Execute(request);

            var dbCredit = JsonConvert.DeserializeObject<DbPlayerCharacter>(response.Content);
            var credit = new Player(dbCredit);

            client.BaseUrl = new Uri("http://guildmanagerapi.azurewebsites.net/api/monster/2");
            request = new RestRequest();
            response = client.Execute(request);

            var dbMonster = JsonConvert.DeserializeObject<DbMonster>(response.Content);
            var monster = new Monster(dbMonster);

            var warriorPlayer = new PlayerObject(vexing, true);
            var roguePlayer = new PlayerObject(credit, true);

            var orcPawn = new MonsterObject(monster, true);

            var playerList = new List<ICharacterObject>();
            var monsterList = new List<ICharacterObject>();

            playerList.Add(warriorPlayer);
            playerList.Add(roguePlayer);
            monsterList.Add(orcPawn);

            var attackerGroup = new CharacterGroup(playerList, warriorPlayer);
            var defenderGroup = new CharacterGroup(monsterList, orcPawn);

            var combat = new Combat(attackerGroup, defenderGroup);

            combat.StartCombat();
        }
    }
}
