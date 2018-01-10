using System.Collections.Generic;
using System.Linq;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameData.Abilities.EffectData;
using Microsoft.AspNetCore.Mvc;
using GuildManager.Data.GameData.Characters;
using GuildManager.Data.GameData.Characters.CharactersData;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Classes.GameClassData;
using GuildManager.Data.GameData.Items;
using GuildManager.Data.GameData.Items.ItemsData;
using GuildManager.Data.GameData.Items.Types;
using GuildManager.Data.GameObjects.Characters;
using GuildManager.Data.GameObjects.Characters.Stats;
using GuildManager.Data.GameObjects.Characters.Stats.SpecificStat;
using GuildManager.Server.GameEngine.AI.Combat;
using GuildManager.Server.GameEngine.Combat.Engine;
using GuildManager.Server.GameEngine.GameObjects.Characters;
using GuildManager.Server.GameEngine.GameObjects.Groups;
using GuildManager.Simulator.Models.CombatViewModels;
using Microsoft.Extensions.DependencyModel;

namespace GuildManager.Simulator.Controllers
{
    public class CombatController : Controller
    {
        private Combat _testCombat; 
        public void Index()
        {
            CreateTestData();
        }

        public IActionResult CombatResult()
        {
            CreateTestData();
            var combatResult = new CombatResultViewModel
            {
                Attackers = _testCombat.Attackers,
                Defenders = _testCombat.Defenders,
                CombatMembers = _testCombat.CombatMembers
            };

            return View(combatResult);
        }

        private void CreateTestData()
        {
            var testRogueDb = new DbPlayerCharacter
            {
                Class = new DbGameClass
                {
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            CastTime = 0,
                            Cooldown = 1000,
                            Cost = 20,
                            Id = 1,
                            Name = "Backstab",
                            Effects = new List<Effect>
                            {
                                new DirectDamageEffect
                                {
                                    BonusDamage = 2,
                                    CritChance = 10,
                                    Id = 1,
                                    MaxDamage = 0,
                                    MinDamage = 0,
                                    Type = EffectType.DirectDamage,
                                    TargetType = TargetType.Single
                                }
                            }
                        },
                        new Skill
                        {
                            CastTime = 0,
                            Cooldown = 1000,
                            Cost = 20,
                            Id = 3,
                            Name = "Evade",
                            Effects = new List<Effect>
                            {
                                new DirectThreatEffect()
                                {
                                    Id = 3,
                                    MinThreat = -10,
                                    MaxThreat = -10,
                                    Type = EffectType.DirectThreat,
                                    TargetType = TargetType.Aoe
                                }
                            }
                        }
                    },
                    Id = 1,
                    Name = "Rogue",
                    MainStat = StatName.Agility,
                    BaseStats = new BaseStats
                    {
                        Id = 1,
                        BaseAgility = 20,
                        BaseStrength = 10,
                        BaseIntelligence = 10,
                        BaseWisdom = 10,
                        BaseStamina = 20
                    },
                    BaseResources = new BaseResources
                    {
                        Id = 1,
                        BaseHealth = 100
                    }
                },
                EquipedItems = new DbEquipedItems
                {
                    MainHand = new DbWeapon
                    {
                        EquipSlotType = EquipSlot.MainHand,
                        Id = 1,
                        ItemRarity = ItemRarity.Magic,
                        MaxDamage = 10,
                        MinDamage = 5,
                        Name = "Magic Dagger",
                        SwingSpeed = 1,
                        WeaponEquipType = WeaponEquipType.OneHanded,
                        Stats = new ItemStats
                        {
                            Agility = 10,
                            Id = 1
                        }
                    }
                },
                Id = 1,
                Inventory = new DbInventory
                {
                    Id = 1,
                    Gold = 100
                },
                Name = "Test Rogue"
            };
            var testRoguePlayer = new Player(testRogueDb);
            var testRogue =
                new PlayerObject(testRoguePlayer, true) {CombatConfig = new CombatConfig(testRogueDb.Class.Skills)};

            var tesstWarriorDb = new DbPlayerCharacter
            {
                Class = new DbGameClass
                {
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            CastTime = 0,
                            Cooldown = 500,
                            Cost = 20,
                            Id = 2,
                            Name = "Taunt",
                            Effects = new List<Effect>
                            {
                                new DirectThreatEffect()
                                {
                                    Id = 2,
                                    Type = EffectType.DirectThreat,
                                    MinThreat = 20,
                                    MaxThreat = 20,
                                    TargetType = TargetType.Single
                                }
                            }
                        },
                        new Skill
                        {
                            CastTime = 0,
                            Cooldown = 500,
                            Cost = 20,
                            Id = 3,
                            Name = "Health",
                            Effects = new List<Effect>
                            {
                                new BuffEffect()
                                {
                                    Id = 2,
                                    Type = EffectType.Buff,
                                    Duration = 1000,
                                    Stats = new BuffStats
                                    {
                                        Health = 50
                                    }
                                }
                            }
                        }
                    },
                    Id = 2,
                    Name = "Warrior",
                    MainStat = StatName.Agility,
                    BaseStats = new BaseStats
                    {
                        Id = 2,
                        BaseAgility = 10,
                        BaseStrength = 20,
                        BaseIntelligence = 10,
                        BaseWisdom = 10,
                        BaseStamina = 20
                    },
                    BaseResources = new BaseResources
                    {
                        Id = 2,
                        BaseHealth = 200
                    }
                },
                EquipedItems = new DbEquipedItems
                {
                    MainHand = new DbWeapon
                    {
                        EquipSlotType = EquipSlot.MainHand,
                        Id = 2,
                        ItemRarity = ItemRarity.Magic,
                        MaxDamage = 15,
                        MinDamage = 9,
                        Name = "Magic Sword",
                        SwingSpeed = 2,
                        WeaponEquipType = WeaponEquipType.OneHanded,
                        Stats = new ItemStats
                        {
                            Strength = 10,
                            Id = 2
                        }
                    }
                },
                Id = 2,
                Inventory = new DbInventory
                {
                    Id = 2,
                    Gold = 100
                },
                Name = "Test Warrior"
            };
            var testWarriorPlayer = new Player(tesstWarriorDb);
            var testWarrior =
                new PlayerObject(testWarriorPlayer, true)
                {
                    CombatConfig = new CombatConfig(testWarriorPlayer.Class.Skills)
                };

            var playerList = new List<ICharacterObject> {testWarrior, testRogue};
            var playerGroup = new CharacterGroup(playerList, testWarrior);

            var testOrcPawnDb = new DbMonster
            {
                Class = new DbGameClass
                {
                    Skills = new List<Skill>
                    {
                        new Skill
                        {
                            CastTime = 0,
                            Cooldown = 100000,
                            Cost = 20,
                            Id = 2,
                            Name = "Taunt",
                            Effects = new List<Effect>
                            {
                                new DirectThreatEffect()
                                {
                                    Id = 2,
                                    Type = EffectType.DirectThreat,
                                    MinThreat = 20,
                                    MaxThreat = 20,
                                    TargetType = TargetType.Single
                                }
                            }
                        }
                    },
                    Id = 2,
                    Name = "Warrior",
                    MainStat = StatName.Agility,
                    BaseStats = new BaseStats
                    {
                        Id = 2,
                        BaseAgility = 10,
                        BaseStrength = 20,
                        BaseIntelligence = 10,
                        BaseWisdom = 10,
                        BaseStamina = 20
                    },
                    BaseResources = new BaseResources
                    {
                        Id = 2,
                        BaseHealth = 200
                    }
                },
                Id = 3,
                Inventory = new DbInventory
                {
                    Id = 3,
                    Gold = 100
                },
                Name = "Orc Pawn",
                LootList = new List<PossibleLoot>
                {
                    new PossibleLoot()
                },
                MonsterType = MonsterType.Common,
                MonsterBaseResources = new BaseResources
                {
                    Id = 1,
                    BaseHealth = 300
                }
            };

            var testOrcPawnMonster = new Monster(testOrcPawnDb);
            var testOrcPawn =
                new MonsterObject(testOrcPawnMonster, false)
                {
                    CombatConfig = new CombatConfig(testOrcPawnMonster.Class.Skills)
                };

            var monsterList = new List<ICharacterObject> { testOrcPawn };
            var monsterGroup = new CharacterGroup(monsterList, testOrcPawn);

            _testCombat = new Combat(playerGroup, monsterGroup);
            _testCombat.StartCombat();
        }
    }
}
