using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Api.Data;
using GuildManager.Api.Data.Contexts;
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
        public IEnumerable<DbMonster> Get()
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var monsters = context.GetAllMonsters();
                    return monsters;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        // GET api/PlayerCharacter/5
        [HttpGet("{monsterId}")]
        public DbMonster Get(int monsterId)
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var monsterContext = new MonsterContext(context);
                    var monster = monsterContext.GetMonsterById(monsterId);
                    return monster;
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
