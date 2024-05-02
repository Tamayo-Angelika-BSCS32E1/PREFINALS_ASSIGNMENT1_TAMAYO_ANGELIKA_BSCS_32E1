using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class ValuesController : ControllerBase
{
    [HttpGet]
    [Authorize]
    public IActionResult Get()
    {
        var userClaims = User.Claims.Select(c => new { c.Type, c.Value });
        // Return user information and fun facts about API creator
        return Ok(new
        {
            User = new { Name = "Angelika", Section = "BSCS", Course = "Computer Science" },
            FunFacts = new string[]
            {
                "I'm just a girl!",
                "I love reading",
                "I'm good at designing"
            }
        });
    }
}
