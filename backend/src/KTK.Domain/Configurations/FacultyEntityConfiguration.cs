namespace Domain.Configurations;

public class FacultyEntityConfiguration : IEntityTypeConfiguration<FacultyEntity>
{
    public void Configure(EntityTypeBuilder<FacultyEntity> builder)
    {
        builder
            .HasQueryFilter(f => f.IsDeleted == false);
        
        builder
            .HasKey(f => f.Id)
            .HasName("FacultyId");

        builder
            .HasIndex(f => f.Title)
            .IsUnique();
        builder
            .Property(f => f.Title)
            .HasMaxLength(256);
        
        builder
            .Property(f => f.Created)
            .IsRequired();
        
        builder
            .HasMany(f => f.Specialties)
            .WithOne(s => s.Faculty)
            .HasForeignKey(s => s.FaculityId);
    }
}