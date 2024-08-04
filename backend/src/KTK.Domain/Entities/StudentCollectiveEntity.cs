namespace Domain.Entities;

public sealed class StudentCollectiveEntity
{
    public StudentCollectiveEntity(
        Guid studentId, int collectiveId)
        => (StudentId, CollectiveId) = (studentId, collectiveId);

    private StudentCollectiveEntity() { }
    
    public Guid StudentId { get; set; }
    public int CollectiveId { get; set; }
}