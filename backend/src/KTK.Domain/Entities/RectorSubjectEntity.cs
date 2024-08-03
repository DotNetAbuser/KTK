namespace Domain.Entities;

public sealed class RectorSubjectEntity : BaseEntity
{
    public Guid RectorId { get; set; }
    public int SubjectId { get; set; }

    public UserEntity Rector { get; } = null!;
    public SubjectEntity Subject { get; } = null!;

    public RectorSubjectEntity(Guid rectorId, int subjectId)
        => (RectorId, SubjectId) = (rectorId, subjectId);
}