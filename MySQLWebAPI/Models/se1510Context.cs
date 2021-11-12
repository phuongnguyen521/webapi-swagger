using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace MySQLWebAPI.Models
{
    public partial class se1510Context : DbContext
    {
        public se1510Context()
        {
        }

        public se1510Context(DbContextOptions<se1510Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Student> Students { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseMySQL("server=localhost;database=se1510;user=root;pwd=1234");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Student>(entity =>
            {
                entity.HasKey(e => e.IdStudent)
                    .HasName("PRIMARY");

                entity.ToTable("students");

                entity.Property(e => e.IdStudent).HasColumnName("ID_Student");

                entity.Property(e => e.Major)
                    .HasMaxLength(40)
                    .HasDefaultValueSql("'Undecided'");

                entity.Property(e => e.StudentName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("Student_Name");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
