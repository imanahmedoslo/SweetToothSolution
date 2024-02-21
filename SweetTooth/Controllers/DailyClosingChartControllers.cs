using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DailyClosingChartControllers:ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public DailyClosingChartControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetClosingChartsList()
        {
            List<DailyClosingChart> dailyClosingChart = await _context.DailyClosingCharts.ToListAsync();
            if (dailyClosingChart.Count == 0)
            {
                return NotFound();
            }
            return Ok(dailyClosingChart);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClosingChartById(int id)
        {
            DailyClosingChart dailyClosingChart = await _context.DailyClosingCharts.FirstOrDefaultAsync(x => x.Id == id);
            if (dailyClosingChart == null)
            {
                return NotFound();
            }
            return Ok(dailyClosingChart);
        }
        [HttpPost]
        public async Task<IActionResult> CreateClosingChart([FromBody] CreateClosingChart dailyClosingChart)
        {
            DailyClosingChart newClosingChart = new DailyClosingChart
            {
               Date = dailyClosingChart.Date,
               TotalCharity = dailyClosingChart.TotalCharity,
               TotalEarnings = dailyClosingChart.TotalEarnings,
               TotalWaste = dailyClosingChart.TotalWaste,
               ClosingReport = dailyClosingChart.ClosingReport,
               TotallBills = dailyClosingChart.TotallBills,
               EmployeeId = dailyClosingChart.EmployeeId,
               BudgetId = dailyClosingChart.BudgetId

            };
            await _context.DailyClosingCharts.AddAsync(newClosingChart);
            await _context.SaveChangesAsync();
            return Ok(dailyClosingChart);
        }
        [HttpPut]
        public async Task<IActionResult> EditClosingChart([FromBody] DailyClosingChart dailyClosingChart)
        {
            DailyClosingChart? closingChartToUpdate = await _context.DailyClosingCharts.Where(x => x.Id == dailyClosingChart.Id).FirstOrDefaultAsync();
            if (closingChartToUpdate == null)
            {
                return NotFound();
            }
            closingChartToUpdate.Date = dailyClosingChart.Date;
            closingChartToUpdate.TotalCharity = dailyClosingChart.TotalCharity;
            closingChartToUpdate.TotalEarnings = dailyClosingChart.TotalEarnings;
            closingChartToUpdate.TotalWaste = dailyClosingChart.TotalWaste;
            closingChartToUpdate.ClosingReport = dailyClosingChart.ClosingReport;
            closingChartToUpdate.TotallBills = dailyClosingChart.TotallBills;
            closingChartToUpdate.EmployeeId = dailyClosingChart.EmployeeId;
            closingChartToUpdate.BudgetId = dailyClosingChart.BudgetId;
            await _context.SaveChangesAsync();
            return Ok(dailyClosingChart);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteClosingChart(int id)
        {
            DailyClosingChart? closingChartToDelete = await _context.DailyClosingCharts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (closingChartToDelete == null)
            {
                return NotFound();
            }
            _context.DailyClosingCharts.Remove(closingChartToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
   

}
public class CreateClosingChart
{
    public int TotalEarnings { get; set; }
    public int TotalWaste { get; set; }
    public int TotalCharity { get; set; }
    public string ClosingReport { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int TotallBills { get; set; }
    public int EmployeeId { get; set; }
    public int BudgetId { get; set; }
}