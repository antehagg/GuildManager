using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Classes;

namespace GuildManager.Data.GameObjects.Characters
{
    public class Character
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DbGamelass Class { get; set; }
    }
}
