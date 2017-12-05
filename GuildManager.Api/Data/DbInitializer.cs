using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Api.Data
{
    public static class DbInitializer
    {

        public static void Initialize(GuildManagerContext context) //SchoolContext is EF context
        {

            context.Database.EnsureCreated(); //if db is not exist ,it will create database .but ,do nothing .

            // Look for any students.
            if (context.PlayerCharacters.Any())
            {
                return; // DB has been seeded
            }

            context.PlayerCharacters.AddRange(
                new PlayerCharacter
                {
                    Name = "Vexing"
                },
                new PlayerCharacter
                {
                    Name = "Credit"
                });

            context.SaveChanges();
        }
    }
}