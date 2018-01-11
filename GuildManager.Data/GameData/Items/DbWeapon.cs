using GuildManager.Data.GameData.Items.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GuildManager.Data.GameData.Items
{
    public class DbWeapon : DbItem
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public WeaponType WeaponType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public WeaponEquipType WeaponEquipType { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public EquipSlot EquipSlotType { get; set; }
        public double SwingSpeed { get; set; }
        public int MinDamage { get; set; }
        public int MaxDamage { get; set; }
    }
}
