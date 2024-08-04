namespace Domain.Configurations;

public class SpecialtyEntityConfiguration
    : IEntityTypeConfiguration<SpecialtyEntity>
{
    public void Configure(EntityTypeBuilder<SpecialtyEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);
        
        builder
            .HasKey(s => s.Id)
            .HasName("SpecialityId");

        builder
            .Property(s => s.FaculityId)
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
            .Property(s => s.Created)
            .IsRequired();

        builder
            .HasOne(s => s.Faculty)
            .WithMany(f => f.Specialties)
            .HasForeignKey(s => s.FaculityId);

        builder
            .HasMany(s => s.Courses)
            .WithOne(c => c.Specialty)
            .HasForeignKey(c => c.SpecialityId);
    }
}