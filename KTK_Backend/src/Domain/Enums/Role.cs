namespace Domain.Enums;

public enum Role
{
    [Description("Супер пользователь")]
    Admin,
    
    [Description("Оператор расписания")]
    ScheduleOperator,
    
    [Description("Преподаватель")]
    Teacher,
    
    [Description("Студент")]
    Student
}