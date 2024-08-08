namespace Domain.Configurations;

public class CollectiveEntityConfiguration 
    : IEntityTypeConfiguration<CollectiveEntity>
{
    public void Configure(EntityTypeBuilder<CollectiveEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);

        builder
            .HasKey(c => c.Id);
        builder
            .Property(c => c.Id)
            .HasConversion(c => c.Value,
                v => new CollectiveId(v))
            .HasColumnName("collective_id")
            .IsRequired();

        builder
            .Property(c => c.SpecialityId)
            .HasColumnName("speciality_id")
            .IsRequired();

        builder
            .HasIndex(t => t.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(c => c.Title)
            .HasConversion(c => c.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
            .IsRequired();

        builder
            .Property(c => c.EnrollmentAt)
            .HasColumnName("enrollment_at")
            .IsRequired();

        builder
            .Property(c => c.DeducationAt)
            .HasColumnName("deducation_at")
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