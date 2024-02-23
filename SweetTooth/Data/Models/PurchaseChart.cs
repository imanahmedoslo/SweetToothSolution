namespace SweetTooth.Data.Models
{

    public class PurchaseChart
    {
        public int Id { get; set; }
        public int TotalPurchasePrice { get; set; }
        public string Report { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int EmployeeId { get; set; }
        public int BudgetId { get; set; }

        // Assuming a one-to-many relationship with EssentialsClosingChart
        public Employee? Employee { get; set; }
        public Budget? Budget { get; set; }
        public ICollection<ShoppingListItem> ShoppingList { get; set; } = new List<ShoppingListItem>();

        public bool Equals(PurchaseChart purchaseChart)
        {
            return TotalPurchasePrice == purchaseChart.TotalPurchasePrice && Report == purchaseChart.Report && Date == purchaseChart.Date && EmployeeId == purchaseChart.EmployeeId && BudgetId == purchaseChart.BudgetId;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as PurchaseChart);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(TotalPurchasePrice, Report, Date, EmployeeId, BudgetId);
        }
    }
}
