using System;
using Assignment.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace Assignment.Domain
{
    public partial class ABNContext : DbContext
    {
        public ABNContext()
        {
        }

        public ABNContext(DbContextOptions<ABNContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Output> Outputs { get; set; }
        public virtual DbSet<ProcessRequest> ProcessRequests { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer();
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Output>(entity =>
            {
                entity.ToTable("Output");

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.ProcessRequest)
                    .WithMany(p => p.Outputs)
                    .HasForeignKey(d => d.ProcessRequestId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Output_ProcessRequest");
            });

            modelBuilder.Entity<ProcessRequest>(entity =>
            {
                entity.ToTable("ProcessRequest");

                entity.Property(e => e.Created)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Guid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.LastName).HasMaxLength(50);

                entity.Property(e => e.Name).HasMaxLength(50);

                entity.Property(e => e.ProcessStatusId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Processed).HasColumnType("datetime");

                entity.Property(e => e.Progress).HasDefaultValueSql("((0))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
