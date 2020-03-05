using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Expats.Models
{
    public partial class ExpatsDatabaseContext : DbContext
    {
        public ExpatsDatabaseContext()
        {
        }

        public ExpatsDatabaseContext(DbContextOptions<ExpatsDatabaseContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Details> Details { get; set; }
        public virtual DbSet<List> List { get; set; }
        public virtual DbSet<SubCategories> SubCategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=.\\SQLExpress;Database=ExpatsDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<Details>(entity =>
            {
                entity.HasKey(e => new { e.Id, e.Idlist });

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .ValueGeneratedOnAdd();

                entity.Property(e => e.Idlist).HasColumnName("idlist");

                entity.Property(e => e.Address)
                    .HasColumnName("address")
                    .HasMaxLength(50);

                entity.Property(e => e.Description)
                    .HasColumnName("description")
                    .HasMaxLength(50);

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Other)
                    .HasColumnName("other")
                    .HasMaxLength(50);

                entity.Property(e => e.Phone)
                    .HasColumnName("phone")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdlistNavigation)
                    .WithMany(p => p.Details)
                    .HasForeignKey(d => d.Idlist)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Details_List");
            });

            modelBuilder.Entity<List>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategory).HasColumnName("idcategory");

                entity.Property(e => e.Idsubcategory).HasColumnName("idsubcategory");

                entity.Property(e => e.Name)
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.Property(e => e.Type)
                    .HasColumnName("type")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.List)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_List_Categories");

                entity.HasOne(d => d.IdsubcategoryNavigation)
                    .WithMany(p => p.List)
                    .HasForeignKey(d => d.Idsubcategory)
                    .HasConstraintName("FK_List_SubCategories");
            });

            modelBuilder.Entity<SubCategories>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("id");

                entity.Property(e => e.Idcategory).HasColumnName("idcategory");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasColumnName("name")
                    .HasMaxLength(50);

                entity.HasOne(d => d.IdcategoryNavigation)
                    .WithMany(p => p.SubCategories)
                    .HasForeignKey(d => d.Idcategory)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_SubCategories_Categories");
            });
        }
    }
}
