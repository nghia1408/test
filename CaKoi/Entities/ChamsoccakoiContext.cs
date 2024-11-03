using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CaKoi.Entities;

public partial class ChamsoccakoiContext : DbContext
{
    public ChamsoccakoiContext()
    {
    }

    public ChamsoccakoiContext(DbContextOptions<ChamsoccakoiContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Blog> Blogs { get; set; }

    public virtual DbSet<FeedPlan> FeedPlans { get; set; }

    public virtual DbSet<FishTank> FishTanks { get; set; }

    public virtual DbSet<KoiFish> KoiFishes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<Purchase> Purchases { get; set; }

    public virtual DbSet<SaltCalculation> SaltCalculations { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<WaterQuality> WaterQualities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=DESKTOP-EJ6Q2BF;Initial Catalog=chamsoccakoi;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Blog>(entity =>
        {
            entity.HasKey(e => e.BlogId).HasName("PK__Blog__54379E50A729CE0D");

            entity.ToTable("Blog");

            entity.Property(e => e.BlogId).HasColumnName("BlogID");
            entity.Property(e => e.AuthorId).HasColumnName("AuthorID");
            entity.Property(e => e.Content).HasColumnType("text");
            entity.Property(e => e.DatePosted).HasColumnType("datetime");
            entity.Property(e => e.Title).HasMaxLength(200);

            entity.HasOne(d => d.Author).WithMany(p => p.Blogs)
                .HasForeignKey(d => d.AuthorId)
                .HasConstraintName("FK__Blog__AuthorID__5DCAEF64");
        });

        modelBuilder.Entity<FeedPlan>(entity =>
        {
            entity.HasKey(e => e.FeedId).HasName("PK__FeedPlan__1586DF75FDC8CC84");

            entity.ToTable("FeedPlan");

            entity.Property(e => e.FeedId).HasColumnName("FeedID");
            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.GrowthStage).HasMaxLength(50);
            entity.Property(e => e.TimePeriod).HasMaxLength(50);

            entity.HasOne(d => d.Fish).WithMany(p => p.FeedPlans)
                .HasForeignKey(d => d.FishId)
                .HasConstraintName("FK__FeedPlan__FishID__4E88ABD4");
        });

        modelBuilder.Entity<FishTank>(entity =>
        {
            entity.HasKey(e => e.FishTankId).HasName("PK__FishTank__3B19CA91E299A0D8");

            entity.ToTable("FishTank");

            entity.Property(e => e.FishTankId).HasColumnName("FishTankID");
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.TankName).HasMaxLength(100);

            entity.HasOne(d => d.Owner).WithMany(p => p.FishTanks)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__FishTank__OwnerI__44FF419A");
        });

        modelBuilder.Entity<KoiFish>(entity =>
        {
            entity.HasKey(e => e.FishId).HasName("PK__KoiFish__F82A5BF969049541");

            entity.ToTable("KoiFish");

            entity.Property(e => e.FishId).HasColumnName("FishID");
            entity.Property(e => e.FishTankId).HasColumnName("FishTankID");
            entity.Property(e => e.Gender).HasMaxLength(10);
            entity.Property(e => e.Name).HasMaxLength(100);
            entity.Property(e => e.Origin).HasMaxLength(100);
            entity.Property(e => e.OwnerId).HasColumnName("OwnerID");
            entity.Property(e => e.Species).HasMaxLength(50);

            entity.HasOne(d => d.FishTank).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.FishTankId)
                .HasConstraintName("FK__KoiFish__FishTan__47DBAE45");

            entity.HasOne(d => d.Owner).WithMany(p => p.KoiFishes)
                .HasForeignKey(d => d.OwnerId)
                .HasConstraintName("FK__KoiFish__OwnerID__48CFD27E");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.ProductId).HasName("PK__Product__B40CC6ED486B9432");

            entity.ToTable("Product");

            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.Category).HasMaxLength(50);
            entity.Property(e => e.Description).HasColumnType("text");
            entity.Property(e => e.ProductName).HasMaxLength(100);
        });

        modelBuilder.Entity<Purchase>(entity =>
        {
            entity.HasKey(e => e.PurchaseId).HasName("PK__Purchase__6B0A6BDE53792094");

            entity.ToTable("Purchase");

            entity.Property(e => e.PurchaseId).HasColumnName("PurchaseID");
            entity.Property(e => e.ProductId).HasColumnName("ProductID");
            entity.Property(e => e.PurchaseDate).HasColumnType("datetime");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Product).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.ProductId)
                .HasConstraintName("FK__Purchase__Produc__5AEE82B9");

            entity.HasOne(d => d.User).WithMany(p => p.Purchases)
                .HasForeignKey(d => d.UserId)
                .HasConstraintName("FK__Purchase__UserID__59FA5E80");
        });

        modelBuilder.Entity<SaltCalculation>(entity =>
        {
            entity.HasKey(e => e.SaltId).HasName("PK__SaltCalc__036055F3FD3440C1");

            entity.ToTable("SaltCalculation");

            entity.Property(e => e.SaltId).HasColumnName("SaltID");
            entity.Property(e => e.FishTankId).HasColumnName("FishTankID");

            entity.HasOne(d => d.FishTank).WithMany(p => p.SaltCalculations)
                .HasForeignKey(d => d.FishTankId)
                .HasConstraintName("FK__SaltCalcu__FishT__5535A963");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__User__1788CCAC0E519946");

            entity.ToTable("User");

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.Password).HasMaxLength(100);
            entity.Property(e => e.Phone).HasMaxLength(15);
            entity.Property(e => e.Role).HasMaxLength(20);
            entity.Property(e => e.UserName).HasMaxLength(100);
        });

        modelBuilder.Entity<WaterQuality>(entity =>
        {
            entity.HasKey(e => e.WaterId).HasName("PK__WaterQua__C4F18EAF5E5B9D92");

            entity.ToTable("WaterQuality");

            entity.Property(e => e.WaterId).HasColumnName("WaterID");
            entity.Property(e => e.DateChecked).HasColumnType("datetime");
            entity.Property(e => e.FishTankId).HasColumnName("FishTankID");
            entity.Property(e => e.No2).HasColumnName("NO2");
            entity.Property(e => e.No3).HasColumnName("NO3");
            entity.Property(e => e.PH).HasColumnName("pH");
            entity.Property(e => e.Po4).HasColumnName("PO4");

            entity.HasOne(d => d.FishTank).WithMany(p => p.WaterQualities)
                .HasForeignKey(d => d.FishTankId)
                .HasConstraintName("FK__WaterQual__FishT__4BAC3F29");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
