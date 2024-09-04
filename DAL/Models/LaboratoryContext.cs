using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace DAL.Models;

public partial class LaboratoryContext : DbContext
{
    public LaboratoryContext()
    {
    }

    public LaboratoryContext(DbContextOptions<LaboratoryContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Customer> Customers { get; set; }

    public virtual DbSet<Device> Devices { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<Status> Statuses { get; set; }

    public virtual DbSet<StatusType> StatusTypes { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\USERS\\THIS USER\\DESKTOP\\קניון ליין\\LABORATORY\\DAL\\DB\\LABORATORYDB.MDF;Integrated Security=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Customer>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Customer__3214EC0791BCC326");

            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.FullName)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.Phone)
                .HasMaxLength(20)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        modelBuilder.Entity<Device>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Devices__3214EC0758E6EFCD");

            entity.Property(e => e.DeviceModel)
                .HasMaxLength(255)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.DeviceType)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
            entity.Property(e => e.EstimatedPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.FinalPrice).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.IssueDescription)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnType("text");
            entity.Property(e => e.Notes)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnType("text");
            entity.Property(e => e.UnlockCode)
                .HasMaxLength(50)
                .IsUnicode(false)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");

            entity.HasOne(d => d.Customer).WithMany(p => p.Devices)
                .HasForeignKey(d => d.CustomerId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Devices__Custome__4BAC3F29");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Orders__3214EC0740D03A39");

            entity.Property(e => e.Notes)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS")
                .HasColumnType("text");
            entity.Property(e => e.OrderDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Device).WithMany(p => p.Orders)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Orders__DeviceId__59FA5E80");
        });

        modelBuilder.Entity<Status>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Statuses__3214EC07F2CA16A9");

            entity.Property(e => e.StatusChangeDate)
                .HasDefaultValueSql("(getdate())")
                .HasColumnType("datetime");

            entity.HasOne(d => d.Device).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.DeviceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Statuses__Device__5535A963");

            entity.HasOne(d => d.StatusNavigation).WithMany(p => p.Statuses)
                .HasForeignKey(d => d.StatusId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Statuses__Status__5629CD9C");
        });

        modelBuilder.Entity<StatusType>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__StatusTy__3214EC076785F63E");

            entity.HasIndex(e => e.StatusName, "UQ__StatusTy__05E7698ABC8D94C4").IsUnique();

            entity.Property(e => e.StatusName)
                .HasMaxLength(50)
                .UseCollation("SQL_Latin1_General_CP1_CI_AS");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
