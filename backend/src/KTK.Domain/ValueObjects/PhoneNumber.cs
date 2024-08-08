namespace Domain.ValueObjects;

public sealed record PhoneNumber : ValueObject
{
    public const int MaxPhoneNumberLenght = 32;

    private PhoneNumber(string value) => Value = value;

    private PhoneNumber() { }

    public string Value { get; }

    public static IResult<PhoneNumber> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Result<PhoneNumber>.Success(new PhoneNumber());

        if (value.Length > MaxPhoneNumberLenght)
            return Result<PhoneNumber>.Fail(DomainError.General.InvalidMaxLenght("номер телефона", MaxPhoneNumberLenght));

        value = value.Trim().ToLower();
        var phoneNumber = new PhoneNumber(value);
        return Result<PhoneNumber>.Success(phoneNumber);
    }
}