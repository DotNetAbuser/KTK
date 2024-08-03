namespace Domain.Entities;

public sealed class StudentCollectiveEntity : BaseEntity
{
    public Guid StudentId { get; set; }
    public int CollectiveId { get; set; }

    public UserEntity Student { get; } = null!;
    public CollectiveEntity Collective { get; } = null!;
    
    public StudentCollectiveEntity(
        Guid studentId, int collectiveId)
    {
        StudentId = studentId;
        CollectiveId = collectiveId;
    }
    
}