using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace KeyboardProjectAppSimple.Models
{
    public partial class KeyboardProjectSimpleContext : DbContext
    {
        public KeyboardProjectSimpleContext()
        {
        }

        public KeyboardProjectSimpleContext(DbContextOptions<KeyboardProjectSimpleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<KeyboardProject> KeyboardProjects { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<KeyboardProject>(entity =>
            {
                entity.HasKey(e => e.ProjectId);

                entity.Property(e => e.ProjectId).HasColumnName("ProjectID");

                entity.Property(e => e.ProjectKeyboardCase).HasMaxLength(60);

                entity.Property(e => e.ProjectKeyboardCasePrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProjectKeycap).HasMaxLength(60);

                entity.Property(e => e.ProjectKeycapPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProjectName).HasMaxLength(100);

                entity.Property(e => e.ProjectPcb).HasMaxLength(60);

                entity.Property(e => e.ProjectPcbPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProjectPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProjectStabilizer).HasMaxLength(60);

                entity.Property(e => e.ProjectStabilizerPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProjectSwitch).HasMaxLength(60);

                entity.Property(e => e.ProjectSwitchPrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");

                entity.Property(e => e.ProjectSwitchplate).HasMaxLength(60);

                entity.Property(e => e.ProjectSwitchplatePrice)
                    .HasColumnType("decimal(18, 2)")
                    .HasDefaultValueSql("((0.00))");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
