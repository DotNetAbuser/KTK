namespace Domain.ValueObjects;

public record Name : BaseValueObject
{
    private Name() { }

    public Name(string last, string first, string middle)
    {
        Last = last;
        First = first;
        Middle = middle;
    }

    public string Last { get; init; }
    public string First { get; init; }
    public string Middle { get; init; }
}