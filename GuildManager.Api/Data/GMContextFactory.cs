using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace GuildManager.Api.Data
{

    public class GmContextFactory : IDesignTimeDbContextFactory<GuildManagerContext>
    {
        public GuildManagerContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<GuildManagerContext>();
            builder.UseSqlServer("Server=tcp:guildmanager.database.windows.net,1433;Initial Catalog=GuildManager;Persist Security Info=False;User ID=antehagg;Password=Antemrch3f3n;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
            return new GuildManagerContext(builder.Options);
        }
    }
}
