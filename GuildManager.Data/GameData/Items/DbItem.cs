using System.Collections.Generic;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Items.ItemsData;
using GuildManager.Data.GameData.Items.Types;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace GuildManager.Data.GameData.Items
{
    public class DbItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public  ItemStats Stats { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public ItemRarity ItemRarity { get; set; }
        public List<DbGameClass> ClassRestriction { get; set; }
    }
}
