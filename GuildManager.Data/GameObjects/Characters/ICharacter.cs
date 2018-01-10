using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameObjects.Characters.Stats;

namespace GuildManager.Data.GameObjects.Characters
{
    public interface ICharacter
    {
        int Id { get; set; }
        string Name { get; set; }
        PlayerStats Stats { get; set; }
        DbGameClass Class { get; set; }
        EquippedItems EquippedItems { get; set; }

        int GetCurrentHealth();
        void ChangeCurrentHealth(int change);
    }
}
