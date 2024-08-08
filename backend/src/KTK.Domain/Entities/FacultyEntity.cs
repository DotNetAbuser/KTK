namespace Domain.Entities;

public sealed class FacultyEntity : BaseEntity<FacultyId>
{
    public FacultyEntity(FacultyId id, Title title) 
        => (Id, Title) = (id, title);

    private FacultyEntity() { }
    
    public Title Title { get; set; }

}