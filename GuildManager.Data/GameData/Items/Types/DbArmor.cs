namespace GuildManager.Data.GameData.Items.Types
{
    public class DbArmor : DbItem
    {
        public ArmorType ArmorType { get; set; }
        public EquipSlot EquipSlotType { get; set; }
    }
}
