using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using DAMMIT.Models;

namespace DAMMIT.Data
{
    public partial class ProjectDatabaseDbContext : DbContext
    {
        public ProjectDatabaseDbContext()
        {
        }

        public ProjectDatabaseDbContext(DbContextOptions<ProjectDatabaseDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CustomerInfo> CustomerInfo { get; set; }
        public virtual DbSet<Dodiclibrary> Dodiclibrary { get; set; }
        public virtual DbSet<LocalInventory> LocalInventory { get; set; }
        public virtual DbSet<LocalTransaction> LocalTransaction { get; set; }
        public virtual DbSet<SingleInventory> SingleInventory { get; set; }
        public virtual DbSet<SingleTransactionDetails> SingleTransactionDetails { get; set; }
        public virtual DbSet<UserInfo> UserInfo { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Server=LAPTOP-Q11VAC68\\SQLEXPRESS;Database=ProjectDatabase;Trusted_Connection=True;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CustomerInfo>(entity =>
            {
                entity.HasKey(e => e.CustomerId)
                    .HasName("PK__Customer__A4AE64B8EAE12324");

                entity.Property(e => e.CustomerId)
                    .HasColumnName("CustomerID")
                    .ValueGeneratedNever();
            });

            modelBuilder.Entity<Dodiclibrary>(entity =>
            {
                entity.HasKey(e => e.Dodic)
                    .HasName("PK__DODICLib__CFE0CA85F66D6853");

                entity.ToTable("DODICLibrary");

                entity.Property(e => e.Dodic)
                    .HasColumnName("DODIC")
                    .HasMaxLength(4);
            });

            modelBuilder.Entity<LocalInventory>(entity =>
            {
                entity.HasKey(e => e.AmmoId)
                    .HasName("PK__LocalInv__186966724D9D6727");

                entity.Property(e => e.AmmoId)
                    .HasColumnName("AmmoID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CurrentQty).HasColumnName("CurrentQTY");

                entity.Property(e => e.Dodic).HasColumnName("DODIC");

                entity.Property(e => e.InitialQty).HasColumnName("InitialQTY");
            });

            modelBuilder.Entity<LocalTransaction>(entity =>
            {
                entity.HasKey(e => e.Da5515id)
                    .HasName("PK__LocalTra__8BBDF42110ABECB4");

                entity.Property(e => e.Da5515id)
                    .HasColumnName("DA5515ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.Da5515copy).HasColumnName("DA5515Copy");

                entity.Property(e => e.RecDate).HasColumnType("datetime");

                entity.Property(e => e.Tidate)
                    .HasColumnName("TIDate")
                    .HasColumnType("datetime");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SingleInventory>(entity =>
            {
                entity.HasKey(e => e.Da3020id)
                    .HasName("PK__SingleIn__B433A2F136B8857C");

                entity.Property(e => e.Da3020id)
                    .HasColumnName("DA3020ID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Da5515id).HasColumnName("DA5515ID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Dodic).HasColumnName("DODIC");

                entity.Property(e => e.Qtygained).HasColumnName("QTYGained");

                entity.Property(e => e.Qtylost).HasColumnName("QTYLost");

                entity.Property(e => e.UserId).HasColumnName("UserID");
            });

            modelBuilder.Entity<SingleTransactionDetails>(entity =>
            {
                entity.HasKey(e => e.LineId)
                    .HasName("PK__SingleTr__2EAE64C94639CB4D");

                entity.Property(e => e.LineId)
                    .HasColumnName("LineID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Da5515id).HasColumnName("DA5515ID");

                entity.Property(e => e.Dodic).HasColumnName("DODIC");

                entity.Property(e => e.Qtyissued).HasColumnName("QTYIssued");

                entity.Property(e => e.Qtyreturned).HasColumnName("QTYReturned");
            });

            modelBuilder.Entity<UserInfo>(entity =>
            {
                entity.HasKey(e => e.UserId)
                    .HasName("PK__UserInfo__1788CCAC69E6E1BC");

                entity.Property(e => e.UserId)
                    .HasColumnName("UserID")
                    .ValueGeneratedNever();
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
