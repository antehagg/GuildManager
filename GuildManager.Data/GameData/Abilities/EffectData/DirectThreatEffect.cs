using System;

namespace GuildManager.Data.GameData.Abilities.EffectData
{
    public class DirectThreatEffect : Effect
    {
        public int MinThreat { get; set; }
        public int MaxThreat { get; set; }
        public double BonusThreat { get; set; }
    }
}
