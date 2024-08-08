namespace Domain.Configurations;

public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionEntity>
{
    public void Configure(EntityTypeBuilder<PermissionEntity> builder)
    {
        builder
            .HasQueryFilter(p => p.IsDeleted == false);

        builder
            .HasKey(p => p.Id);
        builder
            .Property(p => p.Id)
            .HasConversion(p => p.Value,
                p => new PermissionId(p))
            .HasColumnName("permission_id")
            .IsRequired();
    
        builder
            .HasIndex(p => p.Title)
            .IsUnique()
            .HasFilter("is_deleted IS NULL");
        builder
            .Property(p => p.Title)
            .HasConversion(t => t.Value,
                v => Title.Create(v).Data)
            .HasColumnName("title")
            .HasMaxLength(Title.MaxTitleLenght)
            .IsRequired();
        
        builder
            .Property(d => d.Description)
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

        builder
            .HasMany<RoleEntity>()
            .WithMany()
            .UsingEntity<RolePermissionEntity>(
                l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                r => r.HasOne<PermissionEntity>().WithMany().HasForeignKey(p => p.PermissionId));
    }
}