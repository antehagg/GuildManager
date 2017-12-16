using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public interface ICharacterObject
    {
        ICharacterObject Target { get; set; }
        ICharacterObject TargetedBy { get; set; }
        bool IsAttacker { get; set; }
        bool IsMonster { get; set; }
        CombatStats CombatStats { get; set; }

        int NextMainHandAttack { get; set; }
        int NextOffHandAttack { get; set; }

        int GetMinDamage(bool mainHand);
        int GetMaxDamage(bool mainHand);

        bool IsAlive();

        string GetName();
        int GetHealth();
        void ChangeHealth(int change);

        void UpdateNextMainHandAttack(int timer = 0);
    }
}
