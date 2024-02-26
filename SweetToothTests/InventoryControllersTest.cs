using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetTooth.Controllers;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using Microsoft.AspNetCore.Mvc;
using SweetTooth.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;


namespace SweetToothTests
{
    public class InventoryControllersTest
    {
        private DbContextFactory factory = new DbContextFactory();
        [Fact]
        public async Task CreateInventory_checkIfResultsCorrect()
        {
            var databaseName = "CreateInventory_checkIfResultsCorrect";

            var database = factory.CreateDbContext(databaseName);
            var context = new InventoryControllers(database);
            CreateInventory inventory = new CreateInventory
            {
                ProductName = "TestProduct",
                Amount = 100,
                Measurement = 1,
                ExpiringDate = DateTime.Now
            };
            Inventory newInventory = new Inventory
            {
                Id = 0,
                ProductName = inventory.ProductName,
                Amount = inventory.Amount,
                Measurement = (MeasurmentEnum)inventory.Measurement,
                ExpiringDate = inventory.ExpiringDate
            };

            // Act
          var response=  await context.CreateInventory(inventory);
            var result = await database.Inventory.FirstOrDefaultAsync(x => x.ProductName == inventory.ProductName);
            var okresult = response as OkObjectResult;
            // Assert
            Assert.IsType<OkObjectResult>(response);
            Assert.Equal(newInventory, result);
            Assert.IsType<Inventory>(result);
        }
        [Fact]
        public async Task GetInventoryList_ReturnsAllItems()
        {
            var databaseName = "GetInventoryList_DB";
            var controller = factory.CreateDbContext(databaseName);
            var context= new InventoryControllers(controller);
 
            
               await context.CreateInventory(new CreateInventory { ProductName = "Item1", Amount = 10, Measurement = (int)MeasurmentEnum.Item, ExpiringDate = DateTime.Now.AddDays(10) });
               await context.CreateInventory(new CreateInventory { ProductName = "Item2", Amount = 20, Measurement = (int)MeasurmentEnum.Grams, ExpiringDate = DateTime.Now.AddDays(20) });
                await controller.SaveChangesAsync();
            

            var result = await context.GetInventoryList();

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<System.Collections.Generic.List<Inventory>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }
        [Fact]
        public async Task GetInventoryById_ReturnsItem()
        {
            var databaseName = "GetInventoryById_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new InventoryControllers(dbContext);

            // Act
           await controller.CreateInventory(new CreateInventory { ProductName = "Item", Amount = 10, Measurement = (int)MeasurmentEnum.Liters, ExpiringDate = DateTime.Now.AddDays(5) });
            await dbContext.SaveChangesAsync();
            var newItem = await dbContext.Inventory.FirstOrDefaultAsync(i => i.ProductName == "Item");

            var result = await controller.GetInventoryById(newItem.Id);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<Inventory>(viewResult.Value);
            Assert.Equal("Item", model.ProductName);
        }


        [Fact]
        public async Task EditInventory_UpdatesExistingItem()
        {
            var databaseName = "EditInventory_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new InventoryControllers(dbContext);

            // Act
            var inventory = new CreateInventory { ProductName = "OldItem", Amount = 5, Measurement = (int)MeasurmentEnum.Grams, ExpiringDate = DateTime.Now.AddDays(5) };
            await controller.CreateInventory(inventory);
            await dbContext.SaveChangesAsync();

            var existingItem = await dbContext.Inventory.FirstOrDefaultAsync(i => i.ProductName == "OldItem");
            var editInventory = new EditInventory { Id = existingItem.Id, ProductName = "UpdatedItem", Amount = 10, Measurement = (int)MeasurmentEnum.Liters, ExpiringDate = DateTime.Now.AddDays(10) };
            await controller.EditInventory(editInventory);
            await dbContext.SaveChangesAsync();

            var updatedItem = await dbContext.Inventory.FindAsync(existingItem.Id);

            // Assert
            Assert.NotNull(updatedItem);
            Assert.Equal("UpdatedItem", updatedItem.ProductName);
        }

        [Fact]
        public async Task DeleteInventory_RemovesItem()
        {
            var databaseName = "DeleteInventory_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new InventoryControllers(dbContext);

            // Act
            var inventory = new CreateInventory { ProductName = "DeleteMe", Amount = 10, Measurement = (int)MeasurmentEnum.Item, ExpiringDate = DateTime.Now.AddDays(5) };
            await controller.CreateInventory(inventory);
            await dbContext.SaveChangesAsync();

            var itemToDelete = await dbContext.Inventory.FirstOrDefaultAsync(i => i.ProductName == "DeleteMe");
            await controller.DeleteInventory(itemToDelete.Id);
            await dbContext.SaveChangesAsync();

            var deletedItem = await dbContext.Inventory.FindAsync(itemToDelete.Id);

            // Assert
            Assert.Null(deletedItem);
        }



    }
}
