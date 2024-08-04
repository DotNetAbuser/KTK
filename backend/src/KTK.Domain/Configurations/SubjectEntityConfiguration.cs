namespace Domain.Configurations;

public class SubjectEntityConfiguration
    : IEntityTypeConfiguration<SubjectEntity>
{
    public void Configure(EntityTypeBuilder<SubjectEntity> builder)
    {
        builder
            .HasQueryFilter(s => s.IsDeleted == false);
        
        builder
            .HasKey(s => s.Id)
            .HasName("SubjectId");

        builder
            .Property(s => s.CourseId)
            .IsRequired();

        builder
            .HasIndex(s => s.Code)
            .IsUnique();
        builder
            .Property(s => s.Code)
            .HasMaxLength(64)
            .IsRequired();

        builder
            .HasIndex(s => s.Title)
            .IsUnique();
        builder
            .Property(s => s.Title)
            .HasMaxLength(256)
            .IsRequired();

        builder
            .Property(s => s.Hours)
            .IsRequired();

        builder
            .Property(s => s.Created)
            .IsRequired();

        builder
            .HasOne(s => s.Course)
            .WithMany(c => c.Subjects)
            .HasForeignKey(s => s.CourseId);

        builder
            .HasMany(s => s.Rectors)
            .WithMany(u => u.Subjects)
            .UsingEntity<RectorSubjectEntity>(
                l => l.HasOne<UserEntity>().WithMany().HasForeignKey(u => u.RectorId),
                r => r.HasOne<SubjectEntity>().WithMany().HasForeignKey(s => s.SubjectId));
    }
}