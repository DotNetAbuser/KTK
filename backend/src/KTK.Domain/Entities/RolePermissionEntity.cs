namespace Domain.Entities;

public class RolePermissionEntity
{
    public RolePermissionEntity(RoleId roleId, PermissionId permissionId)
        => (RoleId, PermissionId) = (roleId, permissionId);

    private RolePermissionEntity() { }
    
    public RoleId RoleId { get; set; }
    public PermissionId PermissionId { get; set; }
    
}