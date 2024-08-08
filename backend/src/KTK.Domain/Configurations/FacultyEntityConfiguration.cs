namespace Domain.Configurations;

public class FacultyEntityConfiguration : IEntityTypeConfiguration<FacultyEntity>
{
    public void Configure(EntityTypeBuilder<FacultyEntity> builder)
    {
        builder
            .HasQueryFilter(f => f.IsDeleted == false);

        builder
            .HasKey(f => f.Id);
        builder
            .Property(f => f.Id)
            .HasConversion(f => f.Value,
                v => new FacultyId(v))
            .HasColumnName("faculty_id")
            .IsRequired();

        builder
            .HasIndex(f => f.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(f => f.Title)
            .HasConversion(f => f.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
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
    }
}