using Dapper;
using SpannerPlay.Domain;

namespace SpannerPlay.Data;

public interface IPaymentRepository
{
    Task<IReadOnlyList<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken = default);
}

public class PaymentRepository(ISpannerConnectionFactory connectionFactory) : IPaymentRepository
{
    public async Task<IReadOnlyList<Payment>> GetAllPaymentsAsync(CancellationToken cancellationToken = default)
    {
        const string sql = """
            SELECT
                PaymentID AS PaymentId,
                OrderID AS OrderId,
                UserID AS UserId,
                PaymentDate AS PaymentDate,
                PaymentMethod AS PaymentMethod,
                TransactionID AS TransactionId,
                AmountUSD AS AmountUsd,
                Status AS Status
            FROM Payments
            """;

        await using var connection = await connectionFactory.CreateConnectionAsync(cancellationToken);
        var payments = await connection.QueryAsync<Payment>(new CommandDefinition(sql, cancellationToken: cancellationToken));
        return payments.AsList();
    }
}
