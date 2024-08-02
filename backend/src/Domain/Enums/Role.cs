namespace Domain.Enums;

public enum Role
{
    [Description("Супер пользователь")]
    Admin,
    
    [Description("Оператор расписания")]
    ScheduleOperator,
    
    [Description("Фиксатор преподавательской активности")]
    TeacherActivityRecorder,
    
    [Description("Преподаватель")]
    Teacher,
    
    [Description("Студент")]
    Student
}