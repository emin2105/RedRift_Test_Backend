﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using RedRift_Test_Backend.Data.Context;

#nullable disable

namespace RedRift_Test_Backend.Data.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20220601091856_Initial")]
    partial class Initial
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.5")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.GameRoom", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<Guid?>("HostId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<bool>("IsOpen")
                        .HasColumnType("bit");

                    b.HasKey("Id");

                    b.HasIndex("HostId");

                    b.ToTable("GameRooms");
                });

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.PlayerSession", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.Property<Guid?>("GameRoomId")
                        .HasColumnType("uniqueidentifier");

                    b.Property<int>("Health")
                        .HasColumnType("int");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.HasIndex("GameRoomId");

                    b.HasIndex("UserId");

                    b.ToTable("PlayerSessions");
                });

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.User", b =>
                {
                    b.Property<Guid>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.GameRoom", b =>
                {
                    b.HasOne("RedRift_Test_Backend.Data.Models.User", "Host")
                        .WithMany()
                        .HasForeignKey("HostId");

                    b.Navigation("Host");
                });

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.PlayerSession", b =>
                {
                    b.HasOne("RedRift_Test_Backend.Data.Models.GameRoom", "GameRoom")
                        .WithMany("Players")
                        .HasForeignKey("GameRoomId");

                    b.HasOne("RedRift_Test_Backend.Data.Models.User", "User")
                        .WithMany("PlayerSessions")
                        .HasForeignKey("UserId");

                    b.Navigation("GameRoom");

                    b.Navigation("User");
                });

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.GameRoom", b =>
                {
                    b.Navigation("Players");
                });

            modelBuilder.Entity("RedRift_Test_Backend.Data.Models.User", b =>
                {
                    b.Navigation("PlayerSessions");
                });
#pragma warning restore 612, 618
        }
    }
}
