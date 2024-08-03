namespace Domain.Entities;

public sealed class FacultyEntity : BaseEntity
{
    public int FacultyId { get; init; }
    public string Title { get; set; }
    public ICollection<SpecialtyEntity> Specialties { get; } = [];

    private FacultyEntity(string title, bool isActive)
        => Title = title;
}