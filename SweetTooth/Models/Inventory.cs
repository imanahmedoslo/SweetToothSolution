using SweetTooth.Models.Enums;

namespace SweetTooth.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Amount { get; set; }
        public MeasurmentEnum Measurement { get; set; } // Enum suggested
        public DateTime ExpiringDate { get; set; }
        

      
    }
}
