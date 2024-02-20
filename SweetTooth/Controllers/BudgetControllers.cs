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
        public async Task<IActionResult> Post([FromBody] Budget budget)
        {
            await _context.Budgets.AddAsync(budget);
            await _context.SaveChangesAsync();
            return Ok(budget);
        }
        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Budget budget)
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
   
