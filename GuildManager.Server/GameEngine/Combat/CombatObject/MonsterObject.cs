using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Server.GameEngine.Combat.CombatObject
{
    public class MonsterObject : ICharacterObject
    {
        public MonsterCharacter MonsterCharacter;
        public ICharacterObject Target { get; set; }
        public ICharacterObject TargetedBy { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsMonster { get; set; }

        public MonsterObject(MonsterCharacter monsterCharacter, bool isAttacker)
        {
            IsMonster = true;
            IsAttacker = isAttacker;
            MonsterCharacter = monsterCharacter;
        }

        public void ChangeHealth(int change)
        {
            MonsterCharacter.Health.CurrentValue += change;
        }

        public bool IsAlive()
        {
            return MonsterCharacter.Health.CurrentValue > 0;
        }
    }
}
