namespace Domain.ValueObjects;

public sealed record RoleId : ValueObject
{
    public RoleId(int value) => Value = value;

    private RoleId() { }

    public int Value { get; }
}