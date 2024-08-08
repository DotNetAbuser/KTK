namespace Infrastructure.Services;

public class ClassroomService(
    IUnitOfWork unitOfWork,
    IClassroomRepository classroomRepository)
    : IClassroomService
{
    public async Task<IResult<PaginatedData<ClassroomResponse>>> GetPaginatedAsync(
        int pageNumber, int pageSize, string searchTerms,
        CancellationToken cancellationToken)
    {
        throw new NotImplementedException();
    }

    public async Task<IResult<ClassroomResponse?>> GetByIdAsync(
        Guid id, CancellationToken cancellationToken)
    {
        var classroomEntity = await classroomRepository.GetByIdAsync(
            id: new ClassroomId(id),
            cancellationToken: cancellationToken);
        if (classroomEntity == null)
            return Result<ClassroomResponse>.Fail("Аудитория с данным идентификатором не найдена!");
        
        var classroomResponse = new ClassroomResponse(
            Id: classroomEntity.Id.Value,
            Title: classroomEntity.Title.Value);
        
        return Result<ClassroomResponse>.Success(classroomResponse, "Аудитория успешно получена.");
    }

    public async Task<IResult> CreateAsync(
        CreateClassroomRequest request, CancellationToken cancellationToken)
    {
        var titleResult = Title.Create(request.Title);
        if (!titleResult.Succeeded)
            return Result.Fail(titleResult.Messages);
        
        var isExistIsExistByTitle = await classroomRepository
            .IsExistByTitleAsync(titleResult.Data, cancellationToken);
        if (isExistIsExistByTitle)
            return Result.Fail("Аудитория с данным название уже существует!");
        
        var classroomEntity = new ClassroomEntity(new ClassroomId(default),titleResult.Data);
        await classroomRepository.AddAsync(classroomEntity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success("Аудитория успешно создана.");
    }

    public async Task<IResult> UpdateAsync(
        Guid id, UpdateClassroomRequest request, CancellationToken cancellationToken)
    {
        var classroomEntity = await classroomRepository
            .GetByIdAsync(new ClassroomId(id), cancellationToken);
        if (classroomEntity == null)
            return Result.Fail("Аудитория с данным идентификатором не найдена!");

        var titleResult = Title.Create(request.Title);
        if (!titleResult.Succeeded)
            return Result.Fail(titleResult.Messages);
        
        var isExistByTitleForUpdate = await classroomRepository
            .IsExistByTitleForUpdateAsync(new ClassroomId(id), titleResult.Data, cancellationToken);
        if (isExistByTitleForUpdate)
            return Result.Fail("Аудитория с данным названием уже существует!");
        
        classroomEntity.Title = titleResult.Data;
        classroomEntity.UpdatedAt = DateTime.UtcNow;
        
        await classroomRepository.UpdateAsync(classroomEntity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);

        return Result.Success("Аудитория успешно обновлена.");
    }

    public async Task<IResult> DeleteAsync(Guid id, CancellationToken cancellationToken)
    {
        var classroomEntity = await classroomRepository
            .GetByIdAsync(new ClassroomId(id), cancellationToken);
        if (classroomEntity == null)
            return Result.Success("Аудитория с данным идентификатором не найдена!");

        classroomEntity.IsDeleted = true;
        classroomEntity.DeletedAt = DateTime.UtcNow;
        await classroomRepository.UpdateAsync(classroomEntity, cancellationToken);
        await unitOfWork.SaveChangesAsync(cancellationToken);
        
        return Result.Success("Аудитория успешно удалена.");
    }
}