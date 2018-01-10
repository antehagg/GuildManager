using System.Collections.Generic;
using GuildManager.Server.GameEngine.GameObjects.Characters;

namespace GuildManager.Server.GameEngine.GameObjects.Groups
{
    public class CharacterGroup
    {
        public List<ICharacterObject> Members { get; set; }
        public ICharacterObject MainAssist { get; set; }
        public bool IsDead { get; set; }

        public CharacterGroup(List<ICharacterObject> members, ICharacterObject mainAssist)
        {
            MainAssist = mainAssist;
            Members = members;
            IsDead = false;
        }

        public void UpdateGroup()
        {
            CheckDeadStatus();
            UpdateCharacters();
        }

        private void UpdateCharacters()
        {
            foreach (var c in Members)
            {
                c.UpdateCharacter();
            }
        }

        private void CheckDeadStatus()
        {
            var aliveCount = 0;

            foreach (var c in Members)
            {
                if (c.IsAlive())
                    aliveCount++;
            }

            if (aliveCount == 0)
                IsDead = true;
        }
    }
}
