using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Characters.CharactersData;
using GuildManager.Data.GameData.Classes.GameClassData;

namespace GuildManager.Data.GameData.Characters
{
    public class DbMonster : DbCharacter
    {
        public BaseResources BaseResources { get; set; }
        public MonsterType MonsterType { get; set; }
    }
}
