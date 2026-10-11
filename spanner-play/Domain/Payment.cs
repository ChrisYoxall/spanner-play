namespace SpannerPlay.Domain;

public class Payment
{
    public long PaymentId { get; set; }
    public long OrderId { get; set; }
    public long UserId { get; set; }
    public DateTime? PaymentDate { get; set; }
    public string? PaymentMethod { get; set; }
    public string? TransactionId { get; set; }
    public decimal? AmountUsd { get; set; }
    public string? Status { get; set; }
}