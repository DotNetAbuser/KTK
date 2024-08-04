namespace Domain.Entities;

public sealed class FacultyEntity : BaseEntity<int>
{
    public FacultyEntity(string title, bool isActive)
        => Title = title;

    private FacultyEntity() { }
    
    public string Title { get; set; }
    public ICollection<SpecialtyEntity> Specialties { get; } = [];


}