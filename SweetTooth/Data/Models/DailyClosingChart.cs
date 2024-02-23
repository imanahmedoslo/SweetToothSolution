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

        public bool Equals(DailyClosingChart dailyClosingChart)
        {
            return TotalEarnings == dailyClosingChart.TotalEarnings && TotalWaste == dailyClosingChart.TotalWaste && TotalCharity == dailyClosingChart.TotalCharity && ClosingReport == dailyClosingChart.ClosingReport && Date == dailyClosingChart.Date && TotallBills == dailyClosingChart.TotallBills && EmployeeId == dailyClosingChart.EmployeeId && BudgetId == dailyClosingChart.BudgetId;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as DailyClosingChart);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(TotalEarnings, TotalWaste, TotalCharity, ClosingReport, Date, TotallBills, EmployeeId, BudgetId);
        }


    }
}