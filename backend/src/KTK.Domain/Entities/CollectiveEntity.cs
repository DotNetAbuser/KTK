namespace Domain.Entities;

public class CollectiveEntity : BaseEntity<CollectiveId>
{
    public CollectiveEntity(SpecialtyEntity speciality, Title title, 
        DateTime enrollmentAt, DateTime deducationAt)
    {
        SpecialityId = speciality.Id;
        Title = title;
        EnrollmentAt = enrollmentAt;
        DeducationAt = deducationAt;
    }

    private CollectiveEntity() { }
    
    public SpecialityId SpecialityId { get; set; }
    public Title Title { get; set; }
    public DateTime EnrollmentAt { get; set; }
    public DateTime DeducationAt { get; set; }
}