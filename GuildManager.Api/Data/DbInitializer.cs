using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;

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
                    new DbGamelass
                    {
                        Name = "Warrior",
                        BaseStats = new BaseStats
                        {
                            BaseAgility = 10,
                            BaseIntelligence = 10,
                            BaseStamina = 20,
                            BaseStrength = 20,
                            BaseWisdom = 10
                        },
                        BaseResources = new BaseResources
                        {
                            BaseHealth = 100
                        },
                        MainStat = StatName.Strength
                    },
                    new DbGamelass
                    {
                        Name = "Rogue",
                        BaseStats = new BaseStats
                        {
                            BaseAgility = 20,
                            BaseIntelligence = 10,
                            BaseStamina = 20,
                            BaseStrength = 10,
                            BaseWisdom = 10
                        },
                        BaseResources = new BaseResources
                        {
                            BaseHealth = 50
                        },
                        MainStat = StatName.Agility
                    });

                context.SaveChanges();
            }

            if (!context.PlayerCharacters.Any())
            {

                context.PlayerCharacters.AddRange(
                    new DbPlayerCharacter
                    {
                        Name = "Vexing",
                        ClassId = 1
                    },
                    new DbPlayerCharacter
                    {
                        Name = "Credit",
                        ClassId = 2
                    });

                context.SaveChanges();
            }
        }
    }
}