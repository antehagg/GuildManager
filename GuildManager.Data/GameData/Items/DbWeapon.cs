using GuildManager.Data.GameData.Items.Types;

namespace GuildManager.Data.GameData.Items
{
    public class DbWeapon : DbItem
    {
        public WeaponType WeaponType { get; set; }
        public WeaponEquipType WeaponEquipType { get; set; }
        public EquipSlot EquipSlotType { get; set; }
        public double SwingSpeed { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
    }
}
