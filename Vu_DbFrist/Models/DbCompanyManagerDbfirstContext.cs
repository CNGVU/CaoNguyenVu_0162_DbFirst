using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Vu_DbFrist.Models;

public partial class DbCompanyManagerDbfirstContext : DbContext
{
    public DbCompanyManagerDbfirstContext()
    {
    }

    public DbCompanyManagerDbfirstContext(DbContextOptions<DbCompanyManagerDbfirstContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Company> Companies { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Staff> Staff { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("Data Source=.;Initial Catalog=dbCompanyManagerDBFirst;Integrated Security=True;Trust Server Certificate=True");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Company>(entity =>
        {
            entity.HasKey(e => e.CompanyId).HasName("PK__Company__2D971CAC20D7F2FC");

            entity.ToTable("Company");

            entity.Property(e => e.CompanyId).HasColumnType("numeric(10, 1)");
            entity.Property(e => e.CompanyName).HasMaxLength(250);
            entity.Property(e => e.CompanyPhone)
                .HasMaxLength(13)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("PK__Departme__B2079BEDD8CEFD1F");

            entity.ToTable("Department");

            entity.Property(e => e.DepartmentId).HasColumnType("numeric(10, 1)");
            entity.Property(e => e.CompanyId).HasColumnType("numeric(10, 1)");
            entity.Property(e => e.Departmentname).HasMaxLength(250);

            entity.HasOne(d => d.Company).WithMany(p => p.Departments)
                .HasForeignKey(d => d.CompanyId)
                .HasConstraintName("FK__Departmen__Compa__267ABA7A");
        });

        modelBuilder.Entity<Staff>(entity =>
        {
            entity.HasKey(e => e.StaffId).HasName("PK__Staff__96D4AB17C04EEAA1");

            entity.Property(e => e.StaffId).HasColumnType("numeric(10, 1)");
            entity.Property(e => e.DepartmentId).HasColumnType("numeric(10, 1)");
            entity.Property(e => e.Gender).HasMaxLength(5);
            entity.Property(e => e.Salary).HasColumnType("numeric(10, 1)");
            entity.Property(e => e.Staffname).HasMaxLength(250);

            entity.HasOne(d => d.Department).WithMany(p => p.Staff)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("FK__Staff__Departmen__29572725");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
