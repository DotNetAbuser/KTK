namespace Domain.Entities;

public sealed class FacultyEntity : BaseEntity
{
    public const int MAX_TITLE_LENGHT = 256;

    public int FacultyId { get; } = default!;
    public string Title { get; private set; }
    public bool IsActive { get; private set; }

    public ICollection<SpecialtyEntity> Specialties { get; }
    
    public static IResult<FacultyEntity> Create(string title, bool isActive)
    {
        var validationResult = ValidateEntity(title);
        if (!validationResult.Succeeded)
            return Result<FacultyEntity>.Fail(validationResult.Messages);
        
        var entity = new FacultyEntity(title, isActive);
        return Result<FacultyEntity>.Success(entity);
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
    
    private FacultyEntity(string title, bool isActive)
    {
        Title = title;
        IsActive = isActive;
        Created = DateTimeOffset.UtcNow;
    }

    private static IResult ValidateEntity(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result.Fail(Error.General.ValueIsRequired("название факультета"));

        if (title.Length > MAX_TITLE_LENGHT)
            return Result.Fail(Error.General.InvalidMaxLenght("название факультета", MAX_TITLE_LENGHT));
        return Result.Success();
    }
   
}