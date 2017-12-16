using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;

namespace GuildManager.Server.GameEngine.GameObjects.Characters
{
    public class PlayerObject : ICharacterObject
    {
        public Player PlayerCharacter;
        public ICharacterObject Target { get; set; }
        public ICharacterObject TargetedBy { get; set; }
        public bool IsAttacker { get; set; }
        public bool IsMonster { get; set; }
        public int NextMainHandAttack { get; set; }
        public int NextOffHandAttack { get; set; }

        public PlayerObject(Player pc, bool isAttacker)
        {
            IsMonster = false;
            IsAttacker = isAttacker;
            PlayerCharacter = pc;
            SetNextAttack();
        }

        private void SetNextAttack()
        {

            UpdateNextMainHandAttack();
            //TODO Fix when offhand is implemented
            NextOffHandAttack = 0;
        }

        public bool IsAlive()
        {
            return PlayerCharacter.Stats.Health.CurrentValue > 0;
        }

        public void ChangeHealth(int change)
        {
            PlayerCharacter.Stats.Health.CurrentValue += change;
        }

        public void UpdateNextMainHandAttack(int timer = 0)
        {
            //TODO: Add haste
            NextMainHandAttack = Convert.ToInt32(PlayerCharacter.EquippedItems.MainHand.SwingSpeed * 100) + timer;
        }

        public int GetHealth()
        {
            return PlayerCharacter.Stats.Health.CurrentValue;
        }

        public int GetMinDamage(bool mainHand)
        {
            if (mainHand)
                return PlayerCharacter.EquippedItems.MainHand.MinDamage ;

            return PlayerCharacter.EquippedItems.MainHand.MinDamage;
        }
        public int GetMaxDamage(bool mainHand)
        {
            if (mainHand)
                return PlayerCharacter.EquippedItems.MainHand.MaxDamage;

            return PlayerCharacter.EquippedItems.MainHand.MaxDamage;
        }
    }
}
