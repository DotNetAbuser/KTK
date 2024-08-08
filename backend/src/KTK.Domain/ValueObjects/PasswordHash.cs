namespace Domain.ValueObjects;

public sealed record PasswordHash : ValueObject
{
    public const int MinPasswordLenght = 4;
    
    private PasswordHash(string value) => Value = value; 

    private PasswordHash() { }

    public string Value { get; }

    public static IResult<PasswordHash> Create(string passwordRaw, string passwordRawConfirmed)
    {
        if (string.IsNullOrWhiteSpace(passwordRaw))
            return Result<PasswordHash>.Fail(DomainError.General.ValueIsRequired("пароль"));
        if (passwordRaw.Length < MinPasswordLenght)
            return Result<PasswordHash>.Fail(DomainError.General.InvalidMinLenght("пароль", MinPasswordLenght));
        if (passwordRaw != passwordRawConfirmed)
            return Result<PasswordHash>.Fail(DomainError.Password.NotConfirmed);

        passwordRaw = passwordRaw.Trim();
        var hashedPassword = BCrypt.Net.BCrypt.EnhancedHashPassword(passwordRaw)!;
        var passwordHash = new PasswordHash(hashedPassword);
        return Result<PasswordHash>.Success(passwordHash);
    }
}