namespace Domain.ValueObjects;

public sealed record PermissionId : ValueObject
{
    public PermissionId(int value) => Value = value;
    
    private PermissionId() { }

    public int Value { get; }
}