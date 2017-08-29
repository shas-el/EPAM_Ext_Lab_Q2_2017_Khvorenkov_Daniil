namespace MVCApplication.Models
{
    using DAL.Model;
    using System.Collections.Generic;
    using System.Web.Mvc;

    public class EditViewModel
    {
        public EditViewModel()
        {
            OrderDetails = new List<OrderDetail>();
        }
        public Order Order { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
        public IEnumerable<SelectListItem> AvailableCustomers { get; set; }
        public IEnumerable<SelectListItem> AvailableEmployees { get; set; }
        public IEnumerable<SelectListItem> AvailableShippers { get; set; }
        public List<Product> AvailableProducts { get; set; }
    }
}