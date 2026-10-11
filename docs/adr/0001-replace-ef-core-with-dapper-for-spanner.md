# 0001: Replace Entity Framework Core with Dapper for Spanner Data Access

Context: The project originally used `Google.Cloud.EntityFrameworkCore.Spanner` for data access. We decided to remove EF Core and adopt Dapper alongside the official ADO.NET provider `Google.Cloud.Spanner.Data` using an `IDbConnectionFactory` and repository pattern.

Decision:
1. Replace EF Core dependencies with `Dapper` and `Google.Cloud.Spanner.Data`.
2. Encapsulate connection management behind an `ISpannerConnectionFactory` providing transient `SpannerConnection` instances configured via `appsettings.json`.
3. Keep domain models cleanly decoupled from persistence by stripping EF/data annotations, using standard .NET types (`decimal`) rather than provider-specific types (`SpannerNumeric`), aliasing database columns explicitly in SQL queries (`SELECT OrderID AS OrderId...`), and registering a custom Dapper `SqlMapper.TypeHandler<decimal>` (`SpannerNumericTypeHandler`) to handle Spanner's arbitrary-precision numeric conversions transparently.
