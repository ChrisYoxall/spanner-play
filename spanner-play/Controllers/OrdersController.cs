using Microsoft.AspNetCore.Mvc;
using SpannerPlay.Data;

namespace SpannerPlay.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController(IOrderRepository orderRepository) : ControllerBase
{
    [HttpGet]
    public async Task<IActionResult> GetAllOrders(CancellationToken cancellationToken)
    {
        var orders = await orderRepository.GetAllOrdersAsync(cancellationToken);
        return Ok(orders);
    }
}