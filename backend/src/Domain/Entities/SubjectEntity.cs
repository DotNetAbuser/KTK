namespace Domain.Entities;

public sealed class SubjectEntity : BaseEntity
{
    public const int MAX_CODE_LENGHT = 64;
    public const int MAX_TITLE_LENGHT = 256;
    public const int MIN_HOURS_VALUE = 1;

    public int SubjectId { get; } = default!;
    public int CourseId { get; private set; }
    public string Code { get; private set; }
    public string Title { get; private set; }
    public int Hours { get; private set; }
    public bool IsActive { get; private set; }

    public CourseEntity Course { get; } = null!;

    public static IResult<SubjectEntity> Create(
        int courseId, string code, string title, int hours, bool isActive)
    {
        var validationResult = ValidateEntity(code, title, hours);
        if (!validationResult.Succeeded)
            return Result<SubjectEntity>.Fail(validationResult.Messages);
        
        var entity = new SubjectEntity(courseId, code, title, hours, isActive);
        return Result<SubjectEntity>.Success(entity);
    }

    public IResult Update(
      string code, string title, int hours, bool isActive)
    {
        var validationResult = ValidateEntity(code, title, hours);
        if (!validationResult.Succeeded)
            return Result.Fail(validationResult.Messages);
        
        return Result.Success();
    }
    
    private SubjectEntity(
        int courseId, string code, string title, int hours, bool isActive)
    {
        CourseId = courseId;
        Code = code;
        Title = title;
        Hours = hours;
        IsActive = isActive;
    }

    private static IResult ValidateEntity(
        string code, string title, int hours)
    {
        if (string.IsNullOrWhiteSpace(code))
            return Result.Fail(Error.General.ValueIsRequired("код предметы"));

        if (code.Length > MAX_CODE_LENGHT)
            return Result.Fail(Error.General.InvalidMaxLenght("код предмета", MAX_CODE_LENGHT));

        if (string.IsNullOrWhiteSpace(title))
            return Result.Fail(Error.General.ValueIsRequired("название дисциплины"));

        if (title.Length > MAX_TITLE_LENGHT)
            return Result.Fail(Error.General.InvalidMaxLenght("название дисциплины", MAX_TITLE_LENGHT));

        if (hours < MIN_HOURS_VALUE)
            return Result.Fail(Error.General.ValueIsInvalid("количество часов"));
        
        return Result.Success();
    }
}