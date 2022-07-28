using System;
using System.Collections.Generic;
using AnagramSolver.EF.DbFirst.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace AnagramSolver.EF.DbFirst.Data
{
    public partial class WordsContext : DbContext
    {
        public WordsContext()
        {
        }

        public WordsContext(DbContextOptions<WordsContext> options)
            : base(options)
        {
        }

        public virtual DbSet<CashedWord> CashedWords { get; set; } = null!;
        public virtual DbSet<UserLog> UserLogs { get; set; } = null!;
        public virtual DbSet<WordsTable> WordsTables { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.EnableSensitiveDataLogging();
                optionsBuilder.UseSqlServer("Server=LT-LIT-SC-0684\\MSSQLSERVER01;;Database=Words; Integrated Security=true;");
                
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CashedWord>(entity =>
            {
                entity.Property(e => e.Id).HasMaxLength(50);
                
                entity.Property(e => e.Words).HasMaxLength(50);

                entity.Property(e => e.Anagram).HasMaxLength(50);
            });

            modelBuilder.Entity<UserLog>(entity =>
            {
                entity.ToTable("UserLog");

                entity.Property(e => e.SearchWord).HasMaxLength(50);
                entity.Property(e => e.SearchTime);
                entity.Property(e => e.Anagram);

                entity.Property(e => e.UserIp)
                    .HasMaxLength(50)
                    .HasColumnName("UserIP");
                entity.Property(e => e.Id).HasMaxLength(50);

            });

            modelBuilder.Entity<WordsTable>(entity =>
            {
                entity.ToTable("WordsTable");

                entity.Property(e => e.Pronoun).HasMaxLength(50);

                entity.Property(e => e.Word).HasMaxLength(50);
                entity.Property(e => e.Id).ValueGeneratedNever();

            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
