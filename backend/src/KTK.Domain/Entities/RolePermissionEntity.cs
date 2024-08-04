namespace Domain.Entities;

public class RolePermissionEntity
{
    public RolePermissionEntity(int roleId, int permissionId)
        => (RoleId, PermissionId) = (roleId, permissionId);

    private RolePermissionEntity() { }
    
    public int RoleId { get; set; }
    public int PermissionId { get; set; }
    
}