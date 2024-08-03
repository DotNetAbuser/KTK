namespace Domain.Configurations;

public class FacultyEntityConfiguration : IEntityTypeConfiguration<FacultyEntity>
{
    public void Configure(EntityTypeBuilder<FacultyEntity> builder)
    {
        builder
            .HasKey(x => x.FacultyId);

        builder
            .HasIndex(x => x.Title)
            .IsUnique();
        builder
            .Property(x => x.Title)
            .HasMaxLength(256);

        builder
            .HasMany(x => x.Specialties)
            .WithOne(x => x.Faculty)
            .HasForeignKey(x => x.FaculityId);
    }
}