namespace Domain.Entities;

public sealed class SpecialtyEntity : BaseEntity<SpecialityId>
{
    public SpecialtyEntity(FacultyEntity faculty, Code code, Title title)
        => (FacultyId, Code, Title) = (faculty.Id, code, title);

    private SpecialtyEntity() { }
    
    public FacultyId FacultyId { get; set; }
    public Code Code { get; set; }
    public Title Title { get; set; }
    
}