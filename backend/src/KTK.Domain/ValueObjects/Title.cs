namespace Domain.ValueObjects;

public sealed record Title : ValueObject
{
    public const int MaxTitleLenght = 64;

    private Title(string value) => Value = value;
    

    private Title() { }

    public string Value { get; init; }

    public static IResult<Title> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Title>.Fail(DomainError.General.ValueIsRequired("название"));

        if (value.Length > MaxTitleLenght)
            return Result<Title>.Fail(DomainError.General.InvalidMaxLenght("название", MaxTitleLenght));

        var title = new Title(value);
        return Result<Title>.Success(title);
    }
};