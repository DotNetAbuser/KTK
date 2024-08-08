namespace Domain.Configurations;

public class CollectiveStudentEntityConfiguration : IEntityTypeConfiguration<CollectiveStudentEntity>
{
    public void Configure(EntityTypeBuilder<CollectiveStudentEntity> builder)
    {
        builder
            .HasKey(cs => new { cs.CollectiveId, cs.StudentId });

        builder
            .Property(cs => cs.CollectiveId)
            .HasColumnName("collective_id")
            .IsRequired();

        builder
            .Property(cs => cs.StudentId)
            .HasColumnName("student_id")
            .IsRequired();

        builder
            .HasOne<CollectiveEntity>()
            .WithMany()
            .HasForeignKey(cs => cs.CollectiveId);

        builder
            .HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(cs => cs.StudentId);
    }
}