using System;
using LiftTrackerApi.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace LiftTrackerApi
{
    public partial class fitnessContext : DbContext
    {
        public fitnessContext()
        {
        }

        public fitnessContext(DbContextOptions<fitnessContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Log> Logs { get; set; }
        public virtual DbSet<Users> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "en_US.UTF-8");

            modelBuilder.Entity<Log>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("log");

                entity.Property(e => e.date)
                    .HasColumnName("date")
                    .HasDefaultValueSql("CURRENT_DATE");

                entity.Property(e => e.fatigueindex).HasColumnName("fatigueindex");

                entity.Property(e => e.lift).HasColumnName("lift");

                entity.Property(e => e.set1).HasColumnName("set1");

                entity.Property(e => e.set2).HasColumnName("set2");

                entity.Property(e => e.set3).HasColumnName("set3");

                entity.Property(e => e.set4).HasColumnName("set4");

                entity.Property(e => e.set5).HasColumnName("set5");

                entity.Property(e => e.weight).HasColumnName("weight");
            });

            modelBuilder.Entity<Users>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("users");

                entity.Property(e => e.email).HasColumnName("email");

                entity.Property(e => e.fname).HasColumnName("fname");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("nextval('user_id_sequence'::regclass)");

                entity.Property(e => e.lname).HasColumnName("lname");

                entity.Property(e => e.password).HasColumnName("password");
            });

            modelBuilder.HasSequence("log_id_sequence");

            modelBuilder.HasSequence("user_id_sequence");

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
