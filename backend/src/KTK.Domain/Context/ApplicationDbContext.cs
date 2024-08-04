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

    public DbSet<StudentCollectiveEntity> StudentCollectives { get; set; }
    public DbSet<CuratorCollectiveEntity> CuratorCollectives { get; set; }
    public DbSet<RectorSubjectEntity> RectorSubjects { get; set; }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<SessionEntity> Sessions { get; set; }
    public DbSet<RoleEntity> Roles { get; set; }
    
    public DbSet<RolePermissionEntity> RolePermissions { get; set; }

    public DbSet<PermissionsEntity> Permissions { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}