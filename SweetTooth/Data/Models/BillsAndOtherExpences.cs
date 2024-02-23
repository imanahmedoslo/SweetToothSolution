using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Data.Models
{

    public class BillsAndOtherExpences
    {
        public int Id { get; set; }
        public string ExpenceTitle { get; set; } = string.Empty;
        public ExpenceTypeEnum ExpencetType { get; set; }
        public int Price { get; set; }
        public int ClosingChart { get; set; }

        public DailyClosingChart DailyClosingChart { get; set; } = new DailyClosingChart();


        public bool Equals(BillsAndOtherExpences billsAndOtherExpences)
        {
            return ExpenceTitle == billsAndOtherExpences.ExpenceTitle && ExpencetType == billsAndOtherExpences.ExpencetType && Price == billsAndOtherExpences.Price && ClosingChart == billsAndOtherExpences.ClosingChart;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as BillsAndOtherExpences);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ExpenceTitle, ExpencetType, Price, ClosingChart);
        }

    }
}
