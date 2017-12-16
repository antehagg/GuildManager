using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Server.GameEngine.AI.Combat;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.Combat.Engine
{
    public class Combat
    {
        private CharacterGroup _attackers;
        private CharacterGroup _defenders;

        private List<ICharacterObject> _combatMembers;

        private CombatOutput _combatOutput;

        private int _timer;

        public Combat(CharacterGroup attackers, CharacterGroup defenders)
        {
            _timer = 0;
            _combatOutput = new CombatOutput();
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
                    if(!c.IsAlive())
                        continue;
                    
                    var desicion = _attackers.Members.Any(m => m.Equals(c)) 
                        ? CombatDesicions.MakeDesicion(c, _attackers, _defenders, _timer) 
                        : CombatDesicions.MakeDesicion(c, _defenders, _attackers, _timer);

                    ExecuteAction(desicion, c);
                }

                _timer++;
                UpdateGroups();
            }
            CalculateStats();
        }

        private void CalculateStats()
        {
            foreach (var c in _combatMembers)
            {
                c.CombatStats.CalculateStats(_timer);
            }
        }

        private void UpdateGroups()
        {
            _attackers.UpdateGroup();
            _defenders.UpdateGroup();
        }


        private void ExecuteAction(CombatDesicion action, ICharacterObject actor)
        {
            if (action == CombatDesicion.ChangeTarget)
            {
                _combatOutput.NewLine($"{_timer} {actor.GetName()} targets {actor.Target.GetName()}");
            }
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
            actor.CombatStats.DpsStat.UpdateDamage(damage);

            _combatOutput.NewLine($"{_timer} {actor.GetName()} hits {actor.Target.GetName()} for {damage} damage");
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