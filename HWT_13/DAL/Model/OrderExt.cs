namespace DAL.Model
{
    public class OrderExt : Order
    {
        public string CustomerName { get; set; }
        public string EmployeeLastName { get; set; }
        public string EmployeeFirstName { get; set; }
        public string ShipperName { get; set; }
    }
}
