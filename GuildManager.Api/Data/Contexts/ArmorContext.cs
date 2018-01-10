using System;
using System.Linq;
using GuildManager.Data.GameData.Items.Types;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class ArmorContext
    {
        private readonly GuildManagerContext _context;
        public ArmorContext(GuildManagerContext context)
        {
            _context = context;
        }

        public ArmorContext(IServiceProvider service)
        {
            _context = service.GetService<GuildManagerContext>();
        }

        public DbArmor GetArmorById(int itemId)
        {
            var armor = _context.Armor.Include(w => w.Stats).First(w => w.Id == itemId);
            return armor;
        }
    }
}
