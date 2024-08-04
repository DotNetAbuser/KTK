namespace Domain.Entities.Base;

public abstract class BaseEntity<TId>
{
    public TId Id { get; init; }
    public DateTime Created { get; init; } = DateTime.UtcNow;
    public DateTime? Updated { get; set; }    
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}