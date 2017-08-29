namespace MVCApplication.Models
{
    using DAL.Model;
    using System.Collections.Generic;

    public class OrderDetailTemplateViewModel
    {
        public OrderDetailTemplateViewModel()
        {
            OrderDetails = new OrderDetail();
        }

        public int Index { get; set; }
        public OrderDetail OrderDetails { get; set; }
        public List<Product> AvailableProducts { get; set; }
    }
}