using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.ItemsData;

namespace GuildManager.Data.GameObjects.Characters
{
    public class EquippedItems
    {
        public int Id { get; set; }
        public DbWeapon MainHand { get; set; }
        public ItemStats TotalStats { get; set; }

        public EquippedItems(DbEquipedItems dbEquipedItems)
        {
            Id = dbEquipedItems.Id;
            MainHand = dbEquipedItems.MainHand;
            CalculateTotalStats();
        }

        private void CalculateTotalStats()
        {
            TotalStats = MainHand.Stats;
        }
    }
}
