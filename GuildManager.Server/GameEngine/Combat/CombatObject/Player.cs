using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Server.GameEngine.Combat.CombatObject
{
    public class Player : Actor
    {
        public PlayerCharacter PlayerCharacter;


        public Player(PlayerCharacter pc)
        {
            PlayerCharacter = pc;
            CalculateNextBaseAttack();
        }

        public void CalculateNextBaseAttack(int timer = 0)
        {
            var weapon = (DbWeapon) PlayerCharacter.EquippedItems.MainHand;
            var hasteDecimal = (100 - PlayerCharacter.Stats.Haste) / 100;
            NextBaseAttack = Convert.ToInt16(weapon.SwingSpeed * hasteDecimal * 100) + timer;
        }
    }
}
