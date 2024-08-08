namespace Domain.Configurations;

public class CourseEntityConfiguration 
    : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);

        builder
            .HasKey(c => c.Id);
        builder
            .Property(c => c.Id)
            .HasConversion(c => c.Value,
                v => new CourseId(v))
            .HasColumnName("course_id")
            .IsRequired();

        builder
            .Property(c => c.SpecialityId)
            .HasColumnName("speciality_id")
            .IsRequired();
        
        builder
            .Property(c => c.CourseIndex)
            .HasConversion(c => c.Value,
                v => CourseIndex.Create(v).Data)
            .HasColumnName("course_index")
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
            .HasOne<SpecialtyEntity>()
            .WithMany()
            .HasForeignKey(c => c.SpecialityId);
    }
}