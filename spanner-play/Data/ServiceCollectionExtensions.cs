using Dapper;

namespace SpannerPlay.Data;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddSpannerDataAccess(this IServiceCollection services)
    {
        // Encapsulate Dapper type mapping inside the Data layer
        SqlMapper.AddTypeHandler(new SpannerNumericTypeHandler());

        // Connection factory & repositories
        services.AddSingleton<ISpannerConnectionFactory, SpannerConnectionFactory>();
        services.AddScoped<IOrderRepository, OrderRepository>();
        services.AddScoped<IPaymentRepository, PaymentRepository>();

        return services;
    }
}
