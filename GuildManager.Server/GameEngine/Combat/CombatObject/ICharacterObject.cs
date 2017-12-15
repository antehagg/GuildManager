using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Server.GameEngine.Combat.CombatObject
{
    public interface ICharacterObject
    {
        ICharacterObject Target { get; set; }
        ICharacterObject TargetedBy { get; set; }
        bool IsAttacker { get; set; }
        bool IsMonster { get; set; }

        bool IsAlive();
    }
}
