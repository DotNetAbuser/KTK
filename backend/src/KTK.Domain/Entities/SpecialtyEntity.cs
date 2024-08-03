namespace Domain.Entities;

public sealed class SpecialtyEntity : BaseEntity
{
    public int SpecialtyId { get; init; }
    public int FaculityId { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }

    public FacultyEntity Faculty { get; } = null!;
    public ICollection<CourseEntity> Courses { get; } = [];
    public ICollection<SpecialtyEntity> Specialties { get; } = [];

    public SpecialtyEntity(int faculityId, string code, string title)
        => (FaculityId, Code, Title) = (faculityId, code, title);
}