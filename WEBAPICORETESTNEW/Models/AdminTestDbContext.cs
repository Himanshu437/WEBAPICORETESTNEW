using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace WEBAPICORETESTNEW.Models
{
    public partial class AdminTestDbContext : DbContext
    {
        public AdminTestDbContext()
        {
        }

        public AdminTestDbContext(DbContextOptions<AdminTestDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<BookTest> BookTest { get; set; }
        public virtual DbSet<BookTestnew> BookTestnew { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
 // #warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer(" Server=Q3GGN0604\\SQLEXPRESS; Database=AdminTestDb; Trusted_Connection=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<BookTest>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BOOK_TES__490D1AE1271CC940");

                entity.ToTable("BOOK_TEST");

                entity.Property(e => e.BookId).HasColumnName("book_id");

                entity.Property(e => e.AuthorName)
                    .HasColumnName("author_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasColumnName("book_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BoookCost).HasColumnName("boook_cost");

                entity.Property(e => e.Edition)
                    .HasColumnName("edition")
                    .HasMaxLength(30);

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PublisherName)
                    .HasColumnName("publisher_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<BookTestnew>(entity =>
            {
                entity.HasKey(e => e.BookId)
                    .HasName("PK__BOOK_TES__490D1AE11BE0CBF5");

                entity.ToTable("BOOK_TESTNEW");

                entity.Property(e => e.BookId)
                    .HasColumnName("book_id")
                    .ValueGeneratedNever();

                entity.Property(e => e.AuthorName)
                    .HasColumnName("author_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.BookName)
                    .HasColumnName("book_name")
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BoookCost).HasColumnName("boook_cost");

                entity.Property(e => e.Edition)
                    .HasColumnName("edition")
                    .HasMaxLength(30);

                entity.Property(e => e.Genre)
                    .HasColumnName("genre")
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.Property(e => e.PublisherName)
                    .HasColumnName("publisher_name")
                    .HasMaxLength(30)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
