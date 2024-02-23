using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Data.Models
{
    public class Inventory
    {
        public int Id { get; set; }
        public string ProductName { get; set; } = string.Empty;
        public int Amount { get; set; }
        public MeasurmentEnum Measurement { get; set; } // Enum suggested
        public DateTime ExpiringDate { get; set; }


        public bool Equals(Inventory inventory)
        {
            return ProductName == inventory.ProductName && Amount == inventory.Amount && Measurement == inventory.Measurement && ExpiringDate == inventory.ExpiringDate;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as Inventory);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, Amount, Measurement, ExpiringDate);
        }

    }
}
