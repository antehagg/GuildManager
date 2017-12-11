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
    public class PlayerCharacterController : Controller
    {
        public IServiceProvider Services;

        public PlayerCharacterController(IServiceProvider services)
        {
            Services = services;
        }

        // GET api/PlayerCharacter
        [HttpGet]
        public IEnumerable<DbPlayerCharacter> Get()
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var players = context.GetAllPlayers();
                    return players;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        // GET api/PlayerCharacter/5
        [HttpGet("{playerId}")]
        public DbPlayerCharacter Get(int playerId)
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var player = context.GetPlayerById(playerId);
                    return player;
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
