namespace Domain.Configurations;

public class RolePermissionConfiguration : IEntityTypeConfiguration<RolePermissionEntity>
{
    public void Configure(EntityTypeBuilder<RolePermissionEntity> builder)
    {
        builder
            .HasKey(rp => new { rp.RoleId, rp.PermissionId });

        builder
            .Property(rp => rp.RoleId)
            .HasColumnName("role_id")
            .IsRequired();

        builder
            .Property(rp => rp.PermissionId)
            .HasColumnName("permission_id")
            .IsRequired();

        builder
            .HasOne<RoleEntity>()
            .WithMany()
            .HasForeignKey(rp => rp.RoleId);
        builder
            .HasOne<PermissionEntity>()
            .WithMany()
            .HasForeignKey(rp => rp.PermissionId);
    }
}