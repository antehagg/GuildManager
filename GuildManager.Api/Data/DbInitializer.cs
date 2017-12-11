using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Characters.CharactersData;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.ItemsData;
using GuildManager.Data.GameData.Items.Types;
using GuildManager.Data.GameObjects.Characters;

namespace GuildManager.Api.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GuildManagerContext context)
        {
            context.Database.EnsureCreated();

            if (!context.Weapons.Any())
            {
                var dagger = new DbWeapon
                {
                    EquipSlotType = EquipSlot.MainHand,
                    ItemRarity = ItemRarity.Magic,
                    MaxDamage = 10,
                    MinDamage = 5,
                    Name = "Magic Dagger",
                    Stats = new ItemStats
                    {
                        Agility = 5,
                        CritChance = 5
                    },
                    SwingSpeed = 1.0,
                    WeaponEquipType = WeaponEquipType.OneHanded,
                    WeaponType = WeaponType.Dagger
                };

                var sword = new DbWeapon
                {
                    EquipSlotType = EquipSlot.MainHand,
                    ItemRarity = ItemRarity.Magic,
                    MaxDamage = 20,
                    MinDamage = 10,
                    Name = "Magic Sword",
                    Stats = new ItemStats
                    {
                        Strength = 5,
                        Stamina = 5
                    },
                    SwingSpeed = 2.0,
                    WeaponEquipType = WeaponEquipType.OneHanded,
                    WeaponType = WeaponType.Sword
                };

                context.AddRange(dagger, sword);
                context.SaveChanges();
            }

            if (!context.Weapons.Any())
            {
                var eiWarrior = new DbEquipedItems
                {
                    MainHandId = 2
                };

                var eiRogue = new DbEquipedItems
                {
                    MainHandId = 1
                };

                context.SaveChanges();
            }

            if (!context.GameClasses.Any())
            {
                var warrior = new DbGamelass
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
                };

                var rogue = new DbGamelass
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
                    MainStat = StatName.Agility,
                };

                context.AddRange(warrior, rogue);
                context.SaveChanges();
            }

            if (!context.PlayerCharacters.Any())
            {

                context.PlayerCharacters.AddRange(
                    new DbPlayerCharacter
                    {
                        Name = "Vexing",
                        ClassId = 1,
                        EquipedItemsId = 2
                    },
                    new DbPlayerCharacter
                    {
                        Name = "Credit",
                        ClassId = 2,
                        EquipedItemsId = 1
                    });

                context.SaveChanges();
            }

            if (!context.Monsters.Any())
            {

                context.Monsters.AddRange(
                    new DbMonster
                    {
                        Name = "Orc Pawn",
                        ClassId = 1,
                        BaseResources = new BaseResources
                        {
                            BaseHealth = 100
                        },
                        MonsterType = MonsterType.Common,
                        InventoryId = 3
                    });

                context.SaveChanges();
            }
        }
    }
}