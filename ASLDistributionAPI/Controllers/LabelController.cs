using System.Text;
using Microsoft.AspNetCore.Mvc;

namespace ASLDistributionAPI.Controllers
{
    [ApiController]
    [Route("api/dispatch/label")]
    public class LabelController : ControllerBase
    {
        private readonly IConfiguration _config;

        public LabelController(IConfiguration config)
        {
            _config = config;
        }

        [HttpGet("getlabel/{id}")]
        public IActionResult GetLabel(long id)
        {
            //Validate Authorization header
            if (!Request.Headers.TryGetValue("Authorization", out var authHeader))
            {
                return Unauthorized(new { error = "Missing Authorization header." });
            }

            string expectedAuth = _config["GetLabelAuthKey"];
            if (authHeader != expectedAuth)
            {
                return Unauthorized(new { error = "Invalid Authorization header." });
            }

            if (id <= 0)
            {
                return BadRequest(new { Error = "Invalid Job ID" });
            }

            string fakePdf = Convert.ToBase64String(Encoding.UTF8.GetBytes($"PDF content for job ID {id}"));

            return Ok(new
            {
                JobId = id,
                PdfBase64 = fakePdf
            });
        }

    }
}
