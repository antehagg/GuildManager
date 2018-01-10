using System.Collections.Generic;

namespace GuildManager.Data.GameData.Abilities
{
    public class Effect
    {
        public int Id { get; set; }
        public EffectType Type { get; set; }
        public int Duration { get; set; }
        public TargetType TargetType { get; set; }

    }

    public enum EffectType { DirectDamage, DirectThreat, Buff }
    public enum TargetType { Aoe, Single }
}
