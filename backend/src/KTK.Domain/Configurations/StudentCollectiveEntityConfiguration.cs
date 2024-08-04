namespace Domain.Configurations;

public class StudentCollectiveEntityConfiguration : IEntityTypeConfiguration<StudentCollectiveEntity>
{
    public void Configure(EntityTypeBuilder<StudentCollectiveEntity> builder)
    {
        builder
            .HasKey(sc => new { sc.StudentId, sc.CollectiveId });
    }
}