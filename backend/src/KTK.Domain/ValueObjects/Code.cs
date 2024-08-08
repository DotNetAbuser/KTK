namespace Domain.ValueObjects;

public sealed record Code : ValueObject
{
    public const int MaxCodeLenght = 64;
    
    private Code(string value) => Value = value;

    private Code() { }

    public string Value { get; }

    public static IResult<Code> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Code>.Fail(DomainError.General.ValueIsRequired("код"));
        if (value.Length > MaxCodeLenght)
            return Result<Code>.Fail(DomainError.General.InvalidMaxLenght("код", MaxCodeLenght));
        
        var code = new Code(value);
        return Result<Code>.Success(code);
    }
};