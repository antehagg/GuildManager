using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameObjects.Characters.Stats;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;

namespace GuildManager.Data.GameObjects.Characters
{
    public class MonsterCharacter : Character
    {
        public Resource Health { get; set; }
        public Resource Energy { get; set; }

        public MonsterCharacter(DbMonster monsterInfo)
        {
            Id = monsterInfo.Id;
            Name = monsterInfo.Name;
            Class = monsterInfo.Class;
            CalculateResource();
        }

        public void CalculateResource()
        {
            Health = new Health(200, 0, 0, 0);
            Energy = new Energy(100, 0, 0, 0);
        }
    }

}
