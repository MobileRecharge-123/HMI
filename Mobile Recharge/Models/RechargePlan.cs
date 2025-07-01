namespace MobileRechargeWebsite.Models
{
    public class RechargePlan
    {
        public string MobileNumber { get; set; }
        public decimal Amount { get; set; }
        public string Type { get; set; } 
        public string TransactionId { get; set; }
        public string Validity { get; set; }
        public string Description { get; set; }
    }
}