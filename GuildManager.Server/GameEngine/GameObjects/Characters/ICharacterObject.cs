using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;
using GuildManager.Server.GameEngine.GameObjects.Characters.CharacterData;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public interface ICharacterObject
    {
        ICharacter Character { get; set; }
        ICharacterObject Target { get; set; }
        ICharacterObject TargetedBy { get; set; }
        bool IsAttacker { get; set; }
        bool IsMonster { get; set; }
        CombatStats CombatStats { get; set; }
        Threat Threat { get; set; }

        int NextMainHandAttack { get; set; }
        int NextOffHandAttack { get; set; }

        int GetMinDamage(bool mainHand);
        int GetMaxDamage(bool mainHand);

        bool IsAlive();

        void UpdateNextMainHandAttack(int timer = 0);

        void UpdateCharacter();
    }
}
