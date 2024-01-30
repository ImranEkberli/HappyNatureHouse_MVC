﻿// <auto-generated />
using System;
using HappyNatureHouse_MVC.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace HappyNatureHouse_MVC.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "7.0.15")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.AdminUser", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("AdminUsers");
                });

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.Cottage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<DateTime>("CreateDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal?>("DiscountPrice")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("DoubleBed")
                        .HasColumnType("int");

                    b.Property<int>("GuestCount")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("ModifierDate")
                        .HasColumnType("datetime2");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<decimal>("Price")
                        .HasColumnType("decimal(18,2)");

                    b.Property<int>("RoomCount")
                        .HasColumnType("int");

                    b.Property<int>("SingleBed")
                        .HasColumnType("int");

                    b.Property<bool>("Status")
                        .HasColumnType("bit");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Cottages");
                });

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.CottageImage", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CottageId")
                        .HasColumnType("int");

                    b.Property<int?>("CottageRoomId")
                        .HasColumnType("int");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CottageId");

                    b.HasIndex("CottageRoomId");

                    b.ToTable("CottageImages");
                });

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.CottageRoom", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<int>("CottageId")
                        .HasColumnType("int");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Image")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Title")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("CottageId");

                    b.ToTable("CottageRooms");
                });

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.CottageImage", b =>
                {
                    b.HasOne("HappyNatureHouse_MVC.Models.Cottage", "Cottage")
                        .WithMany("CottageImages")
                        .HasForeignKey("CottageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("HappyNatureHouse_MVC.Models.CottageRoom", "CottageRoom")
                        .WithMany()
                        .HasForeignKey("CottageRoomId");

                    b.Navigation("Cottage");

                    b.Navigation("CottageRoom");
                });

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.CottageRoom", b =>
                {
                    b.HasOne("HappyNatureHouse_MVC.Models.Cottage", "Cottage")
                        .WithMany("CottageRooms")
                        .HasForeignKey("CottageId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Cottage");
                });

            modelBuilder.Entity("HappyNatureHouse_MVC.Models.Cottage", b =>
                {
                    b.Navigation("CottageImages");

                    b.Navigation("CottageRooms");
                });
#pragma warning restore 612, 618
        }
    }
}
