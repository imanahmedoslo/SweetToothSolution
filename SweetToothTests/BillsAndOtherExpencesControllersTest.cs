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
    public class BillsAndOtherExpencesControllersTest
    {
        private readonly DbContextFactory factory;

        public BillsAndOtherExpencesControllersTest()
        {
            factory = new DbContextFactory();
        }

        [Fact]
        public async Task GetExpencesList_ReturnsAllItems()
        {
            var databaseName = "GetExpencesList_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new BillsAndOtherExpencesControllers(dbContext);

           await controller.CreateExpence(new CreateExpence { ExpenceTitle = "Rent", ExpencetType = (int)ExpenceTypeEnum.Bill, Price = 1000, ClosingChart = 1 });
          await  controller.CreateExpence(new CreateExpence { ExpenceTitle = "Utilities", ExpencetType = (int)ExpenceTypeEnum.Bill, Price = 200, ClosingChart = 1 });
            await dbContext.SaveChangesAsync();

            var result = await controller.GetExpencesList();

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<System.Collections.Generic.List<BillsAndOtherExpences>>(viewResult.Value);
            Assert.Equal(2, model.Count);
        }

        [Fact]
        public async Task GetBillsAndOtherExpencesById_ReturnsItem()
        {
            var databaseName = "GetBillsAndOtherExpencesById_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new BillsAndOtherExpencesControllers(dbContext);

           await controller.CreateExpence(new CreateExpence { ExpenceTitle = "Internet", ExpencetType = (int)ExpenceTypeEnum.Bill, Price = 60, ClosingChart = 1 });
            await dbContext.SaveChangesAsync();
            var newItem = await dbContext.BillsAndOtherExpences.FirstOrDefaultAsync(e => e.ExpenceTitle == "Internet");

            var result = await controller.GetBillsAndOtherExpencesById(newItem.Id);

            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<BillsAndOtherExpences>(viewResult.Value);
            Assert.Equal("Internet", model.ExpenceTitle);
        }

        [Fact]
        public async Task CreateExpence_AddsNewItem()
        {
            var databaseName = "CreateExpence_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new BillsAndOtherExpencesControllers(dbContext);

            var newExpence = new CreateExpence { ExpenceTitle = "Cleaning", ExpencetType = (int)ExpenceTypeEnum.Bill, Price = 150, ClosingChart = 1 };
            await controller.CreateExpence(newExpence);
            await dbContext.SaveChangesAsync();

            var item = await dbContext.BillsAndOtherExpences.FirstOrDefaultAsync(e => e.ExpenceTitle == "Cleaning");

            Assert.NotNull(item);
            Assert.Equal(newExpence.ExpenceTitle, item.ExpenceTitle);
        }

        [Fact]
        public async Task EditExpence_UpdatesExistingItem()
        {
            var databaseName = "EditExpence_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new BillsAndOtherExpencesControllers(dbContext);

          await  controller.CreateExpence(new CreateExpence { ExpenceTitle = "Security", ExpencetType = (int)ExpenceTypeEnum.Other, Price = 200, ClosingChart = 1 });
            await dbContext.SaveChangesAsync();
            var existingItem = await dbContext.BillsAndOtherExpences.FirstOrDefaultAsync(e => e.ExpenceTitle == "Security");

            var editExpence = new EditExpence { Id = existingItem.Id, ExpenceTitle = "UpdatedSecurity", ExpencetType = (int)ExpenceTypeEnum.OutSource, Price = 250, ClosingChart = 1 };
            await controller.EditExpence(editExpence);
            await dbContext.SaveChangesAsync();

            var updatedItem = await dbContext.BillsAndOtherExpences.FindAsync(existingItem.Id);

            Assert.NotNull(updatedItem);
            Assert.Equal("UpdatedSecurity", updatedItem.ExpenceTitle);
        }

        [Fact]
        public async Task DeleteExpence_RemovesItem()
        {
            var databaseName = "DeleteExpence_DB";
            var dbContext = factory.CreateDbContext(databaseName);
            var controller = new BillsAndOtherExpencesControllers(dbContext);

          await  controller.CreateExpence(new CreateExpence { ExpenceTitle = "Gardening", ExpencetType = (int)ExpenceTypeEnum.Bill, Price = 100, ClosingChart = 1 });
            await dbContext.SaveChangesAsync();
            var itemToDelete = await dbContext.BillsAndOtherExpences.FirstOrDefaultAsync(e => e.ExpenceTitle == "Gardening");

            await controller.DeleteExpence(itemToDelete.Id);
            await dbContext.SaveChangesAsync();

            var deletedItem = await dbContext.BillsAndOtherExpences.FindAsync(itemToDelete.Id);

            Assert.Null(deletedItem);
        }
    }
}
