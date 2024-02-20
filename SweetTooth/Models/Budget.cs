namespace SweetTooth.Models
{
    public class Budget
    {
        public int Id { get; set; }
        public int TotalSum { get; set; }
        public int ExpensesBudget { get; set; }
        public int CharityBudget { get; set; }
        public int WasteBudget { get; set; }
        public DateTime DateFrom { get; set; }
        public DateTime DateTo { get; set; }
        public int GoalEarnings { get; set; }

       
        public virtual ICollection<PurchaseChart>? PurchaseCharts { get; set; }
        public virtual ICollection <DailyClosingChart>? DailyClosingCharts { get; set; }

       
       
    }
}
