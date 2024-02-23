namespace SweetTooth.Data.Models
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
        public virtual ICollection<DailyClosingChart>? DailyClosingCharts { get; set; }

        public bool Equals(Budget budget)
        {
            return TotalSum == budget.TotalSum && ExpensesBudget == budget.ExpensesBudget && CharityBudget == budget.CharityBudget && WasteBudget == budget.WasteBudget && DateFrom == budget.DateFrom && DateTo == budget.DateTo && GoalEarnings == budget.GoalEarnings;
        }
        public override bool Equals(object? obj)
        {
            if (obj!=null)
            {
                return Equals(obj as Budget);

            }
            else
            {
                return false;
            }
           
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(TotalSum, ExpensesBudget, CharityBudget, WasteBudget, DateFrom, DateTo, GoalEarnings);
        }

    }
}
