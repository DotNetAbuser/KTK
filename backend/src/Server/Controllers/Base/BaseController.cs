namespace Server.Controllers.Base;

public class BaseController<TController>(
    ILogger<TController> logger)
    : ControllerBase;