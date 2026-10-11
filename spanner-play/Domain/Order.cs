namespace SpannerPlay.Domain;

public class Order
{
    public long OrderId { get; set; } 
    public long UserId { get; set; }
    public DateTime? OrderDate { get; set; }
    public long? ShippingAddressId { get; set; }
    public long? PaymentId { get; set; }
    public decimal? TotalAmountUsd { get; set; }
    public string? OrderStatus { get; set; }
}