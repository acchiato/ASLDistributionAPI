using ASLDistributionAPI.Models;
using Microsoft.AspNetCore.DataProtection.KeyManagement;
using Microsoft.AspNetCore.Mvc;

namespace ASLDistributionAPI.Controllers
{
    [ApiController]
    [Route("api/shipment")]
    public class ShipmentController: ControllerBase
    {
        private readonly IConfiguration _config;

        public ShipmentController(IConfiguration config)
        {
            _config = config;
        }


        [HttpPost("create")]
        public IActionResult CreateShipment([FromBody] ShipmentModel request)
        {
           //Check API Key
            string clientKey = Request.Headers["x-api-key"];
            string expectedKey = _config["ShipmentApiKey"];

            if (string.IsNullOrEmpty(clientKey) || clientKey != expectedKey)
            {
                return Unauthorized(new { error = "Invalid or missing API key." });
            }

            //Validate and simulate shipment
            var errors = new List<string>();

            if (string.IsNullOrWhiteSpace(request.CarrierReferenceNumber))
                errors.Add("CarrierReferenceNumber is required");

            if (string.IsNullOrWhiteSpace(request.Delivery_Company))
                errors.Add("Delivery_Company is required");

            if (errors.Any())
            {
                return Ok(new
                {
                    d = new
                    {
                        __type = "shiptrack.ApiModels.Shipments.CreateShipmentResult",
                        Duplicates = new string[] { },
                        Errors = errors
                    }
                });
            }

            return Ok(new
            {
                d = new
                {
                    __type = "shiptrack.ApiModels.Shipments.CreateShipmentResult",
                    Duplicates = new string[] { },
                    Errors = new string[] { }
                }
            });
        }
    }
}
