namespace Domain.Entities;

public sealed class CourseEntity : BaseEntity<CourseId>
{
    public CourseEntity(CourseId id, SpecialtyEntity speciality, CourseIndex courseIndex)
        => (Id, SpecialityId, CourseIndex) = (id, speciality.Id, courseIndex);

    private CourseEntity() { }
    
    public SpecialityId SpecialityId { get; set; }
    public CourseIndex CourseIndex { get; set; }
}