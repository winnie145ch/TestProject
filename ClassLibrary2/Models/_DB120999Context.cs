using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace ClassLibrary2.Models
{
    public partial class _DB120999Context : DbContext
    {
        public _DB120999Context(DbContextOptions<_DB120999Context> options)
    : base(options)
        { }
        //As the error said it if you configure your MyContext through AddDbContext then you need too add a constructor that receive a parameter of type DbContextOptions<MyContext> into your MyContext class From:https://stackoverflow.com/questions/45947795/adddbcontext-was-called-with-configuration-but-the-context-type-mycontext-onl
        public virtual DbSet<AbsDetail> AbsDetail { get; set; }
        public virtual DbSet<Absent> Absent { get; set; }
        public virtual DbSet<Dept> Dept { get; set; }
        public virtual DbSet<Employee> Employee { get; set; }

        // Unable to generate entity type for table 'dbo.SalData'. Please see the warning messages.
        // Unable to generate entity type for table 'dbo.Appointment'. Please see the warning messages.

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<AbsDetail>(entity =>
            {
                entity.HasKey(e => new { e.EmpNo, e.AbsType, e.AbsDate });

                entity.HasIndex(e => e.AbsDate)
                    .HasName("IX_AbsDetail");

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.AbsType)
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.AbsDate).HasColumnType("datetime");

                entity.HasOne(d => d.AbsTypeNavigation)
                    .WithMany(p => p.AbsDetail)
                    .HasForeignKey(d => d.AbsType)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbsDetail_Absent");

                entity.HasOne(d => d.EmpNoNavigation)
                    .WithMany(p => p.AbsDetail)
                    .HasForeignKey(d => d.EmpNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_AbsDetail_Employee");
            });

            modelBuilder.Entity<Absent>(entity =>
            {
                entity.HasKey(e => e.AbsType);

                entity.HasIndex(e => e.AbsType)
                    .HasName("IX_AbsType");

                entity.Property(e => e.AbsType)
                    .HasMaxLength(8)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.AbsName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Dept>(entity =>
            {
                entity.HasKey(e => e.DeptNo);

                entity.HasIndex(e => e.DeptNo)
                    .HasName("IX_Dept");

                entity.Property(e => e.DeptNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.DeptName)
                    .IsRequired()
                    .HasMaxLength(20)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Employee>(entity =>
            {
                entity.HasKey(e => e.EmpNo);

                entity.HasIndex(e => e.EmpNo)
                    .HasName("IX_EmpNo");

                entity.Property(e => e.EmpNo)
                    .HasMaxLength(10)
                    .IsUnicode(false)
                    .ValueGeneratedNever();

                entity.Property(e => e.Brithday)
                    .IsRequired()
                    .HasMaxLength(8)
                    .IsUnicode(false);

                entity.Property(e => e.DeptNo)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.EmpName)
                    .IsRequired()
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.Property(e => e.Sex)
                    .IsRequired()
                    .HasMaxLength(2)
                    .IsUnicode(false);

                entity.HasOne(d => d.DeptNoNavigation)
                    .WithMany(p => p.Employee)
                    .HasForeignKey(d => d.DeptNo)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Employee_Dept");
            });
        }
    }
}
