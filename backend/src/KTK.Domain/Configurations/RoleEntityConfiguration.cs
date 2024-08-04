namespace Domain.Configurations;

public class RoleEntityConfiguration : IEntityTypeConfiguration<RoleEntity>
{
    public void Configure(EntityTypeBuilder<RoleEntity> builder)
    {
        builder
            .HasQueryFilter(r => r.IsDeleted == false);
        
        builder
            .HasKey(r => r.Id)
            .HasName("RoleId");

        builder
            .Property(r => r.Title)
            .HasMaxLength(64)
            .IsRequired();
        builder
            .HasIndex(r => r.Title)
            .IsUnique();

        builder
            .Property(r => r.Description)
            .HasMaxLength(512)
            .IsRequired();
        builder
            .HasIndex(r => r.Description)
            .IsUnique();

        builder
            .Property(r => r.Created)
            .IsRequired();

        builder
            .HasMany(r => r.Users)
            .WithOne(u => u.Role)
            .HasForeignKey(u => u.RoleId);
        
        builder
            .HasMany(r => r.Permissions)
            .WithMany(p => p.Roles)
            .UsingEntity<RolePermissionEntity>(
                l => l.HasOne<PermissionsEntity>().WithMany().HasForeignKey(p => p.PermissionId),
                r => r.HasOne<RoleEntity>().WithMany().HasForeignKey(r => r.RoleId));
    }
}