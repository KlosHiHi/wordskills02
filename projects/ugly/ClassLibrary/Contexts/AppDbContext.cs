using System;
using System.Collections.Generic;
using ClassLibrary.Models;
using Microsoft.EntityFrameworkCore;

namespace ClassLibrary.Contexts;

public partial class AppDbContext : DbContext
{
    public AppDbContext()
    {
    }

    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Formulation> Formulations { get; set; }

    public virtual DbSet<FormulationItem> FormulationItems { get; set; }

    public virtual DbSet<Item> Items { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<TechCard> TechCards { get; set; }

    public virtual DbSet<TechCardStep> TechCardSteps { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySQL("Server=127.0.0.1;Database=mydb;Uid=root;Password=1234");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Formulation>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("formulations");

            entity.HasIndex(e => e.ProductId, "fk_formulations_product_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsCurrent)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_current");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");

            entity.HasOne(d => d.Product).WithMany(p => p.Formulations)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_formulations_product");
        });

        modelBuilder.Entity<FormulationItem>(entity =>
        {
            entity.HasKey(e => new { e.FormulationId, e.ItemId }).HasName("PRIMARY");

            entity.ToTable("formulation_items");

            entity.HasIndex(e => e.ItemId, "fk_formulations_has_formulation_items_formulation_items1_idx");

            entity.HasIndex(e => e.FormulationId, "fk_formulations_has_formulation_items_formulations1_idx");

            entity.Property(e => e.FormulationId).HasColumnName("formulation_id");
            entity.Property(e => e.ItemId).HasColumnName("item_id");
            entity.Property(e => e.Quantity).HasColumnName("quantity");

            entity.HasOne(d => d.Formulation).WithMany(p => p.FormulationItems)
                .HasForeignKey(d => d.FormulationId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_formulations_has_formulation_items_formulations1");

            entity.HasOne(d => d.Item).WithMany(p => p.FormulationItems)
                .HasForeignKey(d => d.ItemId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_formulations_has_formulation_items_formulation_items1");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("items");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("product");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
        });

        modelBuilder.Entity<TechCard>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tech_card");

            entity.HasIndex(e => e.ProductId, "fk_tech_card_product1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.ProductId).HasColumnName("product_id");
            entity.Property(e => e.Status)
                .HasMaxLength(45)
                .HasColumnName("status");

            entity.HasOne(d => d.Product).WithMany(p => p.TechCards)
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tech_card_product1");
        });

        modelBuilder.Entity<TechCardStep>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PRIMARY");

            entity.ToTable("tech_card_steps");

            entity.HasIndex(e => e.TechCardId, "fk_tech_card_steps_tech_card1_idx");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.IsRequired)
                .HasDefaultValueSql("'0'")
                .HasColumnName("is_required");
            entity.Property(e => e.Name)
                .HasMaxLength(45)
                .HasColumnName("name");
            entity.Property(e => e.Number).HasColumnName("number");
            entity.Property(e => e.TechCardId).HasColumnName("tech_card_id");

            entity.HasOne(d => d.TechCard).WithMany(p => p.TechCardSteps)
                .HasForeignKey(d => d.TechCardId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("fk_tech_card_steps_tech_card1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
