﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using StalNoteM;

#nullable disable

namespace StalNoteM.Migrations
{
    [DbContext(typeof(ApplicationDbContext))]
    [Migration("20240407205942_3_9_mig")]
    partial class _3_9_mig
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.2")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("StalNoteM.Data.AuctionItem.AucItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Ammount")
                        .HasColumnType("int");

                    b.Property<long?>("BuyoutPrice")
                        .HasColumnType("bigint");

                    b.Property<long?>("CurrentPrice")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("EndTime")
                        .HasColumnType("datetime2");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Pottential")
                        .HasColumnType("int");

                    b.Property<int?>("Quality")
                        .HasColumnType("int");

                    b.Property<long?>("StartPrice")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("StartTime")
                        .HasColumnType("datetime2");

                    b.Property<bool>("State")
                        .HasColumnType("bit");

                    b.Property<double?>("Stats")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("AucItems");
                });

            modelBuilder.Entity("StalNoteM.Data.AuctionItem.SelledItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int?>("Amount")
                        .HasColumnType("int");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<int?>("Pottential")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int?>("Quality")
                        .HasColumnType("int");

                    b.Property<double?>("Stats")
                        .HasColumnType("float");

                    b.Property<DateTime>("Time")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("SelledItems");
                });

            modelBuilder.Entity("StalNoteM.Data.DataItem.ArmorItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("BioinfectionProtection")
                        .HasColumnType("float");

                    b.Property<double>("Bleeding")
                        .HasColumnType("float");

                    b.Property<double>("BleedingProtection")
                        .HasColumnType("float");

                    b.Property<double>("BulletResistance")
                        .HasColumnType("float");

                    b.Property<double>("CarryWeight")
                        .HasColumnType("float");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("CompatibleBackpacks")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("CompatibleContainers")
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("ExplosionProtection")
                        .HasColumnType("float");

                    b.Property<string>("Features")
                        .HasMaxLength(500)
                        .HasColumnType("nvarchar(500)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("LacerationProtection")
                        .HasColumnType("float");

                    b.Property<double>("MoveSpeed")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<double>("PeriodicHealing")
                        .HasColumnType("float");

                    b.Property<int>("Pottential")
                        .HasColumnType("int");

                    b.Property<double>("PsyProtection")
                        .HasColumnType("float");

                    b.Property<double>("RadiationProtection")
                        .HasColumnType("float");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("ResistanceToChemicals")
                        .HasColumnType("float");

                    b.Property<double>("ResistanceToElectricity")
                        .HasColumnType("float");

                    b.Property<double>("ResistanceToFire")
                        .HasColumnType("float");

                    b.Property<double>("Stability")
                        .HasColumnType("float");

                    b.Property<double>("Stamina")
                        .HasColumnType("float");

                    b.Property<double>("StaminaRegeneration")
                        .HasColumnType("float");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("ThermalProtection")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("ArmorsItems");
                });

            modelBuilder.Entity("StalNoteM.Data.DataItem.Bullet", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AmmoType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("ArmorPenetration")
                        .HasColumnType("float");

                    b.Property<double>("Bleeding")
                        .HasColumnType("float");

                    b.Property<double>("Burning")
                        .HasColumnType("float");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Damage")
                        .HasColumnType("float");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("NumberOfProjectiles")
                        .HasColumnType("float");

                    b.Property<double>("Spread")
                        .HasColumnType("float");

                    b.Property<double>("StoppingPower")
                        .HasColumnType("float");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("Bullets");
                });

            modelBuilder.Entity("StalNoteM.Data.DataItem.SqlItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("AveragePrice")
                        .HasColumnType("bigint");

                    b.Property<bool>("Finding")
                        .HasColumnType("bit");

                    b.Property<string>("ImgWay")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(15)
                        .HasColumnType("nvarchar(15)");

                    b.Property<long>("MinBuyPrice")
                        .HasColumnType("bigint");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(70)
                        .HasColumnType("nvarchar(70)");

                    b.Property<int?>("Pottential")
                        .HasColumnType("int");

                    b.Property<int?>("Quality")
                        .HasColumnType("int");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.HasKey("Id");

                    b.ToTable("SqlItems");
                });

            modelBuilder.Entity("StalNoteM.Data.DataItem.WeaponItem", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<double>("AimingTime")
                        .HasColumnType("float");

                    b.Property<string>("AmmoType")
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<double>("ArmorPenetration")
                        .HasColumnType("float");

                    b.Property<double>("Bleeding")
                        .HasColumnType("float");

                    b.Property<string>("Class")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("Damage")
                        .HasColumnType("float");

                    b.Property<double>("DamageDecreaseEnd")
                        .HasColumnType("float");

                    b.Property<double>("DamageDecreaseStart")
                        .HasColumnType("float");

                    b.Property<double>("DamageModifierHeadshot")
                        .HasColumnType("float");

                    b.Property<double>("DamageModifierLimb")
                        .HasColumnType("float");

                    b.Property<double>("DamageToMutants")
                        .HasColumnType("float");

                    b.Property<string>("Description")
                        .HasMaxLength(1000)
                        .HasColumnType("nvarchar(1000)");

                    b.Property<double>("DrawTime")
                        .HasColumnType("float");

                    b.Property<double>("EndDamage")
                        .HasColumnType("float");

                    b.Property<string>("Features")
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<double>("HipFireSpread")
                        .HasColumnType("float");

                    b.Property<double>("HorizontalRecoil")
                        .HasColumnType("float");

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("MagazineCapacity")
                        .HasColumnType("float");

                    b.Property<double>("MaxDistance")
                        .HasColumnType("float");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int>("Pottential")
                        .HasColumnType("int");

                    b.Property<string>("Rank")
                        .IsRequired()
                        .HasMaxLength(30)
                        .HasColumnType("nvarchar(30)");

                    b.Property<double>("RateOfFire")
                        .HasColumnType("float");

                    b.Property<double>("Reload")
                        .HasColumnType("float");

                    b.Property<double>("Spread")
                        .HasColumnType("float");

                    b.Property<double>("StartDamage")
                        .HasColumnType("float");

                    b.Property<double>("StoppingPower")
                        .HasColumnType("float");

                    b.Property<string>("SubType")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("TacticalReload")
                        .HasColumnType("float");

                    b.Property<string>("Type")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<double>("VerticalRecoil")
                        .HasColumnType("float");

                    b.Property<double>("Weight")
                        .HasColumnType("float");

                    b.HasKey("Id");

                    b.ToTable("WeaponsItems");
                });

            modelBuilder.Entity("StalNoteM.Data.Other.Advertising", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("Context")
                        .IsRequired()
                        .HasMaxLength(200)
                        .HasColumnType("nvarchar(200)");

                    b.Property<int?>("Count")
                        .HasColumnType("int");

                    b.Property<DateTime?>("End")
                        .HasColumnType("datetime2");

                    b.Property<string>("NameCustomer")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<DateTime?>("Start")
                        .HasColumnType("datetime2");

                    b.HasKey("Id");

                    b.ToTable("Advertisings");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.Role", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<double>("Cost")
                        .HasColumnType("float");

                    b.Property<int>("MaxArt")
                        .HasColumnType("int");

                    b.Property<int>("MaxCase")
                        .HasColumnType("int");

                    b.Property<int>("MaxLot")
                        .HasColumnType("int");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.User", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("EndRole")
                        .HasColumnType("datetime2");

                    b.Property<bool>("LockoutEnabled")
                        .HasColumnType("bit");

                    b.Property<DateTimeOffset?>("LockoutEnd")
                        .HasColumnType("datetimeoffset");

                    b.Property<string>("NormalizedEmail")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedUserName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PasswordHash")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("PhoneNumber")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("PhoneNumberConfirmed")
                        .HasColumnType("bit");

                    b.Property<long>("RoleId")
                        .HasColumnType("bigint");

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("StartRole")
                        .HasColumnType("datetime2");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.HasIndex("RoleId");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserConfig", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<bool>("ShowArt")
                        .HasColumnType("bit");

                    b.Property<bool>("ShowGraph")
                        .HasColumnType("bit");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserConfig");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserItem", b =>
                {
                    b.Property<long>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("bigint");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<long>("Id"));

                    b.Property<string>("ItemId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .HasColumnType("nvarchar(20)");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasMaxLength(100)
                        .HasColumnType("nvarchar(100)");

                    b.Property<int?>("Pottential")
                        .HasColumnType("int");

                    b.Property<long>("Price")
                        .HasColumnType("bigint");

                    b.Property<int?>("Quality")
                        .HasColumnType("int");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId");

                    b.ToTable("UserItems");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserTelegram", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<long>("ChatId")
                        .HasColumnType("bigint");

                    b.Property<string>("FirstName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<string>("LastName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.Property<string>("UserName")
                        .HasMaxLength(50)
                        .HasColumnType("nvarchar(50)");

                    b.Property<long>("UserTelegramId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserTelegrams");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserToken", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"));

                    b.Property<string>("AccessCode")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("AccessToken")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<string>("RefreshToken")
                        .HasMaxLength(2000)
                        .HasColumnType("nvarchar(2000)");

                    b.Property<long>("UserId")
                        .HasColumnType("bigint");

                    b.HasKey("Id");

                    b.HasIndex("UserId")
                        .IsUnique();

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.User", b =>
                {
                    b.HasOne("StalNoteM.Data.Users.Role", "Role")
                        .WithMany("Users")
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Role");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserConfig", b =>
                {
                    b.HasOne("StalNoteM.Data.Users.User", "User")
                        .WithOne("UserConfig")
                        .HasForeignKey("StalNoteM.Data.Users.UserConfig", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserItem", b =>
                {
                    b.HasOne("StalNoteM.Data.Users.User", "User")
                        .WithMany("UserItems")
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserTelegram", b =>
                {
                    b.HasOne("StalNoteM.Data.Users.User", "User")
                        .WithOne("UserTelegram")
                        .HasForeignKey("StalNoteM.Data.Users.UserTelegram", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.UserToken", b =>
                {
                    b.HasOne("StalNoteM.Data.Users.User", "User")
                        .WithOne("UserToken")
                        .HasForeignKey("StalNoteM.Data.Users.UserToken", "UserId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("User");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.Role", b =>
                {
                    b.Navigation("Users");
                });

            modelBuilder.Entity("StalNoteM.Data.Users.User", b =>
                {
                    b.Navigation("UserConfig")
                        .IsRequired();

                    b.Navigation("UserItems");

                    b.Navigation("UserTelegram")
                        .IsRequired();

                    b.Navigation("UserToken")
                        .IsRequired();
                });
#pragma warning restore 612, 618
        }
    }
}
