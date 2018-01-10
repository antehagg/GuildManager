using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Data.GameData.Zones;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class ZoneContext
    {
        private readonly GuildManagerContext _context;
        public ZoneContext(GuildManagerContext context)
        {
            _context = context;
        }

        public ZoneContext(IServiceProvider service)
        {
            _context = service.GetService<GuildManagerContext>();
        }

        public DbZone GetZoneById(int zoneId)
        {
            var zone = _context.Zones.Include(w => w.SpawnLocations).First(w => w.Id == zoneId);
            return zone;
        }

        public IEnumerable<DbZone> GetAllZones()
        {
            var zones = _context.Zones
                .Include(z => z.SpawnLocations)
                .ToArray();

            return zones;
        }
    }
}
