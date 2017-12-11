using System;
using System.Linq;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameData.Items;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data
{
    public class GuildManagerContext : DbContext
    {
        public GuildManagerContext(DbContextOptions<GuildManagerContext> options) : base(options)
        {
        }

        public DbSet<DbWeapon> Weapons { get; set; }
        public DbSet<DbPlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<DbGamelass> GameClasses { get; set; }
        public DbSet<BaseStats> BaseStats { get; set; }
        public DbSet<BaseResources> BaseResources { get; set; }

        public DbPlayerCharacter[] GetAllPlayers()
        {
            try
            {
                var context = this;
                var players = context.PlayerCharacters.ToArray();
                foreach (var p in players)
                {
                    p.Class = GetClassById(p.ClassId);
                }

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
                var player = context.PlayerCharacters.First(p => p.Id == playerId);
                player.Class = GetClassById(player.ClassId);

                return player;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public DbGamelass GetClassById(int classId)
        {
            try
            {
                var context = this;
                var gameClass = context.GameClasses.First(c => c.Id == classId);
                gameClass.BaseResources = GetBaseResourcesById(gameClass.BaseResourcesId);
                gameClass.BaseStats = GetBaseStatsById(gameClass.BaseStatsId);
                return gameClass;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private BaseStats GetBaseStatsById(int baseStatId)
        {
            try
            {
                var context = this;
                var baseStats = context.BaseStats.First(bs => bs.Id == baseStatId);
                return baseStats;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        private BaseResources GetBaseResourcesById(int baseResourcesId)
        {
            try
            {
                var context = this;
                var baseResources = context.BaseResources.First(br => br.Id == baseResourcesId);
                return baseResources;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
