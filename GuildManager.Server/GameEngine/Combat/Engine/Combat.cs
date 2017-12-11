using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Server.GameEngine.Combat.CombatObject;

namespace GuildManager.Server.GameEngine.Combat.Engine
{
    public class Combat
    {
        private List<Player> _players;
        private List<Monster> _monsters;

        private int _timer;

        public Combat(List<Player> players, List<Monster> monsters)
        {
            _timer = 0;
            _players = players;
            _monsters = monsters;
            
        }

        public void StartCombat()
        {
            while (TeamsAlive())
            {
                var playerAttackers = _players.Where(p => p.NextBaseAttack == _timer).ToList();
                var monsterAttackers = _monsters.Where(p => p.NextBaseAttack == _timer).ToList();

                foreach (var p in playerAttackers)
                {
                    var rand = new Random();
                    var weapon = (DbWeapon) p.PlayerCharacter.EquippedItems.MainHand;
                    var damage = rand.Next(weapon.MaxDamage, weapon.MinDamage);

                    p.SetTarget(_monsters.First(m => m.IsAlive));
                    var target = (Monster) p.Target;
                    target.ChangeHealth(-damage);
                }
            }
        }

        private bool TeamsAlive()
        {
            var playersAlive = _players.Where(a => a.IsAlive).ToList().Count;
            var monstersAlive = _monsters.Where(a => a.IsAlive).ToList().Count;

            if (playersAlive <= 0 && monstersAlive <= 0)
                return true;

            return false;
        }
    }
}
