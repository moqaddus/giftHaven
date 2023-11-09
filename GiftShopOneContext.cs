using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebWebWeb;

public partial class GiftShopOneContext : DbContext
{
    public GiftShopOneContext()
    {
    }

    public GiftShopOneContext(DbContextOptions<GiftShopOneContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Admin> Admins { get; set; }

    public virtual DbSet<OrderItem> OrderItems { get; set; }

    public virtual DbSet<InventoryItem> InventoryItems { get; set; }

    public virtual DbSet<Order> Orders { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<Cart> Cart { get; set; }





    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=GiftHaven;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Admin>(entity =>
        {
            entity.HasKey(e => e.Id);

            entity.Property(e => e.Email)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.UserName)
                .HasMaxLength(25)
                .IsUnicode(false);
        });

        modelBuilder.Entity<OrderItem>(entity =>
        {
            entity.HasKey(e => new { e.OrderId, e.ItemId });

            entity.Property(e => e.OrderId).ValueGeneratedOnAdd();

            entity.HasOne(d => d.Item).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_ToInventory");

            entity.HasOne(d => d.Order).WithMany(p => p.OrderItems)
                .HasForeignKey(d => d.OrderId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_OrderItems_ToOrders");
        });


        modelBuilder.Entity<Cart>(entity =>
        {
            entity.HasKey(e => new { e.UserId, e.ItemId });

        });

        modelBuilder.Entity<InventoryItem>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.Category)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Description)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ItemName)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.imagePath)
                .HasMaxLength(30)
                .IsUnicode(false);
            entity.Property(e => e.Picture).HasColumnType("image");
        });

        modelBuilder.Entity<Order>(entity =>
        {
            entity.HasKey(e => e.OrderId);

            entity.Property(e => e.City)
                .HasMaxLength(15)
                .IsUnicode(false);
            entity.Property(e => e.Cnn)
                .HasMaxLength(16)
                .IsUnicode(false)
                .HasColumnName("CNN");
            entity.Property(e => e.CustomerName)
                .HasMaxLength(30)
                .IsFixedLength()
                .HasColumnName("customerName");
            entity.Property(e => e.Cvv)
                .HasMaxLength(4)
                .IsUnicode(false)
                .HasColumnName("CVV");
            entity.Property(e => e.DeliveryAddress)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(50)
                .IsUnicode(false);
            entity.Property(e => e.OrderDate).HasColumnType("datetime");
            entity.Property(e => e.TotalAmount)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("totalAmount");
            entity.Property(e => e.Zip)
                .HasMaxLength(10)
                .IsFixedLength();
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
