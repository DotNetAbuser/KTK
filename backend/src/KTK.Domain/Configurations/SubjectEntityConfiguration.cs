namespace Domain.Configurations;

public class SubjectEntityConfiguration
    : IEntityTypeConfiguration<SubjectEntity>
{
    public void Configure(EntityTypeBuilder<SubjectEntity> builder)
    {
        builder
            .HasQueryFilter(s => s.IsDeleted == false);

        builder
            .HasKey(s => s.Id);
        builder
            .Property(s => s.Id)
            .HasConversion(i => i.Value,
                v => new SubjectId(v))
            .HasColumnName("subject_id")
            .IsRequired();

        builder
            .Property(s => s.CourseId)
            .HasColumnName("course_id")
            .IsRequired();
        
        builder
            .HasIndex(s => s.Code)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(s => s.Code)
            .HasConversion(c => c.Value,
                v => Code.Create(v).Data)
            .HasColumnName("code")
            .HasMaxLength(Code.MaxCodeLenght)
            .IsRequired();
        
        builder
            .HasIndex(s => s.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(s => s.Title)
            .HasConversion(s => s.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
            .IsRequired();

        builder
            .Property(s => s.Hours)
            .HasColumnName("hours")
            .IsRequired();
        
        builder
            .Property(c => c.CreatedAt)
            .HasColumnName("created_at")
            .IsRequired();
        builder
            .Property(c => c.UpdatedAt)
            .HasColumnName("updated_at")
            .IsRequired(false);
        builder
            .Property(c => c.IsDeleted)
            .HasColumnName("is_deleted");
        builder
            .Property(c => c.DeletedAt)
            .HasColumnName("deleted_at")
            .IsRequired(false);

        builder
            .HasOne<CourseEntity>()
            .WithMany()
            .HasForeignKey(s => s.CourseId);

    }
}