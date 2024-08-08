namespace Domain.ValueObjects;

public sealed record CourseIndex : ValueObject
{
    private CourseIndex(int value) => Value = value;
    
    private CourseIndex() {  }

    public int Value { get; }

    public static IResult<CourseIndex> Create(int value)
    {
        if (value < 1)
            return Result<CourseIndex>.Fail(DomainError.General.ValueIsInvalid("кол-во часов"));

        var courseIndex = new CourseIndex(value);
        return Result<CourseIndex>.Success(courseIndex);
    }
}