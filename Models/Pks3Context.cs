using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace practice3.Models;

public partial class Pks3Context : DbContext
{
    public Pks3Context()
    {
    }

    public Pks3Context(DbContextOptions<Pks3Context> options)
        : base(options)
    {
    }

    public virtual DbSet<Achievement> Achievements { get; set; }

    public virtual DbSet<Department> Departments { get; set; }

    public virtual DbSet<Enrolle> Enrolles { get; set; }

    public virtual DbSet<EnrolleAchievement> EnrolleAchievements { get; set; }

    public virtual DbSet<EnrolleSubject> EnrolleSubjects { get; set; }

    public virtual DbSet<Program> Programs { get; set; }

    public virtual DbSet<ProgramEnrollee> ProgramEnrollees { get; set; }

    public virtual DbSet<ProgramSubject> ProgramSubjects { get; set; }

    public virtual DbSet<Subject> Subjects { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseNpgsql("Host=localhost;Database=pks3;Username=postgres;Password=postgres");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Achievement>(entity =>
        {
            entity.HasKey(e => e.AchievementId).HasName("achievement_pkey");

            entity.ToTable("achievement");

            entity.Property(e => e.AchievementId)
                .ValueGeneratedNever()
                .HasColumnName("achievement_id");
            entity.Property(e => e.Bonus)
                .HasPrecision(10, 2)
                .HasColumnName("bonus");
            entity.Property(e => e.NameAchievement)
                .HasMaxLength(255)
                .HasColumnName("name_achievement");
        });

        modelBuilder.Entity<Department>(entity =>
        {
            entity.HasKey(e => e.DepartmentId).HasName("department_pkey");

            entity.ToTable("department");

            entity.Property(e => e.DepartmentId)
                .ValueGeneratedNever()
                .HasColumnName("department_id");
            entity.Property(e => e.NameDepartment)
                .HasMaxLength(255)
                .HasColumnName("name_department");
        });

        modelBuilder.Entity<Enrolle>(entity =>
        {
            entity.HasKey(e => e.EnrolleId).HasName("enrolle_pkey");

            entity.ToTable("enrolle");

            entity.Property(e => e.EnrolleId)
                .ValueGeneratedNever()
                .HasColumnName("enrolle_id");
            entity.Property(e => e.NameEnrolle)
                .HasMaxLength(255)
                .HasColumnName("name_enrolle");
        });

        modelBuilder.Entity<EnrolleAchievement>(entity =>
        {
            entity.HasKey(e => e.EnrolleAchievId).HasName("enrolle_achievement_pkey");

            entity.ToTable("enrolle_achievement");

            entity.Property(e => e.EnrolleAchievId)
                .ValueGeneratedNever()
                .HasColumnName("enrolle_achiev_id");
            entity.Property(e => e.AchievementId).HasColumnName("achievement_id");
            entity.Property(e => e.EnrolleId).HasColumnName("enrolle_id");

            entity.HasOne(d => d.Achievement).WithMany(p => p.EnrolleAchievements)
                .HasForeignKey(d => d.AchievementId)
                .HasConstraintName("enrolle_achievement_achievement_id_fkey");

            entity.HasOne(d => d.Enrolle).WithMany(p => p.EnrolleAchievements)
                .HasForeignKey(d => d.EnrolleId)
                .HasConstraintName("enrolle_achievement_enrolle_id_fkey");
        });

        modelBuilder.Entity<EnrolleSubject>(entity =>
        {
            entity.HasKey(e => e.EnrolleSubjectId).HasName("enrolle_subject_pkey");

            entity.ToTable("enrolle_subject");

            entity.Property(e => e.EnrolleSubjectId)
                .ValueGeneratedNever()
                .HasColumnName("enrolle_subject_id");
            entity.Property(e => e.EnrolleId).HasColumnName("enrolle_id");
            entity.Property(e => e.Result).HasColumnName("result");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Enrolle).WithMany(p => p.EnrolleSubjects)
                .HasForeignKey(d => d.EnrolleId)
                .HasConstraintName("enrolle_subject_enrolle_id_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.EnrolleSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("enrolle_subject_subject_id_fkey");
        });

        modelBuilder.Entity<Program>(entity =>
        {
            entity.HasKey(e => e.ProgramId).HasName("program_pkey");

            entity.ToTable("program");

            entity.Property(e => e.ProgramId)
                .ValueGeneratedNever()
                .HasColumnName("program_id");
            entity.Property(e => e.DepartmentId).HasColumnName("department_id");
            entity.Property(e => e.NameProgram)
                .HasMaxLength(255)
                .HasColumnName("name_program");
            entity.Property(e => e.Plan).HasColumnName("plan");

            entity.HasOne(d => d.Department).WithMany(p => p.Programs)
                .HasForeignKey(d => d.DepartmentId)
                .HasConstraintName("program_department_id_fkey");
        });

        modelBuilder.Entity<ProgramEnrollee>(entity =>
        {
            entity.HasKey(e => e.ProgramEnrolleeId).HasName("program_enrollee_pkey");

            entity.ToTable("program_enrollee");

            entity.Property(e => e.ProgramEnrolleeId)
                .ValueGeneratedNever()
                .HasColumnName("program_enrollee_id");
            entity.Property(e => e.EnrolleId).HasColumnName("enrolle_id");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");

            entity.HasOne(d => d.Enrolle).WithMany(p => p.ProgramEnrollees)
                .HasForeignKey(d => d.EnrolleId)
                .HasConstraintName("program_enrollee_enrolle_id_fkey");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramEnrollees)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("program_enrollee_program_id_fkey");
        });

        modelBuilder.Entity<ProgramSubject>(entity =>
        {
            entity.HasKey(e => e.ProgramSubjectId).HasName("program_subject_pkey");

            entity.ToTable("program_subject");

            entity.Property(e => e.ProgramSubjectId)
                .ValueGeneratedNever()
                .HasColumnName("program_subject_id");
            entity.Property(e => e.MinResult).HasColumnName("min_result");
            entity.Property(e => e.ProgramId).HasColumnName("program_id");
            entity.Property(e => e.SubjectId).HasColumnName("subject_id");

            entity.HasOne(d => d.Program).WithMany(p => p.ProgramSubjects)
                .HasForeignKey(d => d.ProgramId)
                .HasConstraintName("program_subject_program_id_fkey");

            entity.HasOne(d => d.Subject).WithMany(p => p.ProgramSubjects)
                .HasForeignKey(d => d.SubjectId)
                .HasConstraintName("program_subject_subject_id_fkey");
        });

        modelBuilder.Entity<Subject>(entity =>
        {
            entity.HasKey(e => e.SubjectId).HasName("subject_pkey");

            entity.ToTable("subject");

            entity.Property(e => e.SubjectId)
                .ValueGeneratedNever()
                .HasColumnName("subject_id");
            entity.Property(e => e.NameSubject)
                .HasMaxLength(255)
                .HasColumnName("name_subject");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
