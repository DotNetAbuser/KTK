namespace Domain.Entities;

public sealed class LessonEntity 
    : BaseEntity<LessonId>
{
    public LessonEntity(
        LessonId id,
        ClassroomEntity classroom,
        CollectiveEntity collective, 
        SubjectEntity subject,
        UserEntity teacher,
        LessonStatusEntity lessonStatus,
        int subGroup,
        TimeOnly startAt,
        TimeOnly endAt,
        DateOnly studyAt)
    {
        Id = id;
        ClassroomId = classroom.Id;
        CollectiveId = collective.Id;
        SubjectId = subject.Id;
        TeacherId = teacher.Id;
        LessonStatusId = lessonStatus.Id;
        SubGroup = subGroup;
        StartAt = startAt;
        EndAt = endAt;
        StudyAt = studyAt;
    }

    private LessonEntity() { }

    public ClassroomId ClassroomId { get; set; }
    public CollectiveId CollectiveId { get; set; }
    public SubjectId SubjectId { get; set; }
    public UserId TeacherId { get; set; }
    public LessonStatusId LessonStatusId { get; set; }
    public int SubGroup { get; set; }
    public TimeOnly StartAt { get; set; }
    public TimeOnly EndAt { get; set; }
    public DateOnly StudyAt { get; set; }
}