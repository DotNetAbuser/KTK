namespace Domain.ValueObjects;

public sealed record Email : ValueObject
{
    public const int MaxEmailLenght = 256;
    
    private Email(string value) => Value = value;

    private Email() { }

    public string Value { get; }

    public static IResult<Email> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Email>.Success(new Email());

        if (value.Length > MaxEmailLenght)
            return Result<Email>.Fail(DomainError.General.InvalidMaxLenght("эл. почта", MaxEmailLenght));

        value = value.Trim().ToLower();
        var email = new Email(value);
        return Result<Email>.Success(email);
    }
}