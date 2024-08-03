namespace Domain.Entities;

public sealed class CourseEntity : BaseEntity
{
    public int CourseId { get; init; }
    public int SpecialityId { get; set; }
    public int CourseIndex { get; set; }

    public SpecialtyEntity Specialty { get; } = null!;
    public ICollection<SubjectEntity> Subjects { get; } = [];

    private CourseEntity(int specialityId, int courseIndex)
        => (SpecialityId, CourseIndex) = (specialityId, courseIndex);
}