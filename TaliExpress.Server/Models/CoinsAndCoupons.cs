namespace TaliExpress.Server.Models
{
    public class CoinsAndCoupons : UserOwner
    {
        public int Coins { get; set; } = 0;
        public LinkedList<Coupon> Coupons { get; set; } = new LinkedList<Coupon>();
    }
}
