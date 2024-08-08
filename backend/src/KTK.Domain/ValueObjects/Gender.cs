namespace Domain.ValueObjects;

public sealed record Gender : ValueObject
{

    public const char Male = 'м';
    public const char Female = 'ж';
    public static readonly char[] Genders = [Male, Female];
    
    private Gender(char value) => Value = value;

    private Gender() { }

    public char Value { get; }

    public static IResult<Gender> Create(char value)
    {
        if (!Genders.Contains(value))
            return Result<Gender>.Fail(DomainError.General.ValueIsInvalid("пол"));
        
        var gender = new Gender(value);
        return Result<Gender>.Success(gender);
    }
}