using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Xunit;
using SweetTooth.Controllers;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;
using Microsoft.EntityFrameworkCore;

namespace SweetToothTests
{
    public class ShoppingListItemControllersTest
    {
        private readonly DbContextFactory factory;

        public ShoppingListItemControllersTest()
        {
            factory = new DbContextFactory();
        }

        [Fact]
        public async Task GetShoppingLists_ReturnsAllItems()
        {
            var databaseName = "GetShoppingLists_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new ShoppingListItemControllers(dbContext);

           await controller.CreateShoppingList(new CreateItem { ProductName = "Milk", Amount = 2, TotalItemPrice = 100, IsPurchased = false, Measurement = (int)MeasurmentEnum.Liters, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(10) });
           await controller.CreateShoppingList(new CreateItem { ProductName = "Bread", Amount = 3, TotalItemPrice = 50, IsPurchased = true, Measurement = (int)MeasurmentEnum.Item, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(5) });
            await dbContext.SaveChangesAsync();

            var result = await controller.GetShoppingLists();

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<System.Collections.Generic.List<ShoppingListItem>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetShoppingListById_ReturnsItem()
        {
            var databaseName = "GetShoppingListById_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new ShoppingListItemControllers(dbContext);

          await  controller.CreateShoppingList(new CreateItem { ProductName = "Eggs", Amount = 12, TotalItemPrice = 200, IsPurchased = false, Measurement = (int)MeasurmentEnum.Item, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(7) });
            await dbContext.SaveChangesAsync();
            var newItem = await dbContext.ShoppingListItems.FirstOrDefaultAsync(i => i.ProductName == "Eggs");

            var result = await controller.GetShoppingListById(newItem.Id);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<ShoppingListItem>(viewResult.Value);
            Assert.Equal("Eggs", model.ProductName);
        }

        [Fact]
        public async Task CreateShoppingList_AddsNewItem()
        {
            var databaseName = "CreateShoppingList_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new ShoppingListItemControllers(dbContext);

            var newShoppingList = new CreateItem { ProductName = "Butter", Amount = 1, TotalItemPrice = 120, IsPurchased = true, Measurement = (int)MeasurmentEnum.Item, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(20) };
            await controller.CreateShoppingList(newShoppingList);
            await dbContext.SaveChangesAsync();

            var item = await dbContext.ShoppingListItems.FirstOrDefaultAsync(i => i.ProductName == "Butter");

            Assert.NotNull(item);
            Assert.Equal(newShoppingList.ProductName, item.ProductName);
        }

        [Fact]
        public async Task EditShoppingList_UpdatesExistingItem()
        {
            var databaseName = "EditShoppingList_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new ShoppingListItemControllers(dbContext);

          await  controller.CreateShoppingList(new CreateItem { ProductName = "Cheese", Amount = 2, TotalItemPrice = 300, IsPurchased = false, Measurement = (int)MeasurmentEnum.Grams, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(10) });
            await dbContext.SaveChangesAsync();
            var existingItem = await dbContext.ShoppingListItems.FirstOrDefaultAsync(i => i.ProductName == "Cheese");

            var editItem = new EditItem { Id = existingItem.Id, ProductName = "UpdatedCheese", Amount = 3, TotalItemPrice = 450, IsPurchased = true, Measurement = (int)MeasurmentEnum.Grams, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(15) };
            await controller.EditShoppingList(editItem);
            await dbContext.SaveChangesAsync();

            var updatedItem = await dbContext.ShoppingListItems.FindAsync(existingItem.Id);

            Assert.NotNull(updatedItem);
            Assert.Equal("UpdatedCheese", updatedItem.ProductName);
        }

        [Fact]
        public async Task DeleteShoppingList_RemovesItem()
        {
            var databaseName = "DeleteShoppingList_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new ShoppingListItemControllers(dbContext);

             await controller.CreateShoppingList(new CreateItem { ProductName = "Juice", Amount = 5, TotalItemPrice = 250, IsPurchased = false, Measurement = (int)MeasurmentEnum.Liters, PurchaseChartId = 1, ExpiringDate = DateTime.Now.AddDays(30) });
            await dbContext.SaveChangesAsync();
            var itemToDelete = await dbContext.ShoppingListItems.FirstOrDefaultAsync(i => i.ProductName == "Juice");

            await controller.DeleteShoppingList(itemToDelete.Id);
            await dbContext.SaveChangesAsync();

            var deletedItem = await dbContext.ShoppingListItems.FindAsync(itemToDelete.Id);

            Assert.Null(deletedItem);
        }
    }
}
