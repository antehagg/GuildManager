﻿namespace GuildManager.Data.GameObjects.Characters.Stats.SpecificStat
{
    public class Health : Resource
    {
        public Health(int baseValue, int itemsValue, int buffsValue, int mainStat) : base(baseValue, itemsValue, buffsValue, mainStat)
        {
            MaxValue = baseValue + itemsValue + buffsValue + mainStat * 5;
            CurrentValue = MaxValue;
        }
    }
}
