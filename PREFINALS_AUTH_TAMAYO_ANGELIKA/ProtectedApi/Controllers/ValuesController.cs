using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;

namespace ProtectedApi
{
    [ApiController]
    [Route("[controller]")]
    public class ValuesController : ControllerBase
    {
        private static readonly Random random = new Random();
        private readonly string ownerName = "Angelika Ann B. Tamayo";

        [HttpGet("about/me")]
        public IActionResult GetAboutMe()
        {
            List<string> randomFacts = new List<string>
            {
                "I'm just a girl'!",
                "I love reading.",
                "I am good at designing."
            };

            int randomIndex = random.Next(randomFacts.Count);
            string randomFact = randomFacts[randomIndex];

            var aboutMeResponse = new
            {
                Fact = randomFact
            };

            return Ok(aboutMeResponse);
        }

        [HttpGet("about")]
        public IActionResult GetAbout()
        {
            var aboutResponse = new
            {
                Owner = ownerName
            };

            return Ok(aboutResponse);
        }

        [HttpPost("about")]
        public IActionResult PostAbout([FromBody] NameRequest nameRequest)
        {
            string name = nameRequest.Name;
            var hiMessage = $"Hi, {name}, my name is {ownerName}";

            var postAboutResponse = new
            {
                Message = hiMessage
            };

            return Ok(postAboutResponse);
        }
    }

    public class NameRequest
    {
        public string Name { get; set; }
    }
}
