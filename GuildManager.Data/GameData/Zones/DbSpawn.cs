using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Characters;

namespace GuildManager.Data.GameData.Zones
{
    public class DbSpawn
    {
        public int Id { get; set; }
        public int SpawnNo { get; set; }
        public int SpawnAmount { get; set; }
        public List<DbMonster> TrashMonsters { get; set; }
        public List<DbMonster> NamedMonsters { get; set; }
    }
}
