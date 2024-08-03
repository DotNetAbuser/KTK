
namespace Application.IRepositories;

public interface IClassroomRepository
{
    Task<ClassroomEntity?> GetByIdAsync(long classroomId);

    Task<PaginatedData<ClassroomEntity>> GetPaginatedActiveAsync(
        int pageNumber, int pageSize, string searchTerms);
    Task<PaginatedData<ClassroomEntity>> GetPaginatedInactiveAsync(
        int pageNumber, int pageSize, string searchTerms);
    Task<PaginatedData<ClassroomEntity>> GetPaginatedAllAsync(
        int pageNumber, int pageSize, string searchTerms);

    Task<int> AddAsync(ClassroomEntity entity);
    Task<int> UpdateAsync(ClassroomEntity entity);
    Task<int> DeleteAsync(ClassroomEntity entity);
}