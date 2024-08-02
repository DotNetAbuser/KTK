namespace Domain.Configurations;

public class FacultyEntityConfiguration : IEntityTypeConfiguration<FacultyEntity>
{
    public void Configure(EntityTypeBuilder<FacultyEntity> builder)
    {
        builder.HasKey(x => x.FacultyId);

        builder.HasIndex(x => x.Title)
            .IsUnique();
        
        builder
            .HasMany(x => x.Specialties)
            .WithOne(x => x.Faculty)
            .HasForeignKey(x => x.)
    }
}