using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public interface ICharacterObject
    {
        ICharacterObject Target { get; set; }
        ICharacterObject TargetedBy { get; set; }
        bool IsAttacker { get; set; }
        bool IsMonster { get; set; }

        int GetMinDamage(bool mainHand);
        int GetMaxDamage(bool mainHand);

        bool IsAlive();

        int GetHealth();
        void ChangeHealth(int change);
    }
}
