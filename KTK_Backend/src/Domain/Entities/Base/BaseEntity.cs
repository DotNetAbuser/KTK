namespace Domain.Entities.Base;

public class BaseEntity<TId>
{
    public TId Id { get; set; }
    
    public Guid CreatedBy { get; set; }
    public DateTime Created { get; set; } = DateTime.UtcNow;
    
    public Guid? UpdatedBy { get; set; }
    public DateTime? Updated { get; set; }
    
    public bool IsDeleted { get; set; }
}