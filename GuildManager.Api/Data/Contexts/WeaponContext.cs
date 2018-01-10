using System;
using System.Linq;
using GuildManager.Data.GameData.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class WeaponContext
    {
        private readonly GuildManagerContext _context;
        public WeaponContext(GuildManagerContext context)
        {
            _context = context;
        }

        public WeaponContext(IServiceProvider service)
        {
            _context = service.GetService<GuildManagerContext>();
        }

        public DbWeapon GetWeaponById(int itemId)
        {
            var weapon = _context.Weapons.Include(w => w.Stats).First(w => w.Id == itemId);
            return weapon;
        }
    }
}
