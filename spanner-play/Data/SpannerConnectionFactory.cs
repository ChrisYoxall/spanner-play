using Google.Cloud.Spanner.Data;

namespace SpannerPlay.Data;

public interface ISpannerConnectionFactory
{
    SpannerConnection CreateConnection();
    Task<SpannerConnection> CreateConnectionAsync(CancellationToken cancellationToken = default);
}

public class SpannerConnectionFactory(IConfiguration configuration) : ISpannerConnectionFactory
{
    private readonly string _connectionString = configuration.GetConnectionString("Spanner")
                                                ?? throw new InvalidOperationException("Connection string 'Spanner' not found.");

    public SpannerConnection CreateConnection()
    {
        return new SpannerConnection(_connectionString);
    }

    public async Task<SpannerConnection> CreateConnectionAsync(CancellationToken cancellationToken = default)
    {
        var connection = new SpannerConnection(_connectionString);
        await connection.OpenAsync(cancellationToken);
        return connection;
    }
}
