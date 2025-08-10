namespace TaliExpress.Server.Models
{
    public class PaymentDetails : PrimaryState
    {
        public string FullName { get; set; } = string.Empty;
        public string ID { get; set; } = string.Empty;
        public string CVV { get; set; } = string.Empty;
        public string CreditCardNumber {  get; set; } = string.Empty;
        public DateOnly ExpiryDate { get; set; } = DateOnly.MinValue;
    }
}
