using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;
using GuildManager.Server.GameEngine.GameObjects.Characters.CharacterData;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public class MonsterObject : ICharacterObject
    {
        public ICharacter Character { get; set; }
        public ICharacterObject Target { get; set; }
        public ICharacterObject TargetedBy { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsMonster { get; set; }
        public CombatStats CombatStats { get; set; }
        public Threat Threat { get; set; }
        public int NextMainHandAttack { get; set; }
        public int NextOffHandAttack { get; set; }

        public MonsterObject(ICharacter character, bool isAttacker)
        {
            IsMonster = true;
            IsAttacker = isAttacker;
            Character = character;
            SetNextAttack();
            CombatStats = new CombatStats();
            Threat = new Threat();
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

        public bool IsAlive()
        {
            return Character.GetCurrentHealth() > 0;
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

        public void UpdateCharacter()
        {
            throw new NotImplementedException();
        }
    }
}
