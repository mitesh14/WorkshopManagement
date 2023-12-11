namespace WorkshopManagement.Models
{
    public class Vehicle
    {
        public int VehicleID { get; set; }
        public int CustomerID { get; set; }
        public string? Make { get; set; }
        public string? Model { get; set; }
        public DateTime LastServiceDate { get; set; }
        public List<WorkshopSlot> WorkshopSlots { get; set; }
    }
}
