using Microsoft.AspNetCore.Mvc;
using SimpleBankPaymentsAPI.Models;

namespace SimpleBankPaymentsAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TransferController : ControllerBase
    {
        [HttpPost]
        public IActionResult Post([FromBody] TransferRequest request)
        {
            if (string.IsNullOrWhiteSpace(request.FromAccount) ||
                string.IsNullOrWhiteSpace(request.ToAccount) ||
                request.Amount <= 0)
            {
                return BadRequest("Invalid transfer request.");
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
