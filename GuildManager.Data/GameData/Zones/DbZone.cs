using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameData.Zones
{
    public class DbZone
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public ZoneType ZoneType { get; set; }
        public List<DbSpawn> SpawnLocations { get; set; }
    }

    public enum ZoneType { Indoor, Outdoor}
}
