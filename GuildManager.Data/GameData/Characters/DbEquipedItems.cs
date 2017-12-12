using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.Types;

namespace GuildManager.Data.GameData.Characters
{
    public class DbEquipedItems
    {
        public int Id { get; set; }
        public virtual DbWeapon MainHand { get; set; }
    }
}