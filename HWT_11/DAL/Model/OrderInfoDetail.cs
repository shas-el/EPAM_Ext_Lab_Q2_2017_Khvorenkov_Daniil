namespace DAL.Model
{
    using System;

    public class OrderInfoDetail
    {
        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }
        public Single Discount { get; set; }
        public decimal ExtendedPrice { get; set; }
    }
}
