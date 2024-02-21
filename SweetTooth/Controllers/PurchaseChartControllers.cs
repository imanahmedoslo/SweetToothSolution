using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PurchaseChartControllers:ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public PurchaseChartControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetPurchaseChartList()
        {
            List<PurchaseChart> purchaseChart = await _context.PurchaseCharts.ToListAsync();
            if (purchaseChart.Count == 0)
            {
                return NotFound();
            }
            return Ok(purchaseChart);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetPurchaseChartById(int id)
        {
            PurchaseChart? purchaseChart = await _context.PurchaseCharts.FirstOrDefaultAsync(x => x.Id == id);
            if (purchaseChart == null)
            {
                return NotFound();
            }
            return Ok(purchaseChart);
        }
        [HttpPost]
        public async Task<IActionResult> CreatePurchaseChart([FromBody] CreatePurchaseChart purchaseChart)
        {
            PurchaseChart newPurchaseChart = new PurchaseChart
            {
                TotalPurchasePrice = purchaseChart.TotalPurchasePrice,
                Report = purchaseChart.Report,
                Date = purchaseChart.Date,
                EmployeeId = purchaseChart.EmployeeId,
                BudgetId = purchaseChart.BudgetId
            };
            await _context.PurchaseCharts.AddAsync(newPurchaseChart);
            await _context.SaveChangesAsync();
            return Ok(purchaseChart);
        }
        [HttpPut]
        public async Task<IActionResult> EditPurchaseChart([FromBody] EditPurchaseChart purchaseChart)
        {
            PurchaseChart? purchaseChartToUpdate = await _context.PurchaseCharts.Where(x => x.Id == purchaseChart.Id).FirstOrDefaultAsync();
            if (purchaseChartToUpdate == null)
            {
                return NotFound();
            }
            purchaseChartToUpdate.TotalPurchasePrice = purchaseChart.TotalPurchasePrice;
            purchaseChartToUpdate.Report = purchaseChart.Report;
            purchaseChartToUpdate.Date = purchaseChart.Date;
            purchaseChartToUpdate.EmployeeId = purchaseChart.EmployeeId;
            purchaseChartToUpdate.BudgetId = purchaseChart.BudgetId;
            await _context.SaveChangesAsync();
            return Ok(purchaseChart);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePurchaseChart(int id)
        {
            PurchaseChart? purchaseChart = await _context.PurchaseCharts.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (purchaseChart == null)
            {
                return NotFound();
            }
            _context.PurchaseCharts.Remove(purchaseChart);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
public class CreatePurchaseChart
{
    public int TotalPurchasePrice { get; set; }
    public string Report { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int EmployeeId { get; set; }
    public int BudgetId { get; set; }

}
public class EditPurchaseChart {
    public int Id { get; set; }
    public int TotalPurchasePrice { get; set; }
    public string Report { get; set; } = string.Empty;
    public DateTime Date { get; set; }
    public int EmployeeId { get; set; }
    public int BudgetId { get; set; }
}

