using Application.IServices;

namespace Server.Controllers.Common;

[ApiController]
[Route("api/classrooms")]
public class ClassroomsController(
    ILogger<ClassroomsController> logger,
    IClassroomService classroomService) 
    : BaseController<ClassroomsController>(logger)
{
    [HttpGet("{classroomId:long}")]
    public async Task<IActionResult> GetByIdAsync(long classroomId)
    {
        try
        {
            return Ok(await classroomService.GetByIdAsync(classroomId));
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest("Произошло исключение при попытке получения аудитории по идентификатору!");
        }
    }
    
    [HttpGet("paginated/active")]
    public async Task<IActionResult> GetPaginatedActiveClassrooms(
        int pageNumber, int pageSize,
        string searchTerms)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest("Произошло исключение при попытке получения аудитории по идентификатору!");
        }
    }

    [HttpGet("paginated/inactive")]
    public async Task<IActionResult> GetPaginatedInactiveClassrooms(
        int pageNumber, int pageSize,
        string searchTerms)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest("Произошло исключение при попытке получения аудитории по идентификатору!");
        }
    }

    [HttpGet("paginated/all")]
    public async Task<IActionResult> GetPaginatedClassrooms(
        int pageNumber, int pageSize,
        string searchTerms)
    {
        try
        {
            return Ok();
        }
        catch (Exception ex)
        {
            logger.LogError(ex.Message);
            return BadRequest("Произошло исключение при попытке получения аудитории по идентификатору!");
        }
    }

}