using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using RentalMotorbike.BusinessObject.Entities;

namespace RentalMotorbike.BusinessObject;

public partial class RentalMotoBikeContext : DbContext
{
    public RentalMotoBikeContext()
    {
    }

    public RentalMotoBikeContext(DbContextOptions<RentalMotoBikeContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Maintenance> Maintenances { get; set; }

    public virtual DbSet<Motorbike> Motorbikes { get; set; }

    public virtual DbSet<MotorbikeStatus> MotorbikeStatuses { get; set; }

    public virtual DbSet<Rental> Rentals { get; set; }

    public virtual DbSet<RentalDetail> RentalDetails { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Server=(local);Database= RentalMotoBike;UID=sa;PWD=12345;TrustServerCertificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Maintenance>(entity =>
        {
            entity.HasKey(e => e.MaintenanceId).HasName("PK__Maintena__E60542B5F3A6FE71");

            entity.ToTable("Maintenance");

            entity.Property(e => e.MaintenanceId).HasColumnName("MaintenanceID");
            entity.Property(e => e.Cost).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.Description).HasMaxLength(255);
            entity.Property(e => e.MaintenanceDate).HasColumnType("datetime");
            entity.Property(e => e.MotorbikeId).HasColumnName("MotorbikeID");
            entity.Property(e => e.Status).HasMaxLength(20);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Motorbike).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.MotorbikeId)
                .HasConstraintName("FK__Maintenan__Motor__59FA5E80");

            entity.HasOne(d => d.User).WithMany(p => p.Maintenances)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Maintenan__UserI__5AEE82B9");
        });

        modelBuilder.Entity<Motorbike>(entity =>
        {
            entity.HasKey(e => e.MotorbikeId).HasName("PK__Motorbik__FC02B63B6E4AA858");

            entity.ToTable("Motorbike");

            entity.Property(e => e.MotorbikeId).HasColumnName("MotorbikeID");
            entity.Property(e => e.Brand).HasMaxLength(50);
            entity.Property(e => e.LicensePlate).HasMaxLength(20);
            entity.Property(e => e.Model).HasMaxLength(50);
            entity.Property(e => e.RentalPricePerDay).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.StatusId).HasColumnName("StatusID");

            entity.HasOne(d => d.Status).WithMany(p => p.Motorbikes)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Motorbike__Statu__5070F446");
        });

        modelBuilder.Entity<MotorbikeStatus>(entity =>
        {
            entity.HasKey(e => e.StatusId).HasName("PK__Motorbik__C8EE2043A284E805");

            entity.ToTable("MotorbikeStatus");

            entity.Property(e => e.StatusId).HasColumnName("StatusID");
            entity.Property(e => e.StatusName).HasMaxLength(50);
        });

        modelBuilder.Entity<Rental>(entity =>
        {
            entity.HasKey(e => e.RentalId).HasName("PK__Rental__970059636A795BA3");

            entity.ToTable("Rental");

            entity.Property(e => e.RentalId).HasColumnName("RentalID");
            entity.Property(e => e.EndDate).HasColumnType("datetime");
            entity.Property(e => e.MotorbikeId).HasColumnName("MotorbikeID");
            entity.Property(e => e.StartDate).HasColumnType("datetime");
            entity.Property(e => e.TotalPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Motorbike).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.MotorbikeId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Rental__Motorbik__5441852A");

            entity.HasOne(d => d.User).WithMany(p => p.Rentals)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.SetNull)
                .HasConstraintName("FK__Rental__UserID__534D60F1");
        });

        modelBuilder.Entity<RentalDetail>(entity =>
        {
            entity.HasKey(e => e.RentalDetailId).HasName("PK__RentalDe__10B359990F84305A");

            entity.ToTable("RentalDetail");

            entity.Property(e => e.RentalDetailId).HasColumnName("RentalDetailID");
            entity.Property(e => e.DailyPrice).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.RentalId).HasColumnName("RentalID");
            entity.Property(e => e.TotalCost).HasColumnType("decimal(18, 2)");

            entity.HasOne(d => d.Rental).WithMany(p => p.RentalDetails)
                .HasForeignKey(d => d.RentalId)
                .HasConstraintName("FK__RentalDet__Renta__571DF1D5");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3A36288E0E");

            entity.ToTable("Role");

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCACCFCE7F6F");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.PasswordHash).HasMaxLength(100);
            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasOne(d => d.Role).WithMany(p => p.Users)
                .HasForeignKey(d => d.RoleId)
                .HasConstraintName("FK__Users__RoleID__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
