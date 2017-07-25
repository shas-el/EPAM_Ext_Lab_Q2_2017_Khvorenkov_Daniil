namespace DAL.Model
{
    using System.Collections.Generic;

    public class CustomerOrderHistory
    {
        public CustomerOrderHistory()
        {
            Details = new List<CustomerOrderHistoryDetail>();
        }

        public string CustomerID { get; set; }
        public List<CustomerOrderHistoryDetail> Details { get; set; }

        public int TotalQuantity
        {
            get
            {
                var sum = 0;

                foreach (var item in Details)
                {
                    sum += item.Quantity;
                }

                return sum;
            }
        }
    }
}
