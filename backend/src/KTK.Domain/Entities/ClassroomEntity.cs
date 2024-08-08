namespace Domain.Entities;

public sealed class ClassroomEntity : BaseEntity<ClassroomId>
{
    public ClassroomEntity(ClassroomId id ,Title title) 
        => (Id, Title) = (id, title);

    private ClassroomEntity() { }
    
    public Title Title { get; set; }
}