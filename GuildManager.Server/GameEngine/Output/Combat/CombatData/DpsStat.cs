using System;

namespace GuildManager.Server.GameEngine.Output.Combat.CombatData
{
    public class DpsStat
    {
        public int Damage { get; set; }
        public double Dps { get; set; }

        public DpsStat()
        {
            Damage = 0;
        }

        public void UpdateDamage(int damage)
        {
            Damage += damage;
        }

        public void CalculateDps(int timer)
        {
            Dps = Damage / Convert.ToDouble(timer) * 100;
        }
    }
}
