namespace WorkshopManagement.Models
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public ICollection<Vehicle> Vehicles { get; set; }
    }
}
