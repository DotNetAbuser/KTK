using System.Reflection;

namespace Domain.Context;

public class ApplicationDbContext(
    DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<FacultyEntity> Faculties { get; set; }
    public DbSet<SpecialtyEntity> Specialties { get; set; }
    public DbSet<CourseEntity> Courses { get; set; }
    public DbSet<CollectiveEntity> Collectives { get; set; }
    public DbSet<SubjectEntity> Subjects { get; set; }
    public DbSet<ClassroomEntity> Classrooms { get; set; }

    public DbSet<CollectiveStudentEntity> CollectiveStudents { get; set; }
    public DbSet<CollectiveCuratorEntity> CollectiveCurators { get; set; }
    public DbSet<SubjectTeacherEntity> SubjectTeachers { get; set; }

    public DbSet<LessonEntity> Lessons { get; set; }
    public DbSet<LessonStatusEntity> LessonStatuses { get; set; }
    
    public DbSet<GradeEntity> Grades { get; set; }
    public DbSet<GradeTypeEntity> GradeTypes { get; set; }
    
    public DbSet<UserEntity> Users { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }
    
    public DbSet<PermissionEntity> Permissions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        
        modelBuilder.Entity<FacultyEntity>()
            .ToTable("faculties");
        
        modelBuilder.Entity<SpecialtyEntity>()
            .ToTable("specialties");
        
        modelBuilder.Entity<CourseEntity>()
            .ToTable("courses");
        
        modelBuilder.Entity<CollectiveEntity>()
            .ToTable("collectives");
        
        modelBuilder.Entity<SubjectEntity>()
            .ToTable("subjects");

        modelBuilder.Entity<ClassroomEntity>()
            .ToTable("classrooms");

        modelBuilder.Entity<LessonEntity>()
            .ToTable("lessons");
        
        modelBuilder.Entity<LessonStatusEntity>()
            .ToTable("lesson_statuses");
        
        modelBuilder.Entity<GradeEntity>()
            .ToTable("grades");
        
        modelBuilder.Entity<GradeTypeEntity>()
            .ToTable("grade_types");
        
        modelBuilder.Entity<CollectiveStudentEntity>()
            .ToTable("collective_students");
        
        modelBuilder.Entity<CollectiveCuratorEntity>()
            .ToTable("collective_curators");
        
        modelBuilder.Entity<SubjectTeacherEntity>()
            .ToTable("subject_teachers");
        
        modelBuilder.Entity<UserEntity>()
            .ToTable("users");
        
        modelBuilder.Entity<SessionEntity>()
            .ToTable("sessions");
        
        modelBuilder.Entity<RoleEntity>()
            .ToTable("roles");
        
        modelBuilder.Entity<RolePermissionEntity>()
            .ToTable("role_permissions");
        
        modelBuilder.Entity<PermissionEntity>()
            .ToTable("permissions");
        
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}