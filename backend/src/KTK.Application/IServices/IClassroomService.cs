namespace Application.IServices;

public interface IClassroomService
{
    Task<IResult<PaginatedData<ClassroomResponse>>> GetPaginatedAsync(
        int pageNumber, int pageSize, string searchTerms, CancellationToken cancellationToken);
    Task<IResult<ClassroomResponse?>> GetByIdAsync(Guid id, CancellationToken cancellationToken);
    Task<IResult> CreateAsync(CreateClassroomRequest request, CancellationToken cancellationToken);
    Task<IResult> UpdateAsync(Guid id, UpdateClassroomRequest request, CancellationToken cancellationToken);
    Task<IResult> DeleteAsync(Guid id, CancellationToken cancellationToken);

}