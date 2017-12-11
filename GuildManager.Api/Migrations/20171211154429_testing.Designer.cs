﻿// <auto-generated />
using GuildManager.Api.Data;
using GuildManager.Data.GameData.Characters.CharactersData;
using GuildManager.Data.GameData.Classes;
using GuildManager.Data.GameData.Items.Types;
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
    [Migration("20171211154429_testing")]
    partial class testing
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbEquipedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int?>("MainHandId");

                    b.HasKey("Id");

                    b.HasIndex("MainHandId");

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

                    b.Property<int?>("BaseResourcesId");

                    b.Property<int>("ClassId");

                    b.Property<int>("InventoryId");

                    b.Property<int>("MonsterType");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BaseResourcesId");

                    b.HasIndex("ClassId");

                    b.HasIndex("InventoryId");

                    b.ToTable("Monsters");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbPlayerCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<int?>("EquipedItemsId");

                    b.Property<int>("InventoryId");

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

                    b.Property<int>("BaseResourcesId");

                    b.Property<int>("BaseStatsId");

                    b.Property<int>("MainStat");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.HasIndex("BaseResourcesId");

                    b.HasIndex("BaseStatsId");

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

                    b.Property<int?>("DbInventoryId");

                    b.Property<string>("Discriminator")
                        .IsRequired();

                    b.Property<int>("ItemRarity");

                    b.Property<string>("Name");

                    b.Property<int>("StatsId");

                    b.HasKey("Id");

                    b.HasIndex("DbInventoryId");

                    b.HasIndex("StatsId");

                    b.ToTable("DbItem");

                    b.HasDiscriminator<string>("Discriminator").HasValue("DbItem");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.ItemsData.ItemStats", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("Agility");

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

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbEquipedItems", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Items.DbItem", "MainHand")
                        .WithMany("DbEquippedItems")
                        .HasForeignKey("MainHandId");
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbMonster", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.GameClassData.BaseResources", "BaseResources")
                        .WithMany()
                        .HasForeignKey("BaseResourcesId");

                    b.HasOne("GuildManager.Data.GameData.Classes.DbGameClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GuildManager.Data.GameData.Characters.DbInventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Characters.DbPlayerCharacter", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.DbGameClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GuildManager.Data.GameData.Characters.DbEquipedItems", "EquipedItems")
                        .WithMany()
                        .HasForeignKey("EquipedItemsId");

                    b.HasOne("GuildManager.Data.GameData.Characters.DbInventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Classes.DbGameClass", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Classes.GameClassData.BaseResources", "BaseResources")
                        .WithMany()
                        .HasForeignKey("BaseResourcesId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GuildManager.Data.GameData.Classes.GameClassData.BaseStats", "BaseStats")
                        .WithMany()
                        .HasForeignKey("BaseStatsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });

            modelBuilder.Entity("GuildManager.Data.GameData.Items.DbItem", b =>
                {
                    b.HasOne("GuildManager.Data.GameData.Characters.DbInventory")
                        .WithMany("InventoryItems")
                        .HasForeignKey("DbInventoryId");

                    b.HasOne("GuildManager.Data.GameData.Items.ItemsData.ItemStats", "Stats")
                        .WithMany()
                        .HasForeignKey("StatsId")
                        .OnDelete(DeleteBehavior.Cascade);
                });
#pragma warning restore 612, 618
        }
    }
}
