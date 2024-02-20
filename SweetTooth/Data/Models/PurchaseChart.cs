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

    }
}
