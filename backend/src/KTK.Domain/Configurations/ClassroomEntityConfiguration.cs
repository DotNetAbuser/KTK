namespace Domain.Configurations;

public class ClassroomEntityConfiguration 
    : IEntityTypeConfiguration<ClassroomEntity>
{
    public void Configure(EntityTypeBuilder<ClassroomEntity> builder)
    {
        builder
            .HasQueryFilter(c => c.IsDeleted == false);

        builder
            .HasKey(c => c.Id);
        builder
            .Property(c => c.Id)
            .HasConversion(c => c.Value,
                c => new ClassroomId(c))
            .HasColumnName("classroom_id")
            .IsRequired();

        builder
            .HasIndex(c => c.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(c => c.Title)
            .HasConversion(c => c.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
            .IsRequired();;

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