using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameObjects.Characters.Stats.SpecificStat
{
    public class Energy : Resource
    {
        public Energy(int baseValue, int itemsValue, int buffsValue, int mainStat) : base(baseValue, itemsValue, buffsValue, mainStat)
        {
            MaxValue = baseValue + itemsValue + buffsValue + mainStat;
            CurrentValue = MaxValue;
        }
    }
}
