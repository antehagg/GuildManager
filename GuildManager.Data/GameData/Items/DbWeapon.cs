using System;
using System.Collections.Generic;
using System.Text;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Items.Types;
using GuildManager.Data.GameObjects.Characters.Stats;

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
