using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Data.Models
{
    public partial class HostelDBContext : IdentityDbContext
    {
        public HostelDBContext()
        {
        }

        public HostelDBContext(DbContextOptions<HostelDBContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Branch> Branches { get; set; } = null!;
        public virtual DbSet<FeeDetail> FeeDetails { get; set; } = null!;
        public virtual DbSet<Hostel> Hostels { get; set; } = null!;
        public virtual DbSet<Role> Roles { get; set; } = null!;
        public virtual DbSet<Room> Rooms { get; set; } = null!;
        public virtual DbSet<RoomBed> RoomBeds { get; set; } = null!;
        public virtual DbSet<Tenant> Tenants { get; set; } = null!;
        public virtual DbSet<TenantBedMapping> TenantBedMappings { get; set; } = null!;
        public virtual DbSet<UserProfile> UserProfiles { get; set; } = null!;
        public virtual DbSet<DailyWage> DailyWages { get; set; } = null!;
        public virtual DbSet<GuestDetail> GuestDetails { get; set; } = null!;
        public virtual DbSet<GuestUser> GuestUsers { get; set; } = null!;

//        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//        {
//            if (!optionsBuilder.IsConfigured)
//            {
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
//                optionsBuilder.UseSqlServer("Data Source=LAPTOP-PV9HN5R2\\SQLEXPRESS03;Initial Catalog=HostelDB;Integrated Security=True");
//            }
//        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Branch>(entity =>
            {
                entity.HasKey(e => e.PkbranchId)
                    .HasName("PK__Branch__A699DE14FF64BD75");

                entity.ToTable("Branch");

                entity.Property(e => e.PkbranchId).HasColumnName("PKBranchId");

                entity.Property(e => e.BranchName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.FkcreatedBy).HasColumnName("FKCreatedBy");

                entity.Property(e => e.FkhostelId).HasColumnName("FKHostelId");

                entity.Property(e => e.Location)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.HasOne(d => d.FkcreatedByNavigation)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.FkcreatedBy)
                    .HasConstraintName("FK_Branch_UserProfile");

                entity.HasOne(d => d.Fkhostel)
                    .WithMany(p => p.Branches)
                    .HasForeignKey(d => d.FkhostelId)
                    .HasConstraintName("FK_Branch_Hostel");
            });

            modelBuilder.Entity<FeeDetail>(entity =>
            {
                entity.HasKey(e => e.PkfeeDetailsId)
                    .HasName("PK__FeeDetai__88B3EF8CE37A962B");

                entity.Property(e => e.PkfeeDetailsId).HasColumnName("PKFeeDetailsId");

                entity.Property(e => e.AdditionalAmount).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.DueAmount).HasColumnType("money");

                entity.Property(e => e.FeeAmount).HasColumnType("money");

                entity.Property(e => e.FeeDate).HasColumnType("datetime");

                entity.Property(e => e.Fkcreatedby).HasColumnName("FKCreatedby");

                entity.Property(e => e.FkmodifiedBy).HasColumnName("FKModifiedBy");

                entity.Property(e => e.FktenantId).HasColumnName("FKTenantId");

                entity.Property(e => e.FoodBill).HasColumnType("money");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.Status).HasColumnName("status");

                entity.Property(e => e.TransactionType)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkcreatedbyNavigation)
                    .WithMany(p => p.FeeDetailFkcreatedbyNavigations)
                    .HasForeignKey(d => d.Fkcreatedby)
                    .HasConstraintName("FK_FeeDetails1_UserProfile");

                entity.HasOne(d => d.FkmodifiedByNavigation)
                    .WithMany(p => p.FeeDetailFkmodifiedByNavigations)
                    .HasForeignKey(d => d.FkmodifiedBy)
                    .HasConstraintName("FK_FeeDetails2_UserProfile");

                entity.HasOne(d => d.Fktenant)
                    .WithMany(p => p.FeeDetails)
                    .HasForeignKey(d => d.FktenantId)
                    .HasConstraintName("FK_FeeDetails_Tenant");
            });

            modelBuilder.Entity<Hostel>(entity =>
            {
                entity.HasKey(e => e.PkhostelId)
                    .HasName("PK__Hostel__EB7BBC4A0FB5BEF7");

                entity.ToTable("Hostel");

                entity.Property(e => e.PkhostelId).HasColumnName("PKHostelId");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.FkcreatedBy).HasColumnName("FKCreatedBy");

                entity.Property(e => e.HostelName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.HasOne(d => d.FkcreatedByNavigation)
                    .WithMany(p => p.Hostels)
                    .HasForeignKey(d => d.FkcreatedBy)
                    .HasConstraintName("FK_Hostel_UserProfile");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.HasKey(e => e.PkroleId)
                    .HasName("PK__Role__B96213F4837A76E6");

                entity.ToTable("Role");

                entity.Property(e => e.PkroleId).HasColumnName("PKRoleId");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.RoleName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Room>(entity =>
            {
                entity.HasKey(e => e.PkroomId)
                    .HasName("PK__Room__4D64ACC37C5529DE");

                entity.ToTable("Room");

                entity.Property(e => e.PkroomId).HasColumnName("PKRoomId");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.FilledBeds).HasDefaultValueSql("((0))");

                entity.Property(e => e.FkbranchId).HasColumnName("FKBranchId");

                entity.Property(e => e.FkhostelId).HasColumnName("FKHostelId");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.RoomName)
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<RoomBed>(entity =>
            {
                entity.HasKey(e => e.PkbedId)
                    .HasName("PK__RoomBed__14EF6E39FD9903B5");

                entity.ToTable("RoomBed");

                entity.Property(e => e.PkbedId).HasColumnName("PKBedId");

                entity.Property(e => e.BedName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.Fkcreatedby)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FKCreatedby");

                entity.Property(e => e.FkmodifiedBy)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("FKModifiedBy");

                entity.Property(e => e.FkroomId).HasColumnName("FKRoomId");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.HasOne(d => d.Fkroom)
                    .WithMany(p => p.RoomBeds)
                    .HasForeignKey(d => d.FkroomId)
                    .HasConstraintName("FK_RoomBed_Room");
            });

            modelBuilder.Entity<Tenant>(entity =>
            {
                entity.HasKey(e => e.PktenantId)
                    .HasName("PK__Tenant__C9A21FB50CA9CAFB");

                entity.ToTable("Tenant");

                entity.Property(e => e.PktenantId).HasColumnName("PKTenantId");

                entity.Property(e => e.AdvancePayment).HasColumnType("money");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.Designation)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.DocumentUrl).IsUnicode(false);

                entity.Property(e => e.EmailId)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.Fkcreatedby).HasColumnName("FKCreatedby");

                entity.Property(e => e.FkmodifiedBy).HasColumnName("FKModifiedBy");

                entity.Property(e => e.FkroomId).HasColumnName("FKRoomId");

                entity.Property(e => e.Gender)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.HomeAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.MonthlyFee).HasColumnType("money");

                entity.Property(e => e.OfficeAddress)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.PhotoUrl)
                    .HasColumnType("image")
                    .HasColumnName("PhotoURL");

                entity.Property(e => e.ProofId)
                    .HasMaxLength(20)
                    .IsUnicode(false)
                    .HasColumnName("ProofID");

                entity.Property(e => e.ProofName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.RegisteredDate).HasColumnType("datetime");

                entity.Property(e => e.TenantName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.FkcreatedbyNavigation)
                    .WithMany(p => p.TenantFkcreatedbyNavigations)
                    .HasForeignKey(d => d.Fkcreatedby)
                    .HasConstraintName("FK_Tenant_UserProfile");

                entity.HasOne(d => d.FkmodifiedByNavigation)
                    .WithMany(p => p.TenantFkmodifiedByNavigations)
                    .HasForeignKey(d => d.FkmodifiedBy)
                    .HasConstraintName("FK_Tenant1_UserProfile");

                entity.HasOne(d => d.Fkroom)
                    .WithMany(p => p.Tenants)
                    .HasForeignKey(d => d.FkroomId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Tenant_Room");
            });

            modelBuilder.Entity<TenantBedMapping>(entity =>
            {
                entity.HasKey(e => e.PktenantBedId)
                    .HasName("PK__TenantBe__31CF726F407417E2");

                entity.ToTable("TenantBedMapping");

                entity.Property(e => e.PktenantBedId).HasColumnName("PKTenantBedId");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.FkbedId).HasColumnName("FKBedId");

                entity.Property(e => e.Fkcreatedby).HasColumnName("FKCreatedby");

                entity.Property(e => e.FkmodifiedBy).HasColumnName("FKModifiedBy");

                entity.Property(e => e.FktenantId).HasColumnName("FKTenantId");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.HasOne(d => d.Fkbed)
                    .WithMany(p => p.TenantBedMappings)
                    .HasForeignKey(d => d.FkbedId)
                    .HasConstraintName("FK_TenantBedMapping_RoomBed");

                entity.HasOne(d => d.FkcreatedbyNavigation)
                    .WithMany(p => p.TenantBedMappingFkcreatedbyNavigations)
                    .HasForeignKey(d => d.Fkcreatedby)
                    .HasConstraintName("FK_TenantBedMapping2_UserProfile");

                entity.HasOne(d => d.FkmodifiedByNavigation)
                    .WithMany(p => p.TenantBedMappingFkmodifiedByNavigations)
                    .HasForeignKey(d => d.FkmodifiedBy)
                    .HasConstraintName("FK_TenantBedMapping3_UserProfile");

                entity.HasOne(d => d.Fktenant)
                    .WithMany(p => p.TenantBedMappings)
                    .HasForeignKey(d => d.FktenantId)
                    .HasConstraintName("FK_TenantBedMapping1_Tenant");
            });

            modelBuilder.Entity<UserProfile>(entity =>
            {
                entity.HasKey(e => e.PkuserId)
                    .HasName("PK__UserProf__CCB89530EAC38D6B");

                entity.ToTable("UserProfile");

                entity.Property(e => e.PkuserId).HasColumnName("PKUserId");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasColumnName("created");

                entity.Property(e => e.Email)
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.FkroleId).HasColumnName("FKRoleId");

                entity.Property(e => e.Modified)
                    .HasColumnType("datetime")
                    .HasColumnName("modified");

                entity.Property(e => e.Password)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.Property(e => e.UserName)
                    .HasMaxLength(20)
                    .IsUnicode(false);

                entity.HasOne(d => d.Fkrole)
                    .WithMany(p => p.UserProfiles)
                    .HasForeignKey(d => d.FkroleId)
                    .HasConstraintName("FK_UserProfile_Role");
            });
            modelBuilder.Entity<DailyWage>(entity =>
            {
                entity.HasKey(e => e.PKDailyWageId)
                    .HasName("PK__DailyWage__B96213F4837A76E6");

                entity.ToTable("DailyWage");

                entity.Property(e => e.PKDailyWageId).HasColumnName("PKDailyWageId");

             
            });

            modelBuilder.Entity<IdentityUserLogin<string>>(entity => {
                entity.HasNoKey();
            });


            modelBuilder.Entity<IdentityUserRole<string>>(entity => {
                entity.HasNoKey();
            });

            modelBuilder.Entity<IdentityUserToken<string>>(entity => {
                entity.HasNoKey();
            });


            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
