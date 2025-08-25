using TaliExpress.Server.Enums;

namespace TaliExpress.Server.Models
{
    public class Coupon
    {
        public DateTime CreationDate {  get; init; } = DateTime.Now;
        public double Value { get; init; } = 0;
        public LinkedList<CouponConditions> Conditions { get; init; } = new LinkedList<CouponConditions>();
    }
}
