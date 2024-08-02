namespace Domain.Entities;

public class CollectiveEntity : BaseEntity
{
    public const int MAX_TITLE_LENGHT = 256;

    public int CollectiveId { get; } = default!;
    public int SpecialityId { get; private set; }
    public string Title { get; private set; }
    public DateTimeOffset EnrollmentDate { get; private set; }
    public DateTimeOffset DeducationDate { get; private set; }
    public bool IsActive { get; private set; }

    public SpecialtyEntity Specialty { get; } = null!;

    public static IResult<CollectiveEntity> Create(int specialityId, string title, 
        DateTimeOffset enrollmentDate, DateTimeOffset deducationDate,
        bool isActive)
    {
        var validationResult = ValidateEntity(specialityId, title, enrollmentDate, deducationDate);
        if (!validationResult.Succeeded)
            return Result<CollectiveEntity>.Fail(validationResult.Messages);
        
        var entity = new CollectiveEntity(specialityId, title, enrollmentDate, deducationDate, isActive);
        return Result<CollectiveEntity>.Success(entity);
    }

    public IResult Update(int specialityId, string title, 
        DateTimeOffset enrollmentDate, DateTimeOffset deducationDate,
        bool isActive)
    {
        var validationResult = ValidateEntity(specialityId, title, enrollmentDate, deducationDate);
        if (!validationResult.Succeeded)
            return Result<CollectiveEntity>.Fail(validationResult.Messages);

        SpecialityId = specialityId;
        Title = title;
        EnrollmentDate = enrollmentDate;
        DeducationDate = deducationDate;
        IsActive = isActive;
        return Result.Success();
    }

    private CollectiveEntity(int specialityId,string title, 
        DateTimeOffset enrollmentDate, DateTimeOffset deducationDate,
        bool isActive)
    {
        SpecialityId = specialityId;
        Title = title;
        EnrollmentDate = enrollmentDate;
        DeducationDate = deducationDate;
        IsActive = isActive;
        Created = DateTimeOffset.UtcNow;
    }

    private static IResult ValidateEntity(int specialityId,string title, 
        DateTimeOffset enrollmentDate, DateTimeOffset deducationDate)
    {
        if (specialityId < 1)
            return Result.Fail(Error.General.ValueIsInvalid("специальность"));
        
        if (string.IsNullOrWhiteSpace(title))
            return Result.Fail(Error.General.ValueIsRequired("название группы"));
        
        if (title.Length > MAX_TITLE_LENGHT)
            return Result.Fail(Error.General.InvalidMaxLenght("название группы", MAX_TITLE_LENGHT));
        
        if (enrollmentDate > deducationDate)
            return Result.Fail(Error.General.ValueIsInvalid("дата зачисления"));

        if (deducationDate < enrollmentDate)
            return Result.Fail(Error.General.ValueIsInvalid("дата отчисления"));
        return Result.Success();
    }
}