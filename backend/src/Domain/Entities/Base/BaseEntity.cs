namespace Domain.Entities.Base;

public class BaseEntity
{
    public DateTimeOffset Created { get; protected set; }
    public DateTimeOffset? Updated { get; private set; }    
    public bool IsDeleted { get; private set; }
    
    protected void ChangeUpdatedDate(DateTimeOffset value) =>
        Updated = value.ToUniversalTime();
    
    protected void ChangeIsDeleted(bool value) =>
        IsDeleted = value;
    


}