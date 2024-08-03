namespace Domain.Entities;

public sealed class ClassroomEntity : BaseEntity
{
    public ClassroomEntity(string title, bool isActive)
        => Title = title;
    
    public int ClassroomId { get; init; }
    public string Title { get; set; }
}