using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public class MonsterObject : ICharacterObject
    {
        public MonsterCharacter MonsterCharacter;
        public ICharacterObject Target { get; set; }
        public ICharacterObject TargetedBy { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsMonster { get; set; }
        public CombatStats CombatStats { get; set; }
        public int NextMainHandAttack { get; set; }
        public int NextOffHandAttack { get; set; }

        public MonsterObject(MonsterCharacter monsterCharacter, bool isAttacker)
        {
            IsMonster = true;
            IsAttacker = isAttacker;
            MonsterCharacter = monsterCharacter;
            SetNextAttack();
            CombatStats = new CombatStats();
        }

        public string GetName()
        {
            return MonsterCharacter.Name;
        }

        public void SetNextAttack(int timer = 0)
        {
            UpdateNextMainHandAttack();
            NextOffHandAttack = 0;
        }

        public void UpdateNextMainHandAttack(int timer = 0)
        {
            NextMainHandAttack = 100 + timer;
        }

        public void ChangeHealth(int change)
        {
            MonsterCharacter.Health.CurrentValue += change;
        }

        public bool IsAlive()
        {
            return MonsterCharacter.Health.CurrentValue > 0;
        }

        public int GetHealth()
        {
            return MonsterCharacter.Health.CurrentValue;
        }

        public int GetMinDamage(bool mainHand)
        {
            if (mainHand)
                return 5;
            else
                return 5;
        }
        public int GetMaxDamage(bool mainHand)
        {
            if (mainHand)
                return 10;
            else
                return 10;
        }
    }
}
