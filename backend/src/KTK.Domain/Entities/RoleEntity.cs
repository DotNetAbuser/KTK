namespace Domain.Entities;

public class RoleEntity : BaseEntity<RoleId>
{
    public RoleEntity(RoleId id, Title title, Description description)
        => (Id, Title, Description) = (id, title, description);

    private RoleEntity() { }
    
    public Title Title { get; set; }
    public Description Description { get; set; }
}