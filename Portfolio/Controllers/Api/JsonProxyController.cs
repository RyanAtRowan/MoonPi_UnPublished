using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class JsonProxyController : Controller
    {
        [HttpGet("fetchJson")]
        public IActionResult GetJsonData()
        {
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "DropDownData.json");

            if (!System.IO.File.Exists(jsonPath))
            {
                return NotFound("JSON file not found.");
            }

            var jsonData = System.IO.File.ReadAllText(jsonPath);

            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            return Content(jsonData, "application/json");
        }
    }
}
