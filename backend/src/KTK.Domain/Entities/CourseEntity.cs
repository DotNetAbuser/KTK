namespace Domain.Entities;

public sealed class CourseEntity : BaseEntity<int>
{
    public CourseEntity(int specialityId, int courseIndex)
        => (SpecialityId, CourseIndex) = (specialityId, courseIndex);

    private CourseEntity() { }
    
    public int SpecialityId { get; set; }
    public int CourseIndex { get; set; }

    public SpecialtyEntity Specialty { get; } = null!;
    public ICollection<SubjectEntity> Subjects { get; } = [];


}