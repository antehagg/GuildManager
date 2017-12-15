using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Server.GameEngine.Combat.CombatObject
{
    public class PlayerObject : ICharacterObject
    {
        public Player PlayerCharacter;
        public ICharacterObject Target { get; set; }
        public ICharacterObject TargetedBy { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsMonster { get; set; }

        public PlayerObject(Player pc, bool isAttacker)
        {
            IsMonster = false;
            IsAttacker = isAttacker;
            PlayerCharacter = pc;
        }

        public bool IsAlive()
        {
            return PlayerCharacter.Stats.Health.CurrentValue > 0;
        }

        public void ChangeHealth(int change)
        {
            PlayerCharacter.Stats.Health.CurrentValue += change;
        }
    }
}
