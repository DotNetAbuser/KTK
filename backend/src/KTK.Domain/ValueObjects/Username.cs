namespace Domain.ValueObjects;

public sealed record Username : ValueObject
{
    public const int MinUsernameLenght = 4;
    public const int MaxUsernameLenght = 64;
    
    private Username(string value) => Value = value;

    private Username() { }

    public string Value { get; }

    public static IResult<Username> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<Username>.Fail(DomainError.General.ValueIsRequired("имя пользователя"));

        if (value.Length < MaxUsernameLenght)
            return Result<Username>.Fail(DomainError.General.InvalidMinLenght("имя пользователя", MinUsernameLenght));

        if (value.Length > MaxUsernameLenght)
            return Result<Username>.Fail(DomainError.General.InvalidMaxLenght("имя пользователя", MaxUsernameLenght));

        value = value.Trim().ToLower();
        var username = new Username(value);
        return Result<Username>.Success(username);
    }
};