namespace Domain.Entities;

public sealed class PermissionEntity : BaseEntity<PermissionId>
{
    public PermissionEntity(PermissionId id, Title title, Description description)
        => (Id, Title, Description) = (id, title, description);

    private PermissionEntity() { }
    
    public Title Title { get; set; }
    public Description Description { get; set; }
  
}