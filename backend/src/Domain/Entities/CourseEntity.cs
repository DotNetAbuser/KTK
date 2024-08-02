namespace Domain.Entities;

public sealed class CourseEntity : BaseEntity
{
    public const int MIN_COURSE_INDEX_VALUE = 1;
    public const int MAX_COURSE_INDEX_VALUE = 4;

    public int CourseId { get; } = default!;
    public int SpecialityId { get; private set; }
    public int CourseIndex { get; private set; }

    public SpecialtyEntity Specialty { get; } = null!;
    public ICollection<SubjectEntity> Subjects { get; } = [];

    public static IResult<CourseEntity> Create(
        int specialtyId, int courseIndex)
    {
        var validationResult = ValidateEntity(courseIndex);
        if (!validationResult.Succeeded)
            return Result<CourseEntity>.Fail(validationResult.Messages);

        var entity = new CourseEntity(specialtyId, courseIndex);
        return Result<CourseEntity>.Success(entity);
    }

    public IResult Update(
        int specialityId, int courseIndex)
    {
        var validationResult = ValidateEntity(courseIndex);
        if (!validationResult.Succeeded)
            return Result<CourseEntity>.Fail(validationResult.Messages);

        SpecialityId = specialityId;
        CourseIndex = courseIndex;
        return Result.Success();
    }
    
    private CourseEntity(int specialityId, int courseIndex)
    {
        SpecialityId = specialityId;
        CourseIndex = courseIndex;
    }

    private static IResult ValidateEntity(int courseIndex)
    {
        if (courseIndex < MIN_COURSE_INDEX_VALUE)
            return Result.Fail(Error.General.ValueIsInvalid("номер курса"));
        if (courseIndex > MAX_COURSE_INDEX_VALUE)
            return Result.Fail(Error.General.ValueIsInvalid("номер курса"));

        return Result.Success();
    }
    
}