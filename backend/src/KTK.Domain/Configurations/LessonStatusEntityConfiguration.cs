namespace Domain.Configurations;

public class LessonStatusEntityConfiguration : IEntityTypeConfiguration<LessonStatusEntity>
{
    public void Configure(EntityTypeBuilder<LessonStatusEntity> builder)
    {
        builder
            .HasKey(ls => ls.Id);
        builder
            .Property(ls => ls.Id)
            .HasConversion(ls => ls.Value,
                v => new LessonStatusId(v))
            .HasColumnName("lesson_status_id")
            .IsRequired();
        
        builder
            .HasIndex(ls => ls.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(ls => ls.Title)
            .HasConversion(ls => ls.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
            .IsRequired();
        
        builder
            .Property(ls => ls.Description)
            .HasConversion(ls => ls.Value,
                v => Description.Create(v).Data)
            .HasColumnName("description")
            .HasMaxLength(Description.MaxDescriptionLenght)
            .IsRequired(false);

        builder
            .Property(ls => ls.ColorHex)
            .HasColumnName("color_hex")
            .HasMaxLength(32)
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