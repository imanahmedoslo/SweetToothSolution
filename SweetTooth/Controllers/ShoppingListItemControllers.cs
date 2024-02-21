using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ShoppingListItemControllers:ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public ShoppingListItemControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetShoppingLists()
        {
            List<ShoppingListItem> shoppingList = await _context.ShoppingListItems.ToListAsync();
            if (shoppingList.Count == 0)
            {
                return NotFound();
            }
            return Ok(shoppingList);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetShoppingListById(int id)
        {
            ShoppingListItem? shoppingList = await _context.ShoppingListItems.FirstOrDefaultAsync(x => x.Id == id);
            if (shoppingList == null)
            {
                return NotFound();
            }
            return Ok(shoppingList);
        }
        [HttpPost]
        public async Task<IActionResult> CreateShoppingList([FromBody] CreateItem shoppingList)
        {
            ShoppingListItem newShoppingList = new ShoppingListItem
            {
                ProductName = shoppingList.ProductName,
                Amount = shoppingList.Amount,
                TotalItemPrice = shoppingList.TotalItemPrice,
                IsPurchased = shoppingList.IsPurchased,
                Measurement = (MeasurmentEnum)shoppingList.Measurement,
                PurchaseChartId = shoppingList.PurchaseChartId,
                ExpiringDate = shoppingList.ExpiringDate
            };
            await _context.ShoppingListItems.AddAsync(newShoppingList);
            await _context.SaveChangesAsync();
            return Ok(shoppingList);
        }
        [HttpPut]
        public async Task<IActionResult> EditShoppingList([FromBody] ShoppingListItem shoppingList)
        {
            ShoppingListItem? shoppingListToUpdate = await _context.ShoppingListItems.Where(x => x.Id == shoppingList.Id).FirstOrDefaultAsync();
            if (shoppingListToUpdate == null)
            {
                return NotFound();
            }
            shoppingListToUpdate.ProductName = shoppingList.ProductName;
            shoppingListToUpdate.Amount = shoppingList.Amount;
            shoppingListToUpdate.TotalItemPrice = shoppingList.TotalItemPrice;
            shoppingListToUpdate.IsPurchased = shoppingList.IsPurchased;
            shoppingListToUpdate.Measurement = shoppingList.Measurement;
            shoppingListToUpdate.PurchaseChartId = shoppingList.PurchaseChartId;
            shoppingListToUpdate.ExpiringDate = shoppingList.ExpiringDate;
            await _context.SaveChangesAsync();
            return Ok(shoppingList);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteShoppingList(int id)
        {
            ShoppingListItem? shoppingList = await _context.ShoppingListItems.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (shoppingList == null)
            {
                return NotFound();
            }
            _context.ShoppingListItems.Remove(shoppingList);
            await _context.SaveChangesAsync();
            return Ok();
        }

    }
}
public class CreateItem
{
   
    public string ProductName { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int TotalItemPrice { get; set; }
    public bool IsPurchased { get; set; }
    public int Measurement { get; set; } // Enum could be suggested
    public int PurchaseChartId { get; set; }
    public DateTime ExpiringDate { get; set; }
}
