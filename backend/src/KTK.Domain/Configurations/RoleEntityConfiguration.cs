namespace Domain.Configurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder
            .HasQueryFilter(r => r.IsDeleted == false);

        builder
            .HasKey(r => r.Id);
        builder
            .Property(r => r.Id)
            .HasConversion(r => r.Value,
                r => new RoleId(r))
            .HasColumnName("role_id")
            .IsRequired();
     
        builder
            .HasIndex(r => r.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(r => r.Title)
            .HasConversion(r => r.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
            .IsRequired();
        
        builder
            .Property(r => r.Description)
            .HasConversion(d => d.Value,
                v => Description.Create(v).Data)
            .HasColumnName("description")
            .HasMaxLength(Description.MaxDescriptionLenght)
            .IsRequired(false);

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