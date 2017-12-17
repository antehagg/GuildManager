using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Classes;

namespace GuildManager.Data.GameObjects.Characters
{
    public interface ICharacter
    {
        int Id { get; set; }
        string Name { get; set; }
        DbGameClass Class { get; set; }
        EquippedItems EquippedItems { get; set; }

        int GetCurrentHealth();
        void ChangeCurrentHealth(int change);
    }
}
