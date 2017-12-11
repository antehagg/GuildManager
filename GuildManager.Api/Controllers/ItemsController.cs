using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Api.Data;
using GuildManager.Api.Data.Contexts;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameObjects.Characters;
using Microsoft.AspNetCore.Mvc;

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
            var weaponContext = new WeaponContext(Services);
            var weapon = weaponContext.GetWeaponById(weaponId);
            return weapon;
        }
    }
}
