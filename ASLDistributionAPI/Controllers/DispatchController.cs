using ASLDistributionAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace ASLDistributionAPI.Controllers
{
    [ApiController]
    [Route("api/dispatch/jobs")]
    public class DispatchController : ControllerBase
    {
        [HttpPost("create")]
        public IActionResult CreateJob([FromBody] CreateJobQueryModel request)
        {
            //Validate Authorization header
            var expectedAuth = "Basic c2FtcGxldXNlcjpzYW1wbGVwYXNzd29yZA==";
            if (!Request.Headers.TryGetValue("Authorization", out var auth) || auth != expectedAuth)
            {
                return Unauthorized(new { error = "Unauthorized - Invalid or missing Authorization header." });
            }

            //Validate TranDateTime header
            if (!Request.Headers.TryGetValue("TranDateTime", out var tranDateTimeStr))
            {
                return BadRequest(new { error = "Missing TranDateTime header." });
            }

            if (!DateTimeOffset.TryParse(tranDateTimeStr, out var tranDateTime))
            {
                return BadRequest(new { error = "Invalid TranDateTime format." });
            }

            var errors = new List<JobModel.Result.Error>();

            if (string.IsNullOrWhiteSpace(request?.Details?.CarrierRef))
            {
                errors.Add(new JobModel.Result.Error
                {
                    Field = "CarrierRef",
                    Message = "CarrierRef is required"
                });
            }

            if (string.IsNullOrWhiteSpace(request?.Details?.SalesOrder))
            {
                errors.Add(new JobModel.Result.Error
                {
                    Field = "SalesOrder",
                    Message = "SalesOrder is required"
                });
            }

            if (errors.Any())
            {
                return Ok(new JobModel
                {
                    ID = 0,
                    Results = new JobModel.Result
                    {
                        Success = false,
                        Errors = errors
                    }
                });
            }

            return Ok(new JobModel
            {
                ID = 1622239,
                Results = new JobModel.Result
                {
                    Success = true,
                    Errors = new List<JobModel.Result.Error>()
                }
            });
        }
    }
}
