namespace DAL.Model
{
    using System.Collections.Generic;

    public class OrderInfo
    {
        public OrderInfo()
        {
            Details = new List<OrderInfoDetail>();
        }

        public int OrderID { get; set; }
        public List<OrderInfoDetail> Details { get; set; }

        public decimal GetTotalCost()
        {
            decimal sum = 0;

            foreach (OrderInfoDetail item in Details)
            {
                sum += item.ExtendedPrice;
            }

            return sum;
        }
    }
}
