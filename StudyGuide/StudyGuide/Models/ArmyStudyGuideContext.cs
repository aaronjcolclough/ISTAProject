using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace StudyGuide.Models
{
    public partial class ArmyStudyGuideContext : DbContext
    {
        public ArmyStudyGuideContext()
        {
        }

        public ArmyStudyGuideContext(DbContextOptions<ArmyStudyGuideContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Categories> Categories { get; set; }
        public virtual DbSet<Pdfs> Pdfs { get; set; }
        public virtual DbSet<QaDetails> QaDetails { get; set; }
        public virtual DbSet<Subcategories> Subcategories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=Oracle\\sqlexpress;Database=ArmyStudyGuide;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Categories>(entity =>
            {
                entity.HasKey(e => e.CatId);

                entity.HasIndex(e => e.CatId)
                    .HasName("UQ__Categori__17B6DD27186E5FFB")
                    .IsUnique();

                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.CatName)
                    .IsRequired()
                    .HasColumnName("catName")
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Pdfs>(entity =>
            {
                entity.HasKey(e => e.PdfId);

                entity.ToTable("PDFs");

                entity.HasIndex(e => e.PdfId)
                    .HasName("UQ__PDFs__F597006653F988DA")
                    .IsUnique();

                entity.Property(e => e.PdfId).HasColumnName("pdfID");

                entity.Property(e => e.PdfName)
                    .IsRequired()
                    .HasColumnName("pdfName")
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.SubId).HasColumnName("subID");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.Pdfs)
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK__PDFs__subID__41B8C09B");
            });

            modelBuilder.Entity<QaDetails>(entity =>
            {
                entity.HasKey(e => e.QaId);

                entity.ToTable("QA_Details");

                entity.HasIndex(e => e.QaId)
                    .HasName("UQ__QA_Detai__3CC263D5B9250B42")
                    .IsUnique();

                entity.Property(e => e.QaId).HasColumnName("qaID");

                entity.Property(e => e.Answer)
                    .IsRequired()
                    .HasMaxLength(3000)
                    .IsUnicode(false);

                entity.Property(e => e.Question)
                    .IsRequired()
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.SubId).HasColumnName("subID");

                entity.HasOne(d => d.Sub)
                    .WithMany(p => p.QaDetails)
                    .HasForeignKey(d => d.SubId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_QA_Details_Subcategories");
            });

            modelBuilder.Entity<Subcategories>(entity =>
            {
                entity.HasKey(e => e.SubId);

                entity.HasIndex(e => e.SubId)
                    .HasName("UQ__Subcateg__B0C482CAC47CA19D")
                    .IsUnique();

                entity.Property(e => e.SubId).HasColumnName("subID");

                entity.Property(e => e.CatId).HasColumnName("catID");

                entity.Property(e => e.SubName)
                    .IsRequired()
                    .HasColumnName("subName")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Cat)
                    .WithMany(p => p.Subcategories)
                    .HasForeignKey(d => d.CatId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Subcategories_Categories");
            });
        }
    }
}
