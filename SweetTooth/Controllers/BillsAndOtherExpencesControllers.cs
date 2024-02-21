using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]

    public class BillsAndOtherExpencesControllers: ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public BillsAndOtherExpencesControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetExpencesList()
        {
            List <BillsAndOtherExpences> billsAndOtherExpences = await _context.BillsAndOtherExpences.ToListAsync();
            if (billsAndOtherExpences.Count == 0)
            {
                return NotFound();
            }
            return Ok(billsAndOtherExpences);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBillsAndOtherExpencesById(int id)
        {
            BillsAndOtherExpences? billsAndOtherExpences = await _context.BillsAndOtherExpences.FirstOrDefaultAsync(x => x.Id == id);
            if (billsAndOtherExpences == null)
            {
                return NotFound();
            }
            return Ok(billsAndOtherExpences);
        }
        [HttpPost]
        public async Task<IActionResult> CreateExpence([FromBody] CreateExpence billsAndOtherExpences)
        {
            BillsAndOtherExpences newExpence = new BillsAndOtherExpences
            {
                ExpenceTitle = billsAndOtherExpences.ExpenceTitle,
                ExpencetType = (ExpenceTypeEnum)billsAndOtherExpences.ExpencetType,
                Price = billsAndOtherExpences.Price,
                ClosingChart = billsAndOtherExpences.ClosingChart
            };
            await _context.BillsAndOtherExpences.AddAsync(newExpence);
            await _context.SaveChangesAsync();
            return Ok(billsAndOtherExpences);
        }
        [HttpPut]
        public async Task<IActionResult> EditExpence([FromBody] EditExpence billsAndOtherExpences)
        {
            BillsAndOtherExpences? ExpenceToUpdate = await _context.BillsAndOtherExpences.Where(x => x.Id == billsAndOtherExpences.Id).FirstOrDefaultAsync();
            if (ExpenceToUpdate == null)
            {
                return NotFound();
            }
            ExpenceToUpdate.ExpenceTitle = billsAndOtherExpences.ExpenceTitle;
            ExpenceToUpdate.ExpencetType = (ExpenceTypeEnum)billsAndOtherExpences.ExpencetType;
            ExpenceToUpdate.Price = billsAndOtherExpences.Price;
            ExpenceToUpdate.ClosingChart = billsAndOtherExpences.ClosingChart;
            await _context.SaveChangesAsync();
            return Ok(billsAndOtherExpences);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExpence(int id)
        {
            BillsAndOtherExpences? ExpenceToDelete = await _context.BillsAndOtherExpences.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (ExpenceToDelete == null)
            {
                return NotFound();
            }
            _context.BillsAndOtherExpences.Remove(ExpenceToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
public class CreateExpence 
{
    public string ExpenceTitle { get; set; } = string.Empty;
    public int ExpencetType { get; set; }
    public int Price { get; set; }
    public int ClosingChart { get; set; }

}
public class EditExpence
{
    public int Id { get; set; }
    public string ExpenceTitle { get; set; } = string.Empty;
    public int ExpencetType { get; set; }
    public int Price { get; set; }
    public int ClosingChart { get; set; }

}
