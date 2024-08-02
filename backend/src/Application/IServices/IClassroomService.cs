namespace Application.IServices;

public interface IClassroomService
{
    Task<Result<ClassroomResponse>> GetByIdAsync(long classroomId);

}