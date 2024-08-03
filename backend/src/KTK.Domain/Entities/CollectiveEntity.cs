namespace Domain.Entities;

public class CollectiveEntity : BaseEntity
{
    public int CollectiveId { get; init; }
    public int SpecialityId { get; set; }
    public string Title { get; set; }
    public DateTime EnrollmentDate { get; set; }
    public DateTime DeducationDate { get; set; }
    
    public SpecialtyEntity Specialty { get; } = null!;
    public ICollection<StudentCollectiveEntity> StudentCollectives { get; } = [];
    
    public CollectiveEntity(int specialityId,string title, 
        DateTime enrollmentDate, DateTime deducationDate)
    {
        SpecialityId = specialityId;
        Title = title;
        EnrollmentDate = enrollmentDate;
        DeducationDate = deducationDate;
    }
}