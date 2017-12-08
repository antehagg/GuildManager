using System;
using System.Linq;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Classes;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace GuildManager.Api.Data
{
    public class GuildManagerContext : DbContext
    {
        public GuildManagerContext(DbContextOptions<GuildManagerContext> options) : base(options)
        {
        }

        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
        public DbSet<GameClass> GameClasses { get; set; }

        public PlayerCharacter[] GetAllPlayers()
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

        public GameClass GetClassById(int classId)
        {
            try
            {
                var context = this;
                var gameClass = context.GameClasses.First(c => c.Id == classId);
                return gameClass;
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }
    }
}
