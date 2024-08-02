namespace Domain.Entities;

public sealed class SpecialtyEntity : BaseEntity
{
    public const int MAX_CODE_LENGTH = 64;
    public const int MAX_TITLE_LENGHT = 256;

    public int SpecialtyId { get; } = default!;
    public int FaculityId { get; private set; }
    public string Code { get; private set; }
    public string Title { get; private set; }

    public FacultyEntity Faculty { get; } = null!;
    public ICollection<CourseEntity> Courses { get; } = [];
    public ICollection<SpecialtyEntity> Specialties { get; } = [];
    
    public static IResult<SpecialtyEntity> Create(
        int faculityId, string code, string title)
    {
        var validationResult = ValidateEntity( code, title);
        if (!validationResult.Succeeded)
            return Result<SpecialtyEntity>.Fail(validationResult.Messages);
        
        var entity = new SpecialtyEntity(faculityId, code, title);
        return Result<SpecialtyEntity>.Success(entity);
    }

    public IResult Update(int faculityId, string code, string title)
    {
        var validationResult = ValidateEntity( code, title);
        if (!validationResult.Succeeded)
            return Result<SpecialtyEntity>.Fail(validationResult.Messages);
        
        FaculityId = faculityId;
        Code = code;
        Title = title;
        return Result.Success();
    }
    
    private SpecialtyEntity(int faculityId, string code, string title)
    {
        FaculityId = faculityId;
        Code = code;
        Title = title;
    }
    
    private static IResult ValidateEntity(string title, string code)
    {
        if (string.IsNullOrWhiteSpace(title))
            return Result<SpecialtyEntity>.Fail(Error.General.ValueIsRequired("название специальности"));

        if (title.Length > MAX_TITLE_LENGHT)
            return Result<SpecialtyEntity>.Fail(Error.General.ValueIsRequired("название специальности"));
        
        if (string.IsNullOrWhiteSpace(code))
            return Result<SpecialtyEntity>.Fail(Error.General.ValueIsRequired("код специальности"));
        
        if (code.Length > MAX_CODE_LENGTH)
            return Result<SpecialtyEntity>.Fail(Error.General.InvalidMaxLenght("код специальности", MAX_CODE_LENGTH));
        return Result.Success();
    }
}