namespace Infrastructure.Services;

public class ClassroomService(
    IClassroomRepository classroomRepository)
    : IClassroomService
{
    public async Task<Result<ClassroomResponse>> GetByIdAsync(long classroomId)
    {
        var classroomEntity = await classroomRepository.GetByIdAsync(classroomId);
        if (classroomEntity == null)
            return Result<ClassroomResponse>.Fail("Аудитория с данным идентификатором не найдена!");

        var classroomResponse = new ClassroomResponse(
            classroomEntity.Id, classroomEntity.Title, classroomEntity.IsActive);
        return Result<ClassroomResponse>.Success();
    }
    
}