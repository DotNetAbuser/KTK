using Domain.Errors;
using Shared.Result;

namespace Domain.ValueObjects;

public sealed record Description : ValueObject
{
    public const int MaxDescriptionLenght = 512;

    private Description(string value) => Value = value;

    private Description() { }
    
    public string Value { get; }

    public static IResult<Description> Create(string value)
    {
        if (value.Length > MaxDescriptionLenght)
            return Result<Description>.Fail(DomainError.General.InvalidMaxLenght("описание", MaxDescriptionLenght));

        var description = new Description(value);
        return Result<Description>.Success(description);
    }
}