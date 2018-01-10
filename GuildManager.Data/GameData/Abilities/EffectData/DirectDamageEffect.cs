using System;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Data.GameData.Abilities.EffectData
{
    public class DirectDamageEffect : Effect
    {
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
        public double BonusDamage { get; set; }
        public double CritChance { get; set; }
    }
}
