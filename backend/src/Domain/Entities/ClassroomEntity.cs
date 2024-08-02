namespace Domain.Entities;

public sealed class ClassroomEntity : BaseEntity
{
    public const int MAX_TITLE_LENGHT = 256;

    public int ClassroomId { get; } = default!;
    public string Title { get; private set; }
    public bool IsActive { get; private set; }

    public static IResult<ClassroomEntity> Create(string title, bool isActive)
    {
        var validationResult = ValidateEntity(title);
        if (!validationResult.Succeeded)
            return Result<ClassroomEntity>.Fail(validationResult.Messages);

        var entity = new ClassroomEntity(title, isActive);
        return Result<ClassroomEntity>.Success(entity);
    }

    public IResult Update(string title, bool isActive)
    {
        var validationResult = ValidateEntity(title);
        if (!validationResult.Succeeded)
            return Result.Fail(validationResult.Messages);

        Title = title;
        IsActive = isActive;
        return Result.Success();
    }
    
    private ClassroomEntity(string title, bool isActive)
    {
        Title = title;
        IsActive = isActive;
    }

    private static IResult ValidateEntity(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Fail(Error.General.ValueIsRequired("номер аудитории"));

        if (title.Length > MAX_TITLE_LENGHT)
            return Result.Fail(Error.General.InvalidMaxLenght("номер аудитории", MAX_TITLE_LENGHT));
        return Result.Success();
    }
    
}