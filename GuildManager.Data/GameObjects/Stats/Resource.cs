using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameObjects.Stats
{
    public class Resource
    {
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }

        public Resource(int baseValue, int itemsValue, int buffsValue, int statValue)
        {
            var maxValue = baseValue + itemsValue + buffsValue + statValue*5;
            MaxValue = maxValue;
            SetCurrentValue(maxValue);
        }

        private void SetCurrentValue(int value)
        {
            CurrentValue = value;
        }
    }
}
