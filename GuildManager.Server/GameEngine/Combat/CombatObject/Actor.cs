using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Server.GameEngine.Combat.CombatObject
{
    public class Actor
    {
        public Actor Target;
        private Actor _targetedBy;
        public bool IsAlive;
        public bool IsAttacker;
        public bool IsMonster;

        public int NextBaseAttack;

        public Actor()
        {
            IsAlive = true;
        }

        public void SetTarget(Actor target)
        {
            Target = target;
        }

        public void SetTargetedBy(Actor targetedBy)
        {
            _targetedBy = targetedBy;
        }
    }
}
