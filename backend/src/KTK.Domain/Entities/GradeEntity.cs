namespace Domain.Entities;

public sealed class GradeEntity
    : BaseEntity<GradeId>
{
    public GradeEntity(
        GradeId id,
        LessonEntity lesson,
        UserEntity student,
        GradeTypeEntity gradeType,
        Description description)
    {
        Id = id;
        LessonId = lesson.Id;
        StudentId = student.Id;
        GradeTypeId = gradeType.Id;
        Description = description;
    }

    private GradeEntity() { }

    public LessonId LessonId { get; set; }
    public UserId StudentId { get; set; }
    public GradeTypeId GradeTypeId { get; set; }
    public Description Description { get; set; }
}