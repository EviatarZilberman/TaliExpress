namespace TaliExpress.Server.Models
{
    public class UserPaymentDetails : UserOwner
    {
        public LinkedList<PaymentDetails> PaymentDetails { get; set; } = new LinkedList<PaymentDetails>();
    }
}
