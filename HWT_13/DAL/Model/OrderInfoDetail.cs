namespace DAL.Model
{
    using System;

    public class OrderInfoDetail
    {
        private Single discount;
        private int discountPercent;

        public string ProductName { get; set; }
        public decimal UnitPrice { get; set; }
        public Int16 Quantity { get; set; }

        public Single Discount
        {
            get
            {
                return discount;
            }

            set
            {
                discount = value;
                discountPercent = (int)(value * 100); 
            }
        }

        public int DiscountPercent
        {
            get
            {
                return discountPercent;
            }

            set
            {
                discountPercent = value;
                discount = value / 100;
            }
        }

        public decimal ExtendedPrice
        {
            get
            {
                return UnitPrice * (decimal)(1 - Discount) * Quantity;
            }
        }
    }
}
