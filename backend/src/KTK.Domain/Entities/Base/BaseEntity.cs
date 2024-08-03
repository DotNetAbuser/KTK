namespace Domain.Entities.Base;

public abstract class BaseEntity
{
    public DateTime Created { get; init; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }    
    public bool IsDeleted { get; set; }
}