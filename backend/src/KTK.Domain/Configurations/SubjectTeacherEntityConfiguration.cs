namespace Domain.Configurations;

public class SubjectTeacherEntityConfiguration : IEntityTypeConfiguration<SubjectTeacherEntity>
{
    public void Configure(EntityTypeBuilder<SubjectTeacherEntity> builder)
    {
        builder
            .HasKey(rs => new { rs.SubjectId, rs.TeacherId });

        builder
            .Property(st => st.SubjectId)
            .HasColumnName("subject_id")
            .IsRequired();
        
        builder
            .Property(st => st.TeacherId)
            .HasColumnName("teacher_id")
            .IsRequired();

        builder
            .HasOne<SubjectEntity>()
            .WithMany()
            .HasForeignKey(st => st.SubjectId);
        builder
            .HasOne<UserEntity>()
            .WithMany()
            .HasForeignKey(st => st.TeacherId);
    }
}