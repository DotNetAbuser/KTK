namespace Domain.Entities.Base;

public abstract class BaseEntity<TPrimaryKey>
{
    public TPrimaryKey Id { get; init; }
    public DateTime CreatedAt { get; } = DateTime.UtcNow;
    public DateTime? UpdatedAt { get; set; }    
    public bool IsDeleted { get; set; }
    public DateTime? DeletedAt { get; set; }
}