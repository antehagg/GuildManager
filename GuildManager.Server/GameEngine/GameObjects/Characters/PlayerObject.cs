using System;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Server.GameEngine.AI.Combat;
using GuildManager.Server.GameEngine.GameObjects.Characters.CharacterData;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public class PlayerObject : ICharacterObject
    {
        public ICharacter Character { get; set; }
        public ICharacterObject Target { get; set; }
        public ICharacterObject TargetedBy { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsMonster { get; set; }
        public CombatStats CombatStats { get; set; }
        public Threat Threat { get; set; }
        public CombatConfig CombatConfig { get; set; }
        public int NextMainHandAttack { get; set; }
        public int NextOffHandAttack { get; set; }
        public IAbility AbilityToUse { get; set; }

        public PlayerObject(ICharacter pc, bool isAttacker)
        {
            IsMonster = false;
            IsAttacker = isAttacker;
            Character = pc;
            SetNextAttack();
            CombatStats = new CombatStats();
            Threat = new Threat();
        }

        private void SetNextAttack()
        {

            UpdateNextMainHandAttack();
            //TODO Fix when offhand is implemented
            NextOffHandAttack = 0;
        }

        public bool IsAlive()
        {
            return Character.GetCurrentHealth() > 0;
        }

        public void UpdateNextMainHandAttack(int timer = 0)
        {
            //TODO: Add haste
            NextMainHandAttack = Convert.ToInt32(Character.EquippedItems.MainHand.SwingSpeed * 100) + timer;
        }

        public void UpdateCharacter()
        {
            UpdateCooldowns();
        }

        private void UpdateCooldowns()
        {
            foreach (var a in Character.Class.Skills)
            {
                a.LowerCoolDownOne();
            }
        }

        public int GetMinDamage(bool mainHand)
        {
            if (mainHand)
                return Character.EquippedItems.MainHand.MinDamage ;

            return Character.EquippedItems.MainHand.MinDamage;
        }
        public int GetMaxDamage(bool mainHand)
        {
            if (mainHand)
                return Character.EquippedItems.MainHand.MaxDamage;

            return Character.EquippedItems.MainHand.MaxDamage;
        }
    }
}
