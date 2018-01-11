﻿// <auto-generated />
using GuildManager.Api.Data;
using GuildManager.Data.GameData.Abilities;
using GuildManager.Data.GameData.Characters.CharactersData;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Items.Types;
using GuildManager.Data.GameData.Zones;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using Microsoft.EntityFrameworkCore.ValueGeneration;
using System;

namespace GuildManager.Api.Migrations
{
    [DbContext(typeof(GuildManagerContext))]
    [Migration("20180111204614_Descriptions")]
    partial class Descriptions
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildManager.Data.GameData.Abilities.Effect", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<int>("Duration");

                    b.Property<string>("Name");

                    b.Property<int?>("SkillId");

                    b.Property<int>("TargetType");

                    b.Property<int>("Type");

                    b.HasKey("Id");

                    b.HasIndex("SkillId");

                    b.ToTable("Effect");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Abilities.Skill", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("CastTime");

                    b.Property<int>("Cooldown");

                    b.Property<int>("Cost");

                    b.Property<int?>("DbGameClassId");

                    b.Property<string>("Description");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("DbGameClassId");

                    b.ToTable("Skills");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.CharactersData.PossibleLoot", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<double>("Chance");

                    b.Property<int?>("DbMonsterId");

                    b.Property<int?>("ItemId");

                    b.HasKey("Id");

                    b.HasIndex("DbMonsterId");

                    b.HasIndex("ItemId");

                    b.ToTable("PossibleLoot");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbEquipedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ArmId");

                    b.Property<int?>("ChestId");

                    b.Property<int?>("FeetId");

                    b.Property<int?>("HandId");

                    b.Property<int?>("HeadId");

                    b.Property<int?>("LegId");

                    b.Property<int?>("MainHandId");

                    b.Property<int?>("NeckId");

                    b.Property<int?>("OffHandId");

                    b.Property<int?>("RingOneId");

                    b.Property<int?>("RingTwoId");

                    b.Property<int?>("WaistId");

                    b.HasKey("Id");

                    b.HasIndex("ArmId");

                    b.HasIndex("ChestId");

                    b.HasIndex("FeetId");

                    b.HasIndex("HandId");

                    b.HasIndex("HeadId");

                    b.HasIndex("LegId");

                    b.HasIndex("MainHandId");

                    b.HasIndex("NeckId");

                    b.HasIndex("OffHandId");

                    b.HasIndex("RingOneId");

                    b.HasIndex("RingTwoId");

                    b.HasIndex("WaistId");

                    b.ToTable("EquippedItems");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbInventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Gold");

                    b.HasKey("Id");

                    b.ToTable("DbInventory");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbMonster", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassId");

                    b.Property<int?>("DbSpawnId");

                    b.Property<int?>("DbSpawnId1");

                    b.Property<int?>("InventoryId");

                    b.Property<int?>("MonsterBaseResourcesId");

                    b.Property<int>("MonsterType");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("DbSpawnId");

                    b.HasIndex("DbSpawnId1");

                    b.HasIndex("InventoryId");

                    b.HasIndex("MonsterBaseResourcesId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbPlayerCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("ClassId");

                    b.Property<int?>("EquipedItemsId");

                    b.Property<int?>("InventoryId");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("EquipedItemsId");

                    b.HasIndex("InventoryId");

                    b.ToTable("PlayerCharacters");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Classes.DbGameClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("BaseResourcesId");

                    b.Property<int?>("BaseStatsId");

                    b.Property<int?>("DbItemId");

                    b.Property<string>("Description");

                    b.Property<int>("MainStat");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BaseResourcesId");

                    b.HasIndex("BaseStatsId");

                    b.HasIndex("DbItemId");

                    b.ToTable("GameClasses");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Classes.GameClassData.BaseResources", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BaseHealth");

                    b.HasKey("Id");

                    b.ToTable("BaseResources");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Classes.GameClassData.BaseStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BaseAgility");

                    b.Property<int>("BaseIntelligence");

                    b.Property<int>("BaseStamina");

                    b.Property<int>("BaseStrength");

                    b.Property<int>("BaseWisdom");

                    b.HasKey("Id");

                    b.ToTable("BaseStats");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.DbItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Description");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("ItemRarity");

                    b.Property<string>("Name");

                    b.Property<int?>("StatsId");

                    b.HasKey("Id");

                    b.HasIndex("StatsId");

                    b.ToTable("DbItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DbItem");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.ItemsData.ItemStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

                    b.Property<int>("Armor");

                    b.Property<double>("CritChance");

                    b.Property<int>("Energy");

                    b.Property<double>("Haste");

                    b.Property<int>("Health");

                    b.Property<int>("Intelligence");

                    b.Property<int>("Stamina");

                    b.Property<int>("Strength");

                    b.Property<int>("Wisdom");

                    b.HasKey("Id");

                    b.ToTable("ItemStats");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Zones.DbSpawn", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("DbZoneId");

                    b.Property<int>("SpawnAmount");

                    b.Property<int>("SpawnNo");

                    b.HasKey("Id");

                    b.HasIndex("DbZoneId");

                    b.ToTable("DbSpawn");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Zones.DbZone", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Name");

                    b.Property<int>("ZoneType");

                    b.HasKey("Id");

                    b.ToTable("Zones");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.DbWeapon", b =>
                {
                    b.HasBaseType("GuildManager.Data.GameData.Items.DbItem");

                    b.Property<int>("EquipSlotType");

                    b.Property<int>("MaxDamage");

                    b.Property<int>("MinDamage");

                    b.Property<double>("SwingSpeed");

                    b.Property<int>("WeaponEquipType");

                    b.Property<int>("WeaponType");

                    b.ToTable("DbWeapon");

                    b.HasDiscriminator().HasValue("DbWeapon");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.Types.DbArmor", b =>
                {
                    b.HasBaseType("GuildManager.Data.GameData.Items.DbItem");

                    b.Property<int>("ArmorType");

                    b.Property<int>("EquipSlotType")
                        .HasColumnName("DbArmor_EquipSlotType");

                    b.ToTable("DbArmor");

                    b.HasDiscriminator().HasValue("DbArmor");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Abilities.Effect", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Abilities.Skill")
                        .WithMany("Effects")
                        .HasForeignKey("SkillId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Abilities.Skill", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.DbGameClass")
                        .WithMany("Skills")
                        .HasForeignKey("DbGameClassId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.CharactersData.PossibleLoot", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Characters.DbMonster")
                        .WithMany("LootList")
                        .HasForeignKey("DbMonsterId");

                    b.HasOne("GuildManager.Data.GameData.Items.DbItem", "Item")
                        .WithMany()
                        .HasForeignKey("ItemId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbEquipedItems", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Arm")
                        .WithMany()
                        .HasForeignKey("ArmId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Chest")
                        .WithMany()
                        .HasForeignKey("ChestId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Feet")
                        .WithMany()
                        .HasForeignKey("FeetId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Hand")
                        .WithMany()
                        .HasForeignKey("HandId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Head")
                        .WithMany()
                        .HasForeignKey("HeadId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Leg")
                        .WithMany()
                        .HasForeignKey("LegId");

                    b.HasOne("GuildManager.Data.GameData.Items.DbWeapon", "MainHand")
                        .WithMany()
                        .HasForeignKey("MainHandId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Neck")
                        .WithMany()
                        .HasForeignKey("NeckId");

                    b.HasOne("GuildManager.Data.GameData.Items.DbWeapon", "OffHand")
                        .WithMany()
                        .HasForeignKey("OffHandId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "RingOne")
                        .WithMany()
                        .HasForeignKey("RingOneId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "RingTwo")
                        .WithMany()
                        .HasForeignKey("RingTwoId");

                    b.HasOne("GuildManager.Data.GameData.Items.Types.DbArmor", "Waist")
                        .WithMany()
                        .HasForeignKey("WaistId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbMonster", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.DbGameClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("GuildManager.Data.GameData.Zones.DbSpawn")
                        .WithMany("NamedMonsters")
                        .HasForeignKey("DbSpawnId");

                    b.HasOne("GuildManager.Data.GameData.Zones.DbSpawn")
                        .WithMany("TrashMonsters")
                        .HasForeignKey("DbSpawnId1");

                    b.HasOne("GuildManager.Data.GameData.Characters.DbInventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("GuildManager.Data.GameData.Classes.GameClassData.BaseResources", "MonsterBaseResources")
                        .WithMany()
                        .HasForeignKey("MonsterBaseResourcesId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbPlayerCharacter", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.DbGameClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId");

                    b.HasOne("GuildManager.Data.GameData.Characters.DbEquipedItems", "EquipedItems")
                        .WithMany()
                        .HasForeignKey("EquipedItemsId");

                    b.HasOne("GuildManager.Data.GameData.Characters.DbInventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Classes.DbGameClass", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.GameClassData.BaseResources", "BaseResources")
                        .WithMany()
                        .HasForeignKey("BaseResourcesId");

                    b.HasOne("GuildManager.Data.GameData.Classes.GameClassData.BaseStats", "BaseStats")
                        .WithMany()
                        .HasForeignKey("BaseStatsId");

                    b.HasOne("GuildManager.Data.GameData.Items.DbItem")
                        .WithMany("ClassRestriction")
                        .HasForeignKey("DbItemId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.DbItem", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Items.ItemsData.ItemStats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Zones.DbSpawn", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Zones.DbZone")
                        .WithMany("SpawnLocations")
                        .HasForeignKey("DbZoneId");
                });
#pragma warning restore 612, 618
        }
    }
}
