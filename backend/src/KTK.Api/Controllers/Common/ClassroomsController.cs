namespace Server.Controllers.Common;

[ApiController]
[Route("api/classrooms")]
public class ClassroomsController(
    ILogger<ClassroomsController> logger) 
    : BaseController<ClassroomsController>(logger)
{
    
}