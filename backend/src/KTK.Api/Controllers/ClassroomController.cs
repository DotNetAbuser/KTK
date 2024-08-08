namespace Api.Controllers;

[ApiController]
[Route("api/classroom")]
public class ClassroomController(
    IClassroomService classroomService)
    : ControllerBase
{
    // [Authorize(Policy = Permissions.Classrooms.View)]
    [HttpGet]
    public async Task<IActionResult> GetPaginatedAsync(
        int pageNumber, int pageSize, string searchTerms,
        CancellationToken cancellationToken)
    {
        var result = await classroomService.GetPaginatedAsync(
            pageNumber, pageSize, searchTerms, cancellationToken);
        return Ok(result);
    }
    
    // [Authorize(Policy = Permissions.Classrooms.View)]
    [HttpGet("{id:guid}")]
    public async Task<IActionResult> GetByIdAsync(Guid id, CancellationToken cancellationToken)
    {
        var result = await classroomService.GetByIdAsync(id, cancellationToken: cancellationToken);
        return Ok(result);
    }

    // [Authorize(Policy = Permissions.Classrooms.Create)]
    [HttpPost]
    public async Task<IActionResult> CreateAsync(
         CreateClassroomRequest request, CancellationToken cancellationToken)
    {
        return Ok(await classroomService.CreateAsync(request, cancellationToken));
    }

    // [Authorize(Policy = Permissions.Classrooms.Edit)]
    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateAsync(
        Guid id, UpdateClassroomRequest request, CancellationToken cancellationToken)
    {
        return Ok(await classroomService.UpdateAsync(id, request, cancellationToken));
    }

    // [Authorize(Policy = Permissions.Classrooms.Delete)]
    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteAsync(
        Guid id, CancellationToken cancellationToken)
    {
        return Ok(await classroomService.DeleteAsync(id, cancellationToken));
    }

   
}