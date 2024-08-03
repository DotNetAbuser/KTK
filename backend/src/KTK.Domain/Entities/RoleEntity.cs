namespace Domain.Entities;

public class RoleEntity : BaseEntity
{
    
    public int RoleId { get; } = default!;
    public string Title { get; set; }

    private RoleEntity(string title)
        => Title = title;
}