﻿// <auto-generated />
using GuildManager.Api.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System;

namespace GuildManager.Api.Migrations
{
    [DbContext(typeof(GuildManagerContext))]
    [Migration("20171208164126_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.0.1-rtm-125")
                .HasAnnotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn);

            modelBuilder.Entity("GuildManager.Data.GameObjects.Characters.EquipedItems", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("EquipedItems");
                });

            modelBuilder.Entity("GuildManager.Data.GameObjects.Characters.Inventory", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Inventory");
                });

            modelBuilder.Entity("GuildManager.Data.GameObjects.Characters.PlayerCharacter", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("ClassId");

                    b.Property<int?>("EquipedItemsId");

                    b.Property<int?>("InventoryId");

                    b.Property<string>("Name");

                    b.Property<int?>("RaceId");

                    b.HasKey("Id");

                    b.HasIndex("ClassId");

                    b.HasIndex("EquipedItemsId");

                    b.HasIndex("InventoryId");

                    b.HasIndex("RaceId");

                    b.ToTable("PlayerCharacters");
                });

            modelBuilder.Entity("GuildManager.Data.GameObjects.Classes.GameClass", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<int>("BaseHealth");

                    b.Property<int>("BaseStrength");

                    b.Property<string>("Name");

                    b.HasKey("Id");

                    b.ToTable("GameClasses");
                });

            modelBuilder.Entity("GuildManager.Data.GameObjects.Races.Race", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.HasKey("Id");

                    b.ToTable("Race");
                });

            modelBuilder.Entity("GuildManager.Data.GameObjects.Characters.PlayerCharacter", b =>
                {
                    b.HasOne("GuildManager.Data.GameObjects.Classes.GameClass", "Class")
                        .WithMany()
                        .HasForeignKey("ClassId")
                        .OnDelete(DeleteBehavior.Cascade);

                    b.HasOne("GuildManager.Data.GameObjects.Characters.EquipedItems", "EquipedItems")
                        .WithMany()
                        .HasForeignKey("EquipedItemsId");

                    b.HasOne("GuildManager.Data.GameObjects.Characters.Inventory", "Inventory")
                        .WithMany()
                        .HasForeignKey("InventoryId");

                    b.HasOne("GuildManager.Data.GameObjects.Races.Race", "Race")
                        .WithMany()
                        .HasForeignKey("RaceId");
                });
#pragma warning restore 612, 618
        }
    }
}
