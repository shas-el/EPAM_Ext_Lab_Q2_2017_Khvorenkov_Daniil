namespace MVCApplication.Models
{
    using DAL.Model;
    using System;

    public class OrderIntroViewModel
    {
        public int OrderID { get; set; }
        public string CustomerName { get; set; }
        public OrderStatus Status { get; set; }
        public DateTime? OrderDate { get; set; }
        public decimal TotalCost { get; set; }
    }
}