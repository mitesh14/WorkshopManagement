using System.ComponentModel.DataAnnotations;

namespace WorkshopManagement.Models
{
    public class WorkshopSlot
    {
        [Key]
        public int SlotID { get; set; }
        public int VehicleID { get; set; }
        public DateTime SlotDateTime { get; set; }
        public List<Vehicle> Vehicles { get; set; }
    }
}
