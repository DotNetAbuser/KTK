namespace Domain.Entities;

public sealed class CollectiveStudentEntity
{
    public CollectiveStudentEntity(
        CollectiveEntity collective, UserEntity student)
        => (CollectiveId, StudentId) = (collective.Id, student.Id);

    private CollectiveStudentEntity() { }
    
    public CollectiveId CollectiveId { get; set; }
    public UserId StudentId { get; set; }
  
}