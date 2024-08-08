namespace Domain.ValueObjects;

public sealed record Name : ValueObject
{
    private Name() { }

    private Name(string last, string first, string middle)
    {
        Last = last;
        First = first;
        Middle = middle;
    }

    public string Last { get; }
    public string First { get; }
    public string Middle { get; }

    public static IResult<Name> Create(string last, string first, string middle)
    {
        if (string.IsNullOrWhiteSpace(last))
            return Result<Name>.Fail(DomainError.General.ValueIsRequired("фамилия"));
        if (string.IsNullOrWhiteSpace(first))
            return Result<Name>.Fail(DomainError.General.ValueIsRequired("имя"));

        var name = new Name(last, first, middle);
        return Result<Name>.Success(name);
    }
}