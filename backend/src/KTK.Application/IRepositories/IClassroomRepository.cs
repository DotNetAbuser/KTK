namespace Application.IRepositories;

public interface IClassroomRepository 
{
    Task<ClassroomEntity?> GetByIdAsync(
        ClassroomId id, CancellationToken cancellationToken);
    
    Task AddAsync(ClassroomEntity classroomEntity, CancellationToken cancellationToken);
    Task UpdateAsync(ClassroomEntity entity, CancellationToken cancellationToken);
    Task<bool> IsExistByTitleAsync(Title title, CancellationToken cancellationToken);
    Task<bool> IsExistByTitleForUpdateAsync(ClassroomId id, Title title, CancellationToken cancellationToken);
}