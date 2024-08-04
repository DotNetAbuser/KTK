namespace Domain.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder
            .HasKey(rs => new { rs.RoleId, rs.PermissionId });
    }
}