namespace Domain.Configurations;

public class CourseEntityConfiguration 
    : IEntityTypeConfiguration<CourseEntity>
{
    public void Configure(EntityTypeBuilder<CourseEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);
        
        builder
            .HasKey(c => c.Id)
            .HasName("CourseId");

        builder
            .Property(c => c.SpecialityId)
            .IsRequired();
        
        builder
            .Property(c => c.CourseIndex)
            .IsRequired();

        builder
            .Property(c => c.CourseIndex)
            .IsRequired();

        builder
            .HasOne(c => c.Specialty)
            .WithMany(s => s.Courses)
            .HasForeignKey(c => c.SpecialityId);
    }
}