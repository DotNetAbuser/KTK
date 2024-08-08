namespace Domain.ValueObjects;

public sealed record ClassroomId
    : ValueObject
{
    public ClassroomId(Guid value) => Value = value;

    private ClassroomId() { }
    
    public Guid Value { get; init; } 
}