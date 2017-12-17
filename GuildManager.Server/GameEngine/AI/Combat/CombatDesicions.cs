using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;

namespace GuildManager.Server.GameEngine.AI.Combat
{
    public static class CombatDesicions
    {
        public static CombatDesicion MakeDesicion(ICharacterObject actor, CharacterGroup actorGroup, CharacterGroup defenderGroup, int timer)
        {
            var madeDdesicion = CombatDesicion.Wait;
            // Make sure actor has valid target
            if (ShouldChangeTarget(actor, actorGroup, defenderGroup))
            {
                return CombatDesicion.ChangeTarget;
            }

            if (timer >= actor.NextMainHandAttack)
            {
                return CombatDesicion.MainHandBaseAttack;
            }

            return madeDdesicion;
        }

        private static bool ShouldChangeTarget(ICharacterObject actor, CharacterGroup actorGroup, CharacterGroup defenderGroup)
        {
            if (actor.Target == null)
            {
                if (actor.Equals(actorGroup.MainAssist))
                {
                    actor.Target = ChangeTarget(actor, defenderGroup);
                    return true;
                }

                if (actor.Target != actorGroup.MainAssist.Target)
                {
                    actor.Target = actorGroup.MainAssist.Target;
                    return true;
                }
            }
            else
            {
                // Check if monster change target because of threat
                if (actor.GetType() == typeof(MonsterObject))
                {
                    if (actor.Threat.ThreatList.Keys.First().Equals(actor.Target))
                        return false;

                    actor.Target = ChangeTarget(actor, defenderGroup);
                    return true;
                }

                if (actor.Target != actorGroup.MainAssist.Target)
                {
                    actor.Target = actorGroup.MainAssist.Target;
                    return true;
                }
            }
            
            return false;
        }

        private static ICharacterObject ChangeTarget(ICharacterObject actor, CharacterGroup defenderGroup)
        {
            if (actor.GetType() == typeof(MonsterObject))
            {
                return actor.Threat.ThreatList.Keys.First();
            }

            var lowestHealth =  defenderGroup.Members.Min(m => m.Character.GetCurrentHealth());
            return defenderGroup.Members.First(m => m.Character.GetCurrentHealth() == lowestHealth);
        }
    }

    public enum CombatDesicion { Wait, MainHandBaseAttack, ChangeTarget }
}
