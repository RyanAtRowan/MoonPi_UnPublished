using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Portfolio.Controllers.Api
{
    /// <summary>
    /// API controller that serves JSON data from a specified file.
    /// This acts as a proxy to fetch JSON files stored on the server.
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class JsonProxyController : Controller
    {
        /// <summary>
        /// Fetches the JSON data from the specified file and returns it as a JSON response.
        /// Adds CORS headers to allow cross-origin requests.
        /// </summary>
        /// <returns>The contents of the JSON file or a 404 response if the file is not found.</returns>
        [HttpGet("fetchJson")]
        public IActionResult GetJsonData()
        {
            // Build the full path to the JSON file
            string jsonPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "Assets", "DropDownData.json");

            // Check if the file exists before trying to read it
            if (!System.IO.File.Exists(jsonPath))
            {
                // Return 404 if the JSON file is not found
                return NotFound("JSON file not found.");
            }

            // Read the contents of the JSON file
            var jsonData = System.IO.File.ReadAllText(jsonPath);

            // Add CORS headers to allow cross-origin requests
            Response.Headers.Add("Access-Control-Allow-Origin", "*");

            // Return the JSON data as plain JSON
            return Content(jsonData, "application/json");
        }
    }
}
