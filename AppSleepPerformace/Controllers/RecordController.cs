namespace Records.Controllers;

[ApiController]
public class RecordController : ControllerBase
{
    [HttpGet("/Records")]
    public IActionResult GetAll()
        => Ok(Records.records.ToList());                     
    
}