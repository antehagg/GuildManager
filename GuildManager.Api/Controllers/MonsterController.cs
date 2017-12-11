using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Api.Data;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameObjects.Characters;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Controllers
{
    [Route("api/[controller]")]
    public class MonsterController : Controller
    {
        public IServiceProvider Services;

        public MonsterController(IServiceProvider services)
        {
            Services = services;
        }

        // GET api/PlayerCharacter
        [HttpGet]
        public IEnumerable<MonsterCharacter> Get()
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var monsters = new List<MonsterCharacter>();
                    var monsterInfo = context.GetAllMonsters();

                    foreach (var m in monsterInfo)
                    {
                        var monster = new MonsterCharacter(m);
                        monsters.Add(monster);
                    }

                    return monsters;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }
    }
}
