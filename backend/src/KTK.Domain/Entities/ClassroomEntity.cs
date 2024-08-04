namespace Domain.Entities;

public sealed class ClassroomEntity : BaseEntity<int>
{
    public ClassroomEntity(string title, bool isActive)
        => Title = title;

    private ClassroomEntity() { }
    
    public string Title { get; set; }
}