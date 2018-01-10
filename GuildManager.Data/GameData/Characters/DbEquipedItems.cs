using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.Types;

namespace GuildManager.Data.GameData.Characters
{
    public class DbEquipedItems
    {
        public int Id { get; set; }
        public virtual DbWeapon MainHand { get; set; }
        public virtual DbWeapon OffHand { get; set; }
        public virtual DbArmor Head { get; set; }
        public virtual DbArmor Chest { get; set; }
        public virtual DbArmor Arm { get; set; }
        public virtual DbArmor Waist { get; set; }
        public virtual DbArmor Hand { get; set; }
        public virtual DbArmor Leg { get; set; }
        public virtual DbArmor Feet { get; set; }
        public virtual DbArmor Neck { get; set; }
        public virtual DbArmor RinegOne { get; set; }
        public virtual DbArmor RingTwo { get; set; }
    }
}