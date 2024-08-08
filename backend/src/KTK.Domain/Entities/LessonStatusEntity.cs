namespace Domain.Entities;

public sealed class LessonStatusEntity : BaseEntity<LessonStatusId>
{
    public LessonStatusEntity(
        LessonStatusId id, Title title, Description description, string colorHex)
    {
        Id = id;
        Title = title;
        Description = description;
        ColorHex = colorHex;
    }

    private LessonStatusEntity() { }
    
    public Title Title { get; set; }
    public Description Description { get; set; }
    public string ColorHex { get; set; }
}