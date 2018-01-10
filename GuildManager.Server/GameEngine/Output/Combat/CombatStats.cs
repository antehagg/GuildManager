using GuildManager.Server.GameEngine.Output.Combat.CombatData;

namespace GuildManager.Server.GameEngine.Output.Combat
{
    public class CombatStats
    {
        public DpsStat DpsStat { get; set; }

        public CombatStats()
        {
            DpsStat = new DpsStat();
        }

        public void CalculateStats(int timer)
        {
            DpsStat.CalculateDps(timer);
        }
    }
}
