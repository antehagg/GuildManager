using GuildManager.Data.GameObjects.Characters;
using Microsoft.EntityFrameworkCore;

namespace GuildManager.Api.Data
{
    public class GuildManagerContext : DbContext
    {
        public GuildManagerContext(DbContextOptions<GuildManagerContext> options) : base(options)
        {
            
        }

        public DbSet<PlayerCharacter> PlayerCharacters { get; set; }
    }
}
