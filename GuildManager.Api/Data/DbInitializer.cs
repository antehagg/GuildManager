using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Classes;

namespace GuildManager.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GuildManagerContext context)
        {
            context.Database.EnsureCreated();

            if (!context.GameClasses.Any())
            {

                context.GameClasses.AddRange(
                    new GameClass
                    {
                        Name = "Warrior",
                        BaseHealth = 20,
                        BaseStrength = 10
                    },
                    new GameClass
                    {
                        Name = "Rogue",
                        BaseHealth = 10,
                        BaseStrength = 10
                    });

                context.SaveChanges();
            }

            if (context.PlayerCharacters.Any())
            {
                return;
            }

            context.PlayerCharacters.AddRange(
                new PlayerCharacter
                {
                    Name = "Vexing",
                    ClassId = 1
                },
                new PlayerCharacter
                {
                    Name = "Credit",
                    ClassId = 2
                });

            context.SaveChanges();
        }
    }
}