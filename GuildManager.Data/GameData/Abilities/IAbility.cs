using System.Collections.Generic;

namespace GuildManager.Data.GameData.Abilities
{
    public interface IAbility
    {
        int Id { get; set; }
        string Name { get; set; }
        int Cost { get; set; }
        int Cooldown { get; set; }
        int CastTime { get; set; }
        List<Effect> Effects { get; set; }

        bool OnCoolDown();
        void UseSkill();
        void LowerCoolDownOne();
    }
}
