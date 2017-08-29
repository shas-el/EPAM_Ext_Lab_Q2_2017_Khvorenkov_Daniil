namespace MVCApplication.Models
{
    using DAL.Model;

    public class OrderDetailsViewModel
    {
        public OrderExt Order { get; set; }
        public OrderInfo OrderInfo { get; set; }
    }
}