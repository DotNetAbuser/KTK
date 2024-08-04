namespace Domain.Entities;

public class RoleEntity : BaseEntity<int>
{
    public RoleEntity(string title, string description)
        => (Title, Description) = (title, description);

    private RoleEntity() { }
    
    public string Title { get; set; }
    public string Description { get; set; }

    public ICollection<PermissionsEntity> Permissions { get; } = [];
    public ICollection<UserEntity> Users { get; } = [];


}