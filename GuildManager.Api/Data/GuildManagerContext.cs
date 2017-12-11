using System;
using System.Linq;
using GuildManager.Api.Data.Contexts;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.ItemsData;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data
{
    public class GuildManagerContext : DbContext
    {
        public GuildManagerContext(DbContextOptions<GuildManagerContext> options) : base(options)
        {
        }

        public DbSet<DbEquipedItems> EquippedItems { get; set; }
        public DbSet<DbWeapon> Weapons { get; set; }
        public DbSet<ItemStats> ItemStats { get; set; }
        public DbSet<DbPlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<DbMonster> Monsters { get; set; }
        public DbSet<DbGameClass> GameClasses { get; set; }
        public DbSet<BaseStats> BaseStats { get; set; }
        public DbSet<BaseResources> BaseResources { get; set; }

        public DbMonster[] GetAllMonsters()
        {
            try
            {
                var context = this;

                var monsters = context.Monsters.Include(m => m.Class).ToArray();

                return monsters;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DbPlayerCharacter[] GetAllPlayers()
        {
            try
            {
                var context = this;

                var players = context.PlayerCharacters
                    .Include(p => p.EquipedItems).ThenInclude(e => e.MainHand).ThenInclude(mh => mh.Stats)
                    .Include(p => p.Class).ThenInclude(c => c.BaseResources).Include(c => c.Class).ThenInclude(c => c.BaseStats)
                    .Include(p => p.Inventory)
                    .ToArray();

                return players;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DbPlayerCharacter GetPlayerById(int playerId)
        {
            try
            {
                var context = this;
                var player = context.PlayerCharacters
                    .Include(p => p.EquipedItems).ThenInclude(e => e.MainHand).ThenInclude(mh => mh.Stats)
                    .Include(p => p.Class).ThenInclude(c => c.BaseResources).Include(c => c.Class).ThenInclude(c => c.BaseStats)
                    .Include(p => p.Inventory)
                    .First(p => p.Id == playerId);

                return player;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
