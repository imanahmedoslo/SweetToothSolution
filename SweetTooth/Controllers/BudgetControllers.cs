using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BudgetControllers:ControllerBase
    {
        private readonly SweetToothDbContext _context;
                public BudgetControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetBudgetHistory()
        {
            var budgets = await _context.Budgets.ToListAsync();
            if (budgets.Count==0)
            {
                return NotFound();
            }
            return Ok(budgets);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetBudgetById(int id)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync(x => x.Id == id);
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }
        [HttpGet("date")]
        public async Task<IActionResult> GetBudgetByDate(DateTime dateFrom, DateTime dateTo)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync(x => x.DateFrom == dateFrom && x.DateTo== dateTo );
            if (budget == null)
            {
                return NotFound();
            }
            return Ok(budget);
        }
        [HttpPost]
        public async Task<IActionResult> CreateBudget([FromBody] CreateBudget budget)
        {
            Budget newBudget = new Budget
            {
                TotalSum = budget.TotalSum,
                ExpensesBudget = budget.ExpensesBudget,
                CharityBudget = budget.CharityBudget,
                WasteBudget = budget.WasteBudget,
                DateFrom = budget.DateFrom,
                DateTo = budget.DateTo,
                GoalEarnings = budget.GoalEarnings
            };
            await _context.Budgets.AddAsync(newBudget);
            await _context.SaveChangesAsync();
            return Ok(newBudget);
        }
        [HttpPut]
        public async Task<IActionResult> EditBudget([FromBody] EditBudget budget)
        {
            var budgetToUpdate = await _context.Budgets.FirstOrDefaultAsync(x => x.Id == budget.Id);
            if (budgetToUpdate == null)
            {
                return NotFound();
            }
            budgetToUpdate.TotalSum = budget.TotalSum;
            budgetToUpdate.ExpensesBudget = budget.ExpensesBudget;
            budgetToUpdate.CharityBudget = budget.CharityBudget;
            budgetToUpdate.WasteBudget = budget.WasteBudget;
            budgetToUpdate.DateFrom = budget.DateFrom;
            budgetToUpdate.DateTo = budget.DateTo;
            budgetToUpdate.GoalEarnings = budget.GoalEarnings;
            await _context.SaveChangesAsync();
            return Ok(budgetToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var budget = await _context.Budgets.FirstOrDefaultAsync(x => x.Id == id);
            if (budget == null)
            {
                return NotFound();
            }
            _context.Budgets.Remove(budget);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }

}
public class CreateBudget
{
    public int TotalSum { get; set; }
    public int ExpensesBudget { get; set; }
    public int CharityBudget { get; set; }
    public int WasteBudget { get; set; }
    public DateTime DateFrom { get; set; }
    public DateTime DateTo { get; set; }
    public int GoalEarnings { get; set; }
}
public class EditBudget 
{
  public int Id { get; set;} 
public int TotalSum { get; set; }
public int ExpensesBudget { get; set; }
public int CharityBudget { get; set; }
public int WasteBudget { get; set; }
public DateTime DateFrom { get; set; }
public DateTime DateTo { get; set; }
public int GoalEarnings { get; set; }
    
}
   
