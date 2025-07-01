public class Transaction
{
    public int Id { get; set; }
    public string Mobile { get; set; }
    public decimal Amount { get; set; }
    public DateTime Date { get; set; }
    public string Type { get; set; } // "TopUp" or "PostPaid"
}
