namespace Domain.Configurations;

public class RectorSubjectEntityConfiguration : IEntityTypeConfiguration<RectorSubjectEntity>
{
    public void Configure(EntityTypeBuilder<RectorSubjectEntity> builder)
    {
        builder
            .HasKey(rs => new { rs.SubjectId, rs.RectorId });
    }
}