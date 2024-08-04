namespace Domain.Entities;

public sealed class SpecialtyEntity : BaseEntity<int>
{
    public SpecialtyEntity(int faculityId, string code, string title)
        => (FaculityId, Code, Title) = (faculityId, code, title);

    private SpecialtyEntity() { }
    
    public int FaculityId { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }

    public FacultyEntity Faculty { get; } = null!;
    public ICollection<CourseEntity> Courses { get; } = [];
    public ICollection<CollectiveEntity> Collectives { get; } = [];
}