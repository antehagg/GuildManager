using System;
using System.Collections.Generic;
using GuildManager.Api.Data;
using GuildManager.Api.Data.Contexts;
using GuildManager.Data.GameData.Zones;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Controllers
{
    public class ZoneController : Controller
    {
        public IServiceProvider Services;

        public ZoneController(IServiceProvider services)
        {
            Services = services;
        }

        // GET api/PlayerCharacter
        [HttpGet]
        public IEnumerable<DbZone> Get()
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var zoneContext = new ZoneContext(context);
                    return zoneContext.GetAllZones();
                }
                catch (Exception e)
                {
                    Console.WriteLine(e);
                    throw;
                }
            }
        }

        [HttpGet("{zoneId}")]
        public DbZone Zone(int zoneId)
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                try
                {
                    var zoneContext = new ZoneContext(context);
                    var zone = zoneContext.GetZoneById(zoneId);
                    return zone;
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
