namespace Domain.Entities;

public sealed class SubjectEntity : BaseEntity<int>
{
    public SubjectEntity(
        int courseId, string code, string title, int hours)
    {
        CourseId = courseId;
        Code = code;
        Title = title;
        Hours = hours;
    }

    private SubjectEntity() { }
    
    public int CourseId { get; set; }
    public string Code { get; set; }
    public string Title { get; set; }
    public int Hours { get;  set; }

    public CourseEntity Course { get; } = null!;
    public ICollection<UserEntity> Rectors{ get; } = [];
}