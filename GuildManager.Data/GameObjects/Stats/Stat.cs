using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Data.GameObjects.Stats
{
    public class Stat
    {
        public int MaxValue { get; set; }
        public int CurrentValue { get; set; }

        public Stat(int baseValue, int itemsValue, int buffsValue)
        {
            var maxValue = baseValue + itemsValue + buffsValue;
            MaxValue = maxValue;
            SetCurrentValue(maxValue);
        }

        private void SetCurrentValue(int value)
        {
            CurrentValue = value;
        }
    }
}
