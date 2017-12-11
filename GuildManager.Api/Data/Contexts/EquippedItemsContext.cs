using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameData.Characters;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class EquippedItemsContext
    {
        private readonly GuildManagerContext _context;

        public EquippedItemsContext(GuildManagerContext context)
        {
            _context = context;
        }

        public DbEquipedItems GetEquippedItemsById(int eiId)
        {
            var equippedItems = _context.EquippedItems.First(ei => ei.Id == eiId);
            var itemContext = new WeaponContext(_context);

            equippedItems.MainHand = itemContext.GetWeaponById(equippedItems.MainHandId);

            return equippedItems;
        }
    }
}
