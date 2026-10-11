using Microsoft.AspNetCore.Mvc;
using SpannerPlay.Data;

namespace SpannerPlay.Controllers;

[ApiController]
[Route("[controller]")]
public class PaymentsController(IPaymentRepository paymentRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllPayments(CancellationToken cancellationToken)
    {
        var payments = await paymentRepository.GetAllPaymentsAsync(cancellationToken);
        return Ok(payments);
    }
}