using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Server.GameEngine.Combat.CombatObject
{
    public class Monster : Actor
    {
        public MonsterCharacter MonsterCharacter;

        public Monster(MonsterCharacter monsterCharacter, bool isAttacker)
        {
            IsMonster = true;
            IsAttacker = isAttacker;
            MonsterCharacter = monsterCharacter;
            CalculateNextBaseAttack();
        }

        public void ChangeHealth(int change)
        {
            MonsterCharacter.Health.CurrentValue += change;

            if (MonsterCharacter.Health.CurrentValue <= 0)
                IsAlive = false;
        }

        public void CalculateNextBaseAttack(int timer = 0)
        {
            NextBaseAttack = 100 + timer;
        }
    }
}
