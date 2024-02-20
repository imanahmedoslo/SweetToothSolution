namespace SweetTooth.Data.Models
{
    public class DailyClosingChart
    {
        public int Id { get; set; }
        public int TotalEarnings { get; set; }
        public int TotalWaste { get; set; }
        public int TotalCharity { get; set; }
        public string ClosingReport { get; set; } = string.Empty;
        public DateTime Date { get; set; }
        public int TotallBills { get; set; }
        public int EmployeeId { get; set; }
        public int BudgetId { get; set; }

        // Navigation properties
        public Budget? Budget { get; set; }
        public Employee? Employee { get; set; }
        public ICollection<BillsAndOtherExpences>? BillsAndOtherExpences { get; set; }



    }
}