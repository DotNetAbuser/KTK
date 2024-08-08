namespace Domain.Configurations;

public class GradeTypeEntityConfiguration : IEntityTypeConfiguration<GradeTypeEntity>
{
    public void Configure(EntityTypeBuilder<GradeTypeEntity> builder)
    {
        builder
            .HasKey(gt => gt.Id);
        builder
            .Property(gt => gt.Id)
            .HasConversion(i => i.Value,
                v => new GradeTypeId(v))
            .HasColumnName("grade_type_id")
            .IsRequired();

        builder
            .OwnsOne(gt => gt.Title, title =>
            {
                title
                    .HasIndex(t => t.Value)
                    .IsUnique()
                    .HasFilter("is_deleted IS NULL");
                title
                    .Property(t => t.Value)
                    .HasColumnName("title")
                    .HasMaxLength(Title.MaxTitleLenght)
                    .IsRequired();
            });

        builder
            .OwnsOne(gt => gt.Description, description =>
            {
                description
                    .Property(d => d.Value)
                    .HasColumnName("description")
                    .HasMaxLength(Description.MaxDescriptionLenght)
                    .IsRequired(false);
            });
        
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