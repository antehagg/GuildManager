using System.Linq;
using GuildManager.Data.GameData.Abilities.EffectData;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;

namespace GuildManager.Server.GameEngine.AI.Combat
{
    public static class CombatDesicions
    {
        public static CombatDesicion MakeDesicion(ICharacterObject actor, CharacterGroup actorGroup, CharacterGroup defenderGroup, int timer)
        {
            var madeDdesicion = CombatDesicion.Wait;

            if (ShouldChangeTarget(actor, actorGroup, defenderGroup))
                return CombatDesicion.ChangeTarget;

            foreach (var a in actor.CombatConfig.PriorityList)
            {
                if (a.Effects.First().GetType() == typeof(DirectDamageEffect))
                {
                    actor.AbilityToUse = a;
                    if (!actor.AbilityToUse.OnCoolDown())
                    {
                        return CombatDesicion.UseSKill;
                    }
                }

                if (a.Effects.First().GetType() == typeof(DirectThreatEffect))
                {
                    actor.AbilityToUse = a;
                    if (!actor.AbilityToUse.OnCoolDown())
                    {
                        return CombatDesicion.UseSKill;
                    }
                }
            }

            if (timer >= actor.NextMainHandAttack)
                return CombatDesicion.MainHandBaseAttack;

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

    public enum CombatDesicion { Wait, MainHandBaseAttack, ChangeTarget, FindTarget, GetThreat, UseSKill }
}
