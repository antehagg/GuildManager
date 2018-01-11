using System;
using System.Linq;
using GuildManager.Api.Data;
using GuildManager.Api.Data.Contexts;
using GuildManager.Data.GameData.Items;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    public class ItemsController : Controller
    {
        public IServiceProvider Services;

        public ItemsController(IServiceProvider services)
        {
            Services = services;
        }

        // GET api/PlayerCharacter/5
        [HttpGet("{weaponId}")]
        public DbWeapon Weapon(int weaponId)
        {
            using (var context = Services.GetService<GuildManagerContext>())
            {
                var test = context.Weapons.ToList();
                var weaponContext = new WeaponContext(context);
                var weapon = weaponContext.GetWeaponById(weaponId);
                return weapon;
            }
        }
    }
}
