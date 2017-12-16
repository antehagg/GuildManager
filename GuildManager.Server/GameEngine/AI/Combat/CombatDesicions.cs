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
            if (actor.Target == null)
            {
                if (actor.Equals(actorGroup.MainAssist))
                {
                    actor.Target = ChangeTarget(defenderGroup);
                    return CombatDesicion.ChangeTarget;
                }
                else
                {
                    if (actor.Target != actorGroup.MainAssist.Target)
                    {
                        actor.Target = actorGroup.MainAssist.Target;
                        return CombatDesicion.ChangeTarget;
                    }
                }
            }

            if (timer >= actor.NextMainHandAttack)
            {
                return CombatDesicion.MainHandBaseAttack;
            }

            return madeDdesicion;
        }

        private static ICharacterObject ChangeTarget(CharacterGroup defenderGroup)
        {
            var lowestHealth =  defenderGroup.Members.Min(m => m.GetHealth());
            return defenderGroup.Members.First(m => m.GetHealth() == lowestHealth);
        }
    }

    public enum CombatDesicion { Wait, MainHandBaseAttack, ChangeTarget }
}
