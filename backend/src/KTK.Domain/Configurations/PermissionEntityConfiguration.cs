namespace Domain.Configurations;

public class PermissionEntityConfiguration : IEntityTypeConfiguration<PermissionsEntity>
{
    public void Configure(EntityTypeBuilder<PermissionsEntity> builder)
    {
        builder
            .HasQueryFilter(p => p.IsDeleted == false);
        
        builder
            .HasKey(p => p.Id)
            .HasName("PermissionId");

        builder
            .HasIndex(p => p.Title)
            .IsUnique();
        builder
            .Property(p => p.Title)
            .HasMaxLength(64)
            .IsRequired();
        
        builder
            .HasIndex(p => p.Description)
            .IsUnique();
        builder
            .Property(p => p.Description)
            .HasMaxLength(512)
            .IsRequired();

        builder
            .Property(p => p.Created)
            .IsRequired();

        builder
            .HasMany(p => p.Roles)
            .WithMany(r => r.Permissions)
            .UsingEntity<RolePermissionEntity>(
                l => l.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId),
                r => r.HasOne<PermissionsEntity>().WithMany().HasForeignKey(p => p.PermissionId));
    }
}