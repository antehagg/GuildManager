using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GuildManager.Server.GameEngine.GameObjects.Characters.CharacterData
{
    public class Threat
    {
        public Dictionary<ICharacterObject, int> ThreatList { get; set; }

        public Threat()
        {
            ThreatList = new Dictionary<ICharacterObject, int>();
        }

        public void ChangeThreat(ICharacterObject actor, int threat)
        {
            ThreatList[actor] += threat;
            SortThreatList();
        }

        public void SortThreatList()
        {
            ThreatList = new Dictionary<ICharacterObject, int>(ThreatList.OrderByDescending(x => x.Value));
        }
    }
}
