using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Data.Models
{
    public class ShoppingListItem
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Amount { get; set; }
        public int TotalItemPrice { get; set; }
        public bool IsPurchased { get; set; }
        public MeasurmentEnum Measurement { get; set; } // Enum could be suggested
        public int PurchaseChartId { get; set; }
        public DateTime ExpiringDate { get; set; }

        // Navigation property
        public PurchaseChart? PurchaseChart { get; set; }
    }
}