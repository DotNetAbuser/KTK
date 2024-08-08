namespace Domain.Configurations;

public class SpecialtyEntityConfiguration
    : IEntityTypeConfiguration<SpecialtyEntity>
{
    public void Configure(EntityTypeBuilder<SpecialtyEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);

        builder
            .HasKey(s => s.Id);
        builder
            .Property(s => s.Id)
            .HasConversion(s => s.Value,
                v => new SpecialityId(v))
            .HasColumnName("speciality_id")
            .IsRequired();

        builder
            .Property(s => s.FacultyId)
            .HasColumnName("faculty_id")
            .IsRequired();
        
        builder
            .HasIndex(s => s.Code)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(s => s.Code)
            .HasConversion(s => s.Value,
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
            .HasOne<FacultyEntity>()
            .WithMany()
            .HasForeignKey(s => s.FacultyId);
    }
}