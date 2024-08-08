using Domain.ValueObjects;

namespace Infrastructure.Repositories;

public class ClassroomRepository(
    ApplicationDbContext dbContext) 
    : IClassroomRepository
{
    private readonly DbSet<ClassroomEntity> _dbSet = dbContext.Set<ClassroomEntity>();

    public async Task<ClassroomEntity?> GetByIdAsync(
        ClassroomId id, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .SingleOrDefaultAsync(c => c.Id == id, cancellationToken);
    }


    public async Task AddAsync(ClassroomEntity classroomEntity, CancellationToken cancellationToken) =>
        await _dbSet.AddAsync(classroomEntity, cancellationToken);
    

    public async Task UpdateAsync(ClassroomEntity entity, CancellationToken cancellationToken)
    {
        await _dbSet
            .Where(c => c.Id == entity.Id)
            .ExecuteUpdateAsync(c => c
                .SetProperty(p => p.Title, entity.Title)
                .SetProperty(p => p.UpdatedAt, entity.UpdatedAt)
                .SetProperty(p => p.IsDeleted, entity.IsDeleted)
                .SetProperty(p => p.DeletedAt, entity.DeletedAt), cancellationToken);
    }


    public async Task<bool> IsExistByTitleAsync(Title title, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .AnyAsync(c => c.Title == title, cancellationToken);
    }

    public async Task<bool> IsExistByTitleForUpdateAsync(ClassroomId id, Title title, CancellationToken cancellationToken)
    {
        return await _dbSet
            .AsNoTracking()
            .AnyAsync(c => c.Id != id && c.Title == title, cancellationToken);
    }
}