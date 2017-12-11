using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using GuildManager.Data.GameData.Items;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data.Contexts
{
    public class WeaponContext
    {
        private readonly GuildManagerContext _context;
        public WeaponContext(IServiceProvider service)
        {
            _context = service.GetService<GuildManagerContext>();
        }

        public DbWeapon GetWeaponById(int itemId)
        {
            var weapon = _context.Weapons.First(w => w.Id == itemId);
            return weapon;
        }
    }
}
