namespace Domain.Entities;

public sealed class SubjectEntity : BaseEntity<SubjectId>
{
    public SubjectEntity(
        CourseEntity course, Code code, Title title, int hours)
    {
        CourseId = course.Id;
        Code = code;
        Title = title;
        Hours = hours;
    }

    private SubjectEntity() { }
    
    public CourseId CourseId { get; set; }
    public Code Code { get; set; }
    public Title Title { get; set; }
    public int Hours { get;  set; }

}