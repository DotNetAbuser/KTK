namespace Domain.Entities;

public sealed class RectorSubjectEntity
{
    public RectorSubjectEntity(Guid rectorId, int subjectId)
        => (RectorId, SubjectId) = (rectorId, subjectId);

    private RectorSubjectEntity() { }
    
    public Guid RectorId { get; set; }
    public int SubjectId { get; set; }


}