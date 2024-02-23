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

        public bool Equals(ShoppingListItem shoppingListItem)
        {
            return ProductName == shoppingListItem.ProductName && Amount == shoppingListItem.Amount && TotalItemPrice == shoppingListItem.TotalItemPrice && IsPurchased == shoppingListItem.IsPurchased && Measurement == shoppingListItem.Measurement && PurchaseChartId == shoppingListItem.PurchaseChartId && ExpiringDate == shoppingListItem.ExpiringDate;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as ShoppingListItem);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Amount, TotalItemPrice, IsPurchased, Measurement, PurchaseChartId, ExpiringDate);
        }
    }
}