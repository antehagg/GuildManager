using System;
using System.Collections.Generic;
using System.Text;

namespace GuildManager.Server.GameEngine.Output.Combat
{
    public class CombatOutput
    {
        public List<string> CombatLog { get; set; }

        public CombatOutput()
        {
            CombatLog = new List<string>();
        }

        public void NewLine(string newLine)
        {
            CombatLog.Add(newLine);
        }
    }
}
