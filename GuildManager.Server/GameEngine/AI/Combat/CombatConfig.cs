using System.Collections.Generic;
using GuildManager.Data.GameData.Abilities;

namespace GuildManager.Server.GameEngine.AI.Combat
{
    public class CombatConfig
    {
        public List<Skill> PriorityList;

        public CombatConfig(List<Skill> priorityList)
        {
            PriorityList = priorityList;
        }
    }
}
