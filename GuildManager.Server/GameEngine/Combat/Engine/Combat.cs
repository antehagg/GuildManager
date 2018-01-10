using System;
using System.Collections.Generic;
using System.Linq;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameData.Abilities.EffectData;
using GuildManager.Server.GameEngine.AI.Combat;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;
using GuildManager.Server.GameEngine.Helpers.Rng;
using GuildManager.Server.GameEngine.Output.Combat;

namespace GuildManager.Server.GameEngine.Combat.Engine
{
    public class Combat
    {
        public CharacterGroup Attackers;
        public CharacterGroup Defenders;

        public List<ICharacterObject> CombatMembers;

        public CombatOutput CombatOutput;

        private int _timer;

        public Combat(CharacterGroup attackers, CharacterGroup defenders)
        {
            _timer = 0;
            CombatOutput = new CombatOutput();
            Attackers = attackers;
            Defenders = defenders;

            CombatMembers = new List<ICharacterObject>();

            CombatMembers.AddRange(Attackers.Members);
            CombatMembers.AddRange(Defenders.Members);
            SetInitialThreat();
        }

        public void StartCombat()
        {
            while (TeamsAlive())
            {
                foreach (var c in CombatMembers)
                {
                    if(!c.IsAlive())
                        continue;
                    
                    var desicion = Attackers.Members.Any(m => m.Equals(c)) 
                        ? CombatDesicions.MakeDesicion(c, Attackers, Defenders, _timer) 
                        : CombatDesicions.MakeDesicion(c, Defenders, Attackers, _timer);

                    ExecuteAction(desicion, c);
                }

                _timer++;
                UpdateGroups();
            }
            CalculateStats();
        }

        private void SetInitialThreat()
        {
            // Assume MainAssist is pulling and get more initial threat
            foreach (var a in Attackers.Members)
            {
                foreach (var d in Defenders.Members)
                {
                    a.Threat.ThreatList.Add(d, Attackers.MainAssist.Equals(d) ? 2 : 1);
                }
            }

            foreach (var d in Defenders.Members)
            {
                foreach (var a in Attackers.Members)
                {
                    d.Threat.ThreatList.Add(a, Attackers.MainAssist.Equals(a) ? 2 : 1);
                }
            }
        }

        private void CalculateStats()
        {
            foreach (var c in CombatMembers)
            {
                c.CombatStats.CalculateStats(_timer);
            }
        }

        private void UpdateGroups()
        {
            Attackers.UpdateGroup();
            Defenders.UpdateGroup();
        }


        private void ExecuteAction(CombatDesicion action, ICharacterObject actor)
        {
            if (action == CombatDesicion.ChangeTarget)
            {
                CombatOutput.NewLine($"{_timer} {actor.Character.Name} targets {actor.Target.Character.Name}");
            }
            if (action == CombatDesicion.MainHandBaseAttack)
            {
                MakeBaseAttack(actor, CombatDesicion.MainHandBaseAttack);
                actor.UpdateNextMainHandAttack(_timer);
            }
            if (action == CombatDesicion.UseSKill)
            {
                ExecuteSkill(actor);
            }
        }

        private void ExecuteSkill(ICharacterObject actor)
        {
            var skill = actor.AbilityToUse;
            foreach (var e in skill.Effects)
            {
                ApplyEffect(actor, e);
            }
            actor.AbilityToUse.UseSkill();
        }

        private void ApplyEffect(ICharacterObject actor, Effect e)
        {
            switch (e.Type)
            {
                case EffectType.DirectThreat:
                {
                    var te = (DirectThreatEffect)e;
                    var threat = Dice.Roll(te.MinThreat, te.MaxThreat);
                    var targets = GetTargets(actor, e);

                    foreach (var t in targets)
                    {
                        t.Threat.ChangeThreat(actor, threat);

                        CombatOutput.NewLine(
                            $"{_timer} {actor.Character.Name} {actor.AbilityToUse.Name} {t.Character.Name}");
                    }
                }
                    break;
                case EffectType.DirectDamage:
                {
                    var de = (DirectDamageEffect)e;
                    var min = actor.GetMinDamage(true);
                    var max = actor.GetMaxDamage(true);
                    var targets = GetTargets(actor, e);

                    foreach (var t in targets)
                    {
                        var damage = 0;
                        damage = CalculateDamage(min, max, actor.Character.Stats.CritChance);
                        
                        t.Character.ChangeCurrentHealth(-damage);
                        actor.CombatStats.DpsStat.UpdateDamage(damage);
                        t.Threat.ChangeThreat(actor, damage);

                        CombatOutput.NewLine(
                            $"{_timer} {actor.Character.Name} {actor.AbilityToUse.Name} {t.Character.Name} for {damage} damage");
                    }
                }
                    break;
            }
        }

        private void MakeBaseAttack(ICharacterObject actor, CombatDesicion attackHand)
        {
            var min = actor.GetMinDamage(true);
            var max = actor.GetMaxDamage(true);
           
            var damage = CalculateDamage(min, max, actor.Character.Stats.CritChance);
            actor.Target.Character.ChangeCurrentHealth(-damage);
            actor.CombatStats.DpsStat.UpdateDamage(damage);
            actor.Target.Threat.ChangeThreat(actor, damage);

            CombatOutput.NewLine($"{_timer} {actor.Character.Name} hits {actor.Target.Character.Name} for {damage} damage");
        }

        private int CalculateDamage(int minDamage, int maxDamage, double critChance, int critBonusDamage = 2)
        {
            var damage = Dice.Roll(minDamage, maxDamage);
            var critRoll = Dice.Roll(0, 100);

            if (critRoll <= critChance)
                damage *= critBonusDamage;

            return damage;
        }

        private bool TeamsAlive()
        {
            var attackersDead = Attackers.IsDead;
            var defendersDead = Defenders.IsDead;

            if (attackersDead || defendersDead)
                return false;

            return true;
        }

        private List<ICharacterObject> GetTargets(ICharacterObject actor, Effect effect)
        {
            var targets = new List<ICharacterObject>();
            if (effect.TargetType == TargetType.Single)
            {
                targets.Add(actor.Target);
            }
            else
            {
                targets = GetOpponentGroup(actor);
            }

            return targets;
        }

        private List<ICharacterObject> GetOpponentGroup(ICharacterObject actor)
        {
            var targets = new List<ICharacterObject>();
            targets.AddRange(actor.IsAttacker ? Defenders.Members : Attackers.Members);

            return targets;
        }
    }
}