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
            // Make sure actor has valid target
            if (actor.Equals(actorGroup.MainAssist))
            {
                var target = defenderGroup.Members.First(m => m.Equals(actorGroup.MainAssist));
                if (!target.IsAlive())
                {
                    actor.Target = ChangeTarget(defenderGroup);
                }
            }
            else
            {
                if (actor.Target != actorGroup.MainAssist.Target)
                {
                    actor.Target = actorGroup.MainAssist.Target;
                    return CombatDesicion.ChangeTarget;
                }
                
            }

            return CombatDesicion.BaseAttack;
        }

        private static ICharacterObject ChangeTarget(CharacterGroup defenderGroup)
        {
            var lowestHealth =  defenderGroup.Members.Min(m => m.GetHealth());
            return defenderGroup.Members.First(m => m.GetHealth() == lowestHealth);
        }

    }

    public enum CombatDesicion { BaseAttack, ChangeTarget }
}
