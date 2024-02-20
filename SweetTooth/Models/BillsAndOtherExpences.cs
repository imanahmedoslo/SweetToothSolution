using SweetTooth.Models.Enums;
namespace SweetTooth.Models 
{ 
   
    public class BillsAndOtherExpences
    {
        public int Id { get; set; }
    public string ExpenceTitle { get; set; } = string.Empty;
        public ExpenceTypeEnum ExpencetType { get; set; }
        public int Price { get; set; }
        public int ClosingChart {  get; set; }

        public DailyClosingChart DailyClosingChart { get; set; } = new DailyClosingChart();



    }
}
