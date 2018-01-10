using System.Collections.Generic;

namespace GuildManager.Data.GameData.Abilities
{
    public class Skill : IAbility
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Cooldown { get; set; }
        public int CastTime { get; set; }
        public List<Effect> Effects { get; set; }
        private int _cooldownRemaining;

        public void UseSkill()
        {
            _cooldownRemaining = Cooldown;
        }

        public void LowerCoolDownOne()
        {
            if(_cooldownRemaining != 0)
                _cooldownRemaining -= 1;
        }

        public bool OnCoolDown()
        {
            return _cooldownRemaining != 0;
        }
    }
}
