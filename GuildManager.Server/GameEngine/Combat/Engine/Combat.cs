﻿using System;
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
        private List<Actor> _attackers;
        private List<Actor> _defenders;

        private List<Actor> _combatMembers;

        private int _timer;

        public Combat(List<Actor> attackers, List<Actor> defenders)
        {
            _timer = 0;
            _attackers = attackers;
            _defenders = defenders;

            _combatMembers = new List<Actor>();

            _combatMembers.AddRange(_attackers);
            _combatMembers.AddRange(_defenders);
        }

        public void StartCombat()
        {
            while (TeamsAlive())
            {

            }
        }

        private bool TeamsAlive()
        {
            var playersAlive = _attackers.Where(a => a.IsAlive).ToList().Count;
            var monstersAlive = _defenders.Where(a => a.IsAlive).ToList().Count;

            if (playersAlive <= 0 && monstersAlive <= 0)
                return true;

            return false;
        }
    }
}
