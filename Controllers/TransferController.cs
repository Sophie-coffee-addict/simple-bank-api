using Microsoft.AspNetCore.Mvc;
using SimpleBankPaymentsAPI.Models;
using Microsoft.Extensions.Logging;

namespace SimpleBankPaymentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        private readonly ILogger<TransferController> _logger;

        public TransferController(ILogger<TransferController> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        public IActionResult Post([FromBody] TransferRequest request)
        {

            _logger.LogInformation($"Received transfer request from {request.FromAccount} to {request.ToAccount} of amount {request.Amount} at {DateTime.UtcNow}");

            if (string.IsNullOrWhiteSpace(request.FromAccount) ||
                string.IsNullOrWhiteSpace(request.ToAccount) ||
                request.Amount <= 0)
            {
                return BadRequest("Invalid transfer request.");
            }

            if (request.Amount == 999)
            {
                throw new Exception("Simulated system failure!");
            }


            var result = new
            {
                TransactionId = Guid.NewGuid().ToString(),
                Status = "Success",
                Timestamp = DateTime.UtcNow
            };

            return Ok(result);
        }
    }
}
