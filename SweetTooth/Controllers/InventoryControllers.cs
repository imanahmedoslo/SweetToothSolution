using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class InventoryControllers:ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public InventoryControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetInventoryList()
        {
            List<Inventory> inventory = await _context.Inventory.ToListAsync();
            if (inventory.Count == 0)
            {
                return NotFound();
            }
            return Ok(inventory);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetInventoryById(int id)
        {
            Inventory? inventory = await _context.Inventory.FirstOrDefaultAsync(x => x.Id == id);
            if (inventory == null)
            {
                return NotFound();
            }
            return Ok(inventory);
        }
        [HttpPost]
        public async Task<IActionResult> CreateInventory([FromBody] CreateInventory inventory)
        {
            Inventory newInventory = new Inventory
            {
                ProductName = inventory.ProductName,
                Amount = inventory.Amount,
                Measurement = (MeasurmentEnum)inventory.Measurement,
                ExpiringDate = inventory.ExpiringDate
          
            };
            await _context.Inventory.AddAsync(newInventory);
            await _context.SaveChangesAsync();
            return Ok(inventory);
        }
        [HttpPut]
        public async Task<IActionResult> EditInventory([FromBody] EditInventory inventory)
        {
            Inventory? inventoryToUpdate = await _context.Inventory.Where(x => x.Id == inventory.Id).FirstOrDefaultAsync();
            if (inventoryToUpdate == null)
            {
                return NotFound();
            }
            inventoryToUpdate.ProductName = inventory.ProductName;
            inventoryToUpdate.Amount = inventory.Amount;
            inventoryToUpdate.Measurement = (MeasurmentEnum)inventory.Measurement;
            inventoryToUpdate.ExpiringDate = inventory.ExpiringDate;

            await _context.SaveChangesAsync();
            return Ok(inventoryToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteInventory(int id)
        {
            Inventory? inventoryToDelete = await _context.Inventory.Where(x => x.Id == id).FirstOrDefaultAsync();
            if (inventoryToDelete == null)
            {
                return NotFound();
            }
            _context.Inventory.Remove(inventoryToDelete);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}
public class CreateInventory
{
    public string ProductName { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int Measurement { get; set; } 
    public DateTime ExpiringDate { get; set; }

}
public class EditInventory
{
    public int Id { get; set; }
    public string ProductName { get; set; } = string.Empty;
    public int Amount { get; set; }
    public int Measurement { get; set; }
    public DateTime ExpiringDate { get; set; }

}
