using Dapper;
using SpannerPlay.Domain;

namespace SpannerPlay.Data;

public interface IOrderRepository
{
    Task<IReadOnlyList<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default);
}

public class OrderRepository(ISpannerConnectionFactory connectionFactory) : IOrderRepository
{
    public async Task<IReadOnlyList<Order>> GetAllOrdersAsync(CancellationToken cancellationToken = default)
    {
        const string sql = """
            SELECT
                OrderID AS OrderId,
                UserID AS UserId,
                OrderDate AS OrderDate,
                ShippingAddressID AS ShippingAddressId,
                PaymentID AS PaymentId,
                TotalAmountUSD AS TotalAmountUsd,
                OrderStatus AS OrderStatus
            FROM Orders
            """;

        await using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        var orders = await connection.QueryAsync<Order>(new CommandDefinition(sql, cancellationToken: cancellationToken));
        return orders.AsList();
    }
}
