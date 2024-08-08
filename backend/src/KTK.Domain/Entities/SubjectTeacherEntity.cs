namespace Domain.Entities;

public sealed class SubjectTeacherEntity
{
    public SubjectTeacherEntity(SubjectEntity subject, UserEntity teacher)
        => (SubjectId, TeacherId) = (subject.Id, teacher.Id);

    private SubjectTeacherEntity() { }
    
    public SubjectId SubjectId { get; set; }
    public UserId TeacherId { get; set; }



}