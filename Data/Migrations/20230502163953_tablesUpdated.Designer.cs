﻿// <auto-generated />
using System;
using Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

#nullable disable

namespace Data.Migrations
{
    [DbContext(typeof(HostelDBContext))]
    [Migration("20230502163953_tablesUpdated")]
    partial class tablesUpdated
    {
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "6.0.14")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, 1L, 1);

            modelBuilder.Entity("Data.Models.Branch", b =>
                {
                    b.Property<int>("PkbranchId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKBranchId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkbranchId"), 1L, 1);

                    b.Property<string>("BranchName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<int?>("FkcreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("FKCreatedBy");

                    b.Property<int?>("FkhostelId")
                        .HasColumnType("int")
                        .HasColumnName("FKHostelId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<string>("Location")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.HasKey("PkbranchId")
                        .HasName("PK__Branch__A699DE14FF64BD75");

                    b.HasIndex("FkcreatedBy");

                    b.HasIndex("FkhostelId");

                    b.ToTable("Branch", (string)null);
                });

            modelBuilder.Entity("Data.Models.DailyWage", b =>
                {
                    b.Property<int>("PKDailyWageId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKDailyWageId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PKDailyWageId"), 1L, 1);

                    b.Property<decimal>("Amount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime2");

                    b.Property<int?>("FkbranchId")
                        .HasColumnType("int");

                    b.Property<int?>("Fkcreatedby")
                        .HasColumnType("int");

                    b.Property<int?>("FkcreatedbyNavigationPkuserId")
                        .HasColumnType("int");

                    b.Property<int?>("FkhostelPkhostelId")
                        .HasColumnType("int");

                    b.Property<int?>("FkmodifiedBy")
                        .HasColumnType("int");

                    b.Property<int?>("FkmodifiedByNavigationPkuserId")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime2");

                    b.Property<string>("Note")
                        .IsRequired()
                        .HasColumnType("nvarchar(max)");

                    b.Property<byte>("Status")
                        .HasColumnType("tinyint");

                    b.Property<byte>("WageType")
                        .HasColumnType("tinyint");

                    b.HasKey("PKDailyWageId")
                        .HasName("PK__DailyWage__B96213F4837A76E6");

                    b.HasIndex("FkbranchId");

                    b.HasIndex("FkcreatedbyNavigationPkuserId");

                    b.HasIndex("FkhostelPkhostelId");

                    b.HasIndex("FkmodifiedByNavigationPkuserId");

                    b.ToTable("DailyWage", (string)null);
                });

            modelBuilder.Entity("Data.Models.FeeDetail", b =>
                {
                    b.Property<int>("PkfeeDetailsId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKFeeDetailsId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkfeeDetailsId"), 1L, 1);

                    b.Property<decimal?>("AdditionalAmount")
                        .HasColumnType("money");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<decimal?>("DueAmount")
                        .HasColumnType("money");

                    b.Property<decimal?>("FeeAmount")
                        .HasColumnType("money");

                    b.Property<DateTime?>("FeeDate")
                        .HasColumnType("datetime");

                    b.Property<byte?>("FeeMode")
                        .HasColumnType("tinyint");

                    b.Property<int?>("Fkcreatedby")
                        .HasColumnType("int")
                        .HasColumnName("FKCreatedby");

                    b.Property<int?>("FkmodifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("FKModifiedBy");

                    b.Property<int?>("FktenantId")
                        .HasColumnType("int")
                        .HasColumnName("FKTenantId");

                    b.Property<decimal?>("FoodBill")
                        .HasColumnType("money");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.Property<string>("Note")
                        .HasColumnType("nvarchar(max)");

                    b.Property<DateTime?>("PaidDate")
                        .HasColumnType("datetime");

                    b.Property<decimal?>("ReceivedAmount")
                        .HasColumnType("decimal(18,2)");

                    b.Property<byte?>("Status")
                        .HasColumnType("tinyint")
                        .HasColumnName("status");

                    b.Property<string>("TransactionType")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("PkfeeDetailsId")
                        .HasName("PK__FeeDetai__88B3EF8CE37A962B");

                    b.HasIndex("Fkcreatedby");

                    b.HasIndex("FkmodifiedBy");

                    b.HasIndex("FktenantId");

                    b.ToTable("FeeDetails");
                });

            modelBuilder.Entity("Data.Models.Hostel", b =>
                {
                    b.Property<int>("PkhostelId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKHostelId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkhostelId"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<int?>("FkcreatedBy")
                        .HasColumnType("int")
                        .HasColumnName("FKCreatedBy");

                    b.Property<string>("HostelName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.HasKey("PkhostelId")
                        .HasName("PK__Hostel__EB7BBC4A0FB5BEF7");

                    b.HasIndex("FkcreatedBy");

                    b.ToTable("Hostel", (string)null);
                });

            modelBuilder.Entity("Data.Models.Role", b =>
                {
                    b.Property<int>("PkroleId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKRoleId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkroleId"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.Property<string>("RoleName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("PkroleId")
                        .HasName("PK__Role__B96213F4837A76E6");

                    b.ToTable("Role", (string)null);
                });

            modelBuilder.Entity("Data.Models.Room", b =>
                {
                    b.Property<int>("PkroomId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKRoomId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkroomId"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<int?>("FilledBeds")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasDefaultValueSql("((0))");

                    b.Property<int?>("FkbranchId")
                        .HasColumnType("int")
                        .HasColumnName("FKBranchId");

                    b.Property<int>("FkhostelId")
                        .HasColumnType("int")
                        .HasColumnName("FKHostelId");

                    b.Property<bool>("IsGuestRoom")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.Property<int?>("NumberOfBeds")
                        .HasColumnType("int");

                    b.Property<string>("RoomName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<byte?>("RoomStatus")
                        .HasColumnType("tinyint");

                    b.Property<byte?>("RoomType")
                        .HasColumnType("tinyint");

                    b.HasKey("PkroomId")
                        .HasName("PK__Room__4D64ACC37C5529DE");

                    b.HasIndex("FkbranchId");

                    b.HasIndex("FkhostelId");

                    b.ToTable("Room", (string)null);
                });

            modelBuilder.Entity("Data.Models.RoomBed", b =>
                {
                    b.Property<int>("PkbedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKBedId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkbedId"), 1L, 1);

                    b.Property<string>("BedName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<string>("Fkcreatedby")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("FKCreatedby");

                    b.Property<string>("FkmodifiedBy")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("FKModifiedBy");

                    b.Property<int?>("FkroomId")
                        .HasColumnType("int")
                        .HasColumnName("FKRoomId");

                    b.Property<byte?>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.HasKey("PkbedId")
                        .HasName("PK__RoomBed__14EF6E39FD9903B5");

                    b.HasIndex("FkroomId");

                    b.ToTable("RoomBed", (string)null);
                });

            modelBuilder.Entity("Data.Models.Tenant", b =>
                {
                    b.Property<int>("PktenantId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKTenantId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PktenantId"), 1L, 1);

                    b.Property<decimal?>("AdvancePayment")
                        .HasColumnType("money");

                    b.Property<int>("Age")
                        .HasColumnType("int");

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<string>("Designation")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("DocumentUrl")
                        .IsUnicode(false)
                        .HasColumnType("varchar(max)");

                    b.Property<string>("EmailId")
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<int?>("Fkcreatedby")
                        .HasColumnType("int")
                        .HasColumnName("FKCreatedby");

                    b.Property<int?>("FkmodifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("FKModifiedBy");

                    b.Property<int>("FkroomId")
                        .HasColumnType("int")
                        .HasColumnName("FKRoomId");

                    b.Property<byte>("FoodCard")
                        .HasColumnType("tinyint");

                    b.Property<string>("Gender")
                        .HasMaxLength(10)
                        .IsUnicode(false)
                        .HasColumnType("varchar(10)");

                    b.Property<string>("HomeAddress")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<byte?>("IsActive")
                        .HasColumnType("tinyint");

                    b.Property<byte>("IsCoLiveIn")
                        .HasColumnType("tinyint");

                    b.Property<DateTime?>("LastDate")
                        .HasColumnType("datetime2");

                    b.Property<long>("MobileNo")
                        .HasColumnType("bigint");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.Property<decimal?>("MonthlyFee")
                        .HasColumnType("money");

                    b.Property<string>("OfficeAddress")
                        .HasMaxLength(100)
                        .IsUnicode(false)
                        .HasColumnType("varchar(100)");

                    b.Property<byte[]>("PhotoUrl")
                        .HasColumnType("image")
                        .HasColumnName("PhotoURL");

                    b.Property<string>("ProofId")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)")
                        .HasColumnName("ProofID");

                    b.Property<string>("ProofName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<DateTime?>("RegisteredDate")
                        .HasColumnType("datetime");

                    b.Property<string>("TenantName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("PktenantId")
                        .HasName("PK__Tenant__C9A21FB50CA9CAFB");

                    b.HasIndex("Fkcreatedby");

                    b.HasIndex("FkmodifiedBy");

                    b.HasIndex("FkroomId");

                    b.ToTable("Tenant", (string)null);
                });

            modelBuilder.Entity("Data.Models.TenantBedMapping", b =>
                {
                    b.Property<int>("PktenantBedId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKTenantBedId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PktenantBedId"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<int?>("FkbedId")
                        .HasColumnType("int")
                        .HasColumnName("FKBedId");

                    b.Property<int?>("Fkcreatedby")
                        .HasColumnType("int")
                        .HasColumnName("FKCreatedby");

                    b.Property<int?>("FkmodifiedBy")
                        .HasColumnType("int")
                        .HasColumnName("FKModifiedBy");

                    b.Property<int?>("FktenantId")
                        .HasColumnType("int")
                        .HasColumnName("FKTenantId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.HasKey("PktenantBedId")
                        .HasName("PK__TenantBe__31CF726F407417E2");

                    b.HasIndex("FkbedId");

                    b.HasIndex("Fkcreatedby");

                    b.HasIndex("FkmodifiedBy");

                    b.HasIndex("FktenantId");

                    b.ToTable("TenantBedMapping", (string)null);
                });

            modelBuilder.Entity("Data.Models.UserProfile", b =>
                {
                    b.Property<int>("PkuserId")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int")
                        .HasColumnName("PKUserId");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("PkuserId"), 1L, 1);

                    b.Property<DateTime?>("Created")
                        .HasColumnType("datetime")
                        .HasColumnName("created");

                    b.Property<string>("Email")
                        .HasMaxLength(255)
                        .IsUnicode(false)
                        .HasColumnType("varchar(255)");

                    b.Property<int?>("FkroleId")
                        .HasColumnType("int")
                        .HasColumnName("FKRoleId");

                    b.Property<bool?>("IsActive")
                        .HasColumnType("bit");

                    b.Property<DateTime?>("Modified")
                        .HasColumnType("datetime")
                        .HasColumnName("modified");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.Property<string>("UserName")
                        .IsRequired()
                        .HasMaxLength(20)
                        .IsUnicode(false)
                        .HasColumnType("varchar(20)");

                    b.HasKey("PkuserId")
                        .HasName("PK__UserProf__CCB89530EAC38D6B");

                    b.HasIndex("FkroleId");

                    b.ToTable("UserProfile", (string)null);
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRole", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("NormalizedName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Roles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityRoleClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("RoleClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUser", b =>
                {
                    b.Property<string>("Id")
                        .HasColumnType("nvarchar(450)");

                    b.Property<int>("AccessFailedCount")
                        .HasColumnType("int");

                    b.Property<string>("ConcurrencyStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Email")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("EmailConfirmed")
                        .HasColumnType("bit");

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

                    b.Property<string>("SecurityStamp")
                        .HasColumnType("nvarchar(max)");

                    b.Property<bool>("TwoFactorEnabled")
                        .HasColumnType("bit");

                    b.Property<string>("UserName")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("Users");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserClaim<string>", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("int");

                    SqlServerPropertyBuilderExtensions.UseIdentityColumn(b.Property<int>("Id"), 1L, 1);

                    b.Property<string>("ClaimType")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ClaimValue")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.HasKey("Id");

                    b.ToTable("UserClaims");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserLogin<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderDisplayName")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("ProviderKey")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserLogins");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserRole<string>", b =>
                {
                    b.Property<string>("RoleId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserRoles");
                });

            modelBuilder.Entity("Microsoft.AspNetCore.Identity.IdentityUserToken<string>", b =>
                {
                    b.Property<string>("LoginProvider")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Name")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("UserId")
                        .HasColumnType("nvarchar(max)");

                    b.Property<string>("Value")
                        .HasColumnType("nvarchar(max)");

                    b.ToTable("UserTokens");
                });

            modelBuilder.Entity("Data.Models.Branch", b =>
                {
                    b.HasOne("Data.Models.UserProfile", "FkcreatedByNavigation")
                        .WithMany("Branches")
                        .HasForeignKey("FkcreatedBy")
                        .HasConstraintName("FK_Branch_UserProfile");

                    b.HasOne("Data.Models.Hostel", "Fkhostel")
                        .WithMany("Branches")
                        .HasForeignKey("FkhostelId")
                        .HasConstraintName("FK_Branch_Hostel");

                    b.Navigation("FkcreatedByNavigation");

                    b.Navigation("Fkhostel");
                });

            modelBuilder.Entity("Data.Models.DailyWage", b =>
                {
                    b.HasOne("Data.Models.Branch", "Fkbranch")
                        .WithMany()
                        .HasForeignKey("FkbranchId");

                    b.HasOne("Data.Models.UserProfile", "FkcreatedbyNavigation")
                        .WithMany()
                        .HasForeignKey("FkcreatedbyNavigationPkuserId");

                    b.HasOne("Data.Models.Hostel", "Fkhostel")
                        .WithMany()
                        .HasForeignKey("FkhostelPkhostelId");

                    b.HasOne("Data.Models.UserProfile", "FkmodifiedByNavigation")
                        .WithMany()
                        .HasForeignKey("FkmodifiedByNavigationPkuserId");

                    b.Navigation("Fkbranch");

                    b.Navigation("FkcreatedbyNavigation");

                    b.Navigation("Fkhostel");

                    b.Navigation("FkmodifiedByNavigation");
                });

            modelBuilder.Entity("Data.Models.FeeDetail", b =>
                {
                    b.HasOne("Data.Models.UserProfile", "FkcreatedbyNavigation")
                        .WithMany("FeeDetailFkcreatedbyNavigations")
                        .HasForeignKey("Fkcreatedby")
                        .HasConstraintName("FK_FeeDetails1_UserProfile");

                    b.HasOne("Data.Models.UserProfile", "FkmodifiedByNavigation")
                        .WithMany("FeeDetailFkmodifiedByNavigations")
                        .HasForeignKey("FkmodifiedBy")
                        .HasConstraintName("FK_FeeDetails2_UserProfile");

                    b.HasOne("Data.Models.Tenant", "Fktenant")
                        .WithMany("FeeDetails")
                        .HasForeignKey("FktenantId")
                        .HasConstraintName("FK_FeeDetails_Tenant");

                    b.Navigation("FkcreatedbyNavigation");

                    b.Navigation("FkmodifiedByNavigation");

                    b.Navigation("Fktenant");
                });

            modelBuilder.Entity("Data.Models.Hostel", b =>
                {
                    b.HasOne("Data.Models.UserProfile", "FkcreatedByNavigation")
                        .WithMany("Hostels")
                        .HasForeignKey("FkcreatedBy")
                        .HasConstraintName("FK_Hostel_UserProfile");

                    b.Navigation("FkcreatedByNavigation");
                });

            modelBuilder.Entity("Data.Models.Room", b =>
                {
                    b.HasOne("Data.Models.Branch", "Fkbranch")
                        .WithMany()
                        .HasForeignKey("FkbranchId");

                    b.HasOne("Data.Models.Hostel", "Fkhostel")
                        .WithMany()
                        .HasForeignKey("FkhostelId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Fkbranch");

                    b.Navigation("Fkhostel");
                });

            modelBuilder.Entity("Data.Models.RoomBed", b =>
                {
                    b.HasOne("Data.Models.Room", "Fkroom")
                        .WithMany("RoomBeds")
                        .HasForeignKey("FkroomId")
                        .HasConstraintName("FK_RoomBed_Room");

                    b.Navigation("Fkroom");
                });

            modelBuilder.Entity("Data.Models.Tenant", b =>
                {
                    b.HasOne("Data.Models.UserProfile", "FkcreatedbyNavigation")
                        .WithMany("TenantFkcreatedbyNavigations")
                        .HasForeignKey("Fkcreatedby")
                        .HasConstraintName("FK_Tenant_UserProfile");

                    b.HasOne("Data.Models.UserProfile", "FkmodifiedByNavigation")
                        .WithMany("TenantFkmodifiedByNavigations")
                        .HasForeignKey("FkmodifiedBy")
                        .HasConstraintName("FK_Tenant1_UserProfile");

                    b.HasOne("Data.Models.Room", "Fkroom")
                        .WithMany("Tenants")
                        .HasForeignKey("FkroomId")
                        .IsRequired()
                        .HasConstraintName("FK_Tenant_Room");

                    b.Navigation("FkcreatedbyNavigation");

                    b.Navigation("FkmodifiedByNavigation");

                    b.Navigation("Fkroom");
                });

            modelBuilder.Entity("Data.Models.TenantBedMapping", b =>
                {
                    b.HasOne("Data.Models.RoomBed", "Fkbed")
                        .WithMany("TenantBedMappings")
                        .HasForeignKey("FkbedId")
                        .HasConstraintName("FK_TenantBedMapping_RoomBed");

                    b.HasOne("Data.Models.UserProfile", "FkcreatedbyNavigation")
                        .WithMany("TenantBedMappingFkcreatedbyNavigations")
                        .HasForeignKey("Fkcreatedby")
                        .HasConstraintName("FK_TenantBedMapping2_UserProfile");

                    b.HasOne("Data.Models.UserProfile", "FkmodifiedByNavigation")
                        .WithMany("TenantBedMappingFkmodifiedByNavigations")
                        .HasForeignKey("FkmodifiedBy")
                        .HasConstraintName("FK_TenantBedMapping3_UserProfile");

                    b.HasOne("Data.Models.Tenant", "Fktenant")
                        .WithMany("TenantBedMappings")
                        .HasForeignKey("FktenantId")
                        .HasConstraintName("FK_TenantBedMapping1_Tenant");

                    b.Navigation("Fkbed");

                    b.Navigation("FkcreatedbyNavigation");

                    b.Navigation("FkmodifiedByNavigation");

                    b.Navigation("Fktenant");
                });

            modelBuilder.Entity("Data.Models.UserProfile", b =>
                {
                    b.HasOne("Data.Models.Role", "Fkrole")
                        .WithMany("UserProfiles")
                        .HasForeignKey("FkroleId")
                        .HasConstraintName("FK_UserProfile_Role");

                    b.Navigation("Fkrole");
                });

            modelBuilder.Entity("Data.Models.Hostel", b =>
                {
                    b.Navigation("Branches");
                });

            modelBuilder.Entity("Data.Models.Role", b =>
                {
                    b.Navigation("UserProfiles");
                });

            modelBuilder.Entity("Data.Models.Room", b =>
                {
                    b.Navigation("RoomBeds");

                    b.Navigation("Tenants");
                });

            modelBuilder.Entity("Data.Models.RoomBed", b =>
                {
                    b.Navigation("TenantBedMappings");
                });

            modelBuilder.Entity("Data.Models.Tenant", b =>
                {
                    b.Navigation("FeeDetails");

                    b.Navigation("TenantBedMappings");
                });

            modelBuilder.Entity("Data.Models.UserProfile", b =>
                {
                    b.Navigation("Branches");

                    b.Navigation("FeeDetailFkcreatedbyNavigations");

                    b.Navigation("FeeDetailFkmodifiedByNavigations");

                    b.Navigation("Hostels");

                    b.Navigation("TenantBedMappingFkcreatedbyNavigations");

                    b.Navigation("TenantBedMappingFkmodifiedByNavigations");

                    b.Navigation("TenantFkcreatedbyNavigations");

                    b.Navigation("TenantFkmodifiedByNavigations");
                });
#pragma warning restore 612, 618
        }
    }
}
