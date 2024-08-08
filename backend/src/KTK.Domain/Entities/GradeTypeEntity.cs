namespace Domain.Entities;

public sealed class GradeTypeEntity 
    : BaseEntity<GradeTypeId>
{
    
    public GradeTypeEntity(
        GradeTypeId id, Title title, Description description)
    {
        Id = id;
        Title = title;
        Description = description;
    }
    
    private GradeTypeEntity() { }
    
    public Title Title { get; set; }
    public Description Description { get; set; }
}