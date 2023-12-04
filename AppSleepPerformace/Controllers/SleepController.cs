namespace Sleeps.Controllers;

[ApiController]
public class SleepController : ControllerBase
{
    [HttpGet("/sleeps")]
    public IActionResult GetAll()
        => Ok(Sleeps.sleeps.ToList());
    
}
    [HttpGet("/{id}")]
    public IActionResult GetById ([FromRoute] int id)
    {
        var Sleep =
        Sleep.Sleeps.FirstOrDefault(x => x.id == id);

        if (Sleep == null){
            return Notfound();
        }

        return ok(Sleep);
    }

    [HttpPost("/sleep")]
    public IActionResult add([FromBody] Sleep sleep)
    {
        Sleep.Sleeps.add(sleep);

        return NoContent();
    }

    [HttpDelete("/{id}")]
    public IActionResult delete([FromRoute] int id)
    {
        var Sleep = Sleep.Sleeps.FirstOrDefault(x => x.id == id);
        if(user == null){
            return Notfound();
        }

        return ok(Sleep);
    }   
    
    [HttpPut("/{id}")]
    public IActionResult update([FromRoute] int id,[FromBody] Sleep sleep) 
    {
    SleepU = Sleep.Sleeps.FirstOrDefault(x => x.id == id);
    }