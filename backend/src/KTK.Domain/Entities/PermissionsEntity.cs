namespace Domain.Entities;

public sealed class PermissionsEntity : BaseEntity<int>
{
    public PermissionsEntity(string title, string description)
        => (Title, Description) = (title, description);

    private PermissionsEntity() { }
    
    public string Title { get; set; }
    public string Description { get; set; }

    public ICollection<RoleEntity> Roles { get; } = [];

  
}