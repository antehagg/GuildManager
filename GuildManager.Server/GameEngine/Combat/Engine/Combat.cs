using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Server.GameEngine.AI.Combat;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;

namespace GuildManager.Server.GameEngine.Combat.Engine
{
    public class Combat
    {
        private CharacterGroup _attackers;
        private CharacterGroup _defenders;

        private List<ICharacterObject> _combatMembers;

        private int _timer;

        public Combat(CharacterGroup attackers, CharacterGroup defenders)
        {
            _timer = 0;
            _attackers = attackers;
            _defenders = defenders;

            _combatMembers = new List<ICharacterObject>();

            _combatMembers.AddRange(_attackers.Members);
            _combatMembers.AddRange(_defenders.Members);
        }

        public void StartCombat()
        {
            while (TeamsAlive())
            {
                foreach (var c in _combatMembers)
                {
                    var desicion = _attackers.Members.Any(m => m.Equals(c)) 
                        ? CombatDesicions.MakeDesicion(c, _attackers, _defenders, _timer) 
                        : CombatDesicions.MakeDesicion(c, _defenders, _attackers, _timer);

                    ExecuteAction(desicion, c);
                }

                _timer++;
                UpdateGroups();
            }
        }

        private void UpdateGroups()
        {
            _attackers.UpdateGroup();
            _defenders.UpdateGroup();
        }


        private void ExecuteAction(CombatDesicion action, ICharacterObject actor)
        {
            if (action == CombatDesicion.MainHandBaseAttack)
            {
                MakeBaseAttack(actor, CombatDesicion.MainHandBaseAttack);
                actor.UpdateNextMainHandAttack(_timer);
            }
        }

        private void MakeBaseAttack(ICharacterObject actor, CombatDesicion attackHand)
        {
            var min = actor.GetMinDamage(true);
            var max = actor.GetMaxDamage(true);
            var random = new Random();

            var damage = random.Next(min, max);
            actor.Target.ChangeHealth(-damage);
        }

        private bool TeamsAlive()
        {
            var attackersDead = _attackers.IsDead;
            var defendersDead = _defenders.IsDead;

            if (attackersDead || defendersDead)
                return false;

            return true;
        }
    }
}