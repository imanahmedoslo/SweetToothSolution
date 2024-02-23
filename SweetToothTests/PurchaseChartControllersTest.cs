using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetTooth.Controllers;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace SweetToothTests
{
    public class PurchaseChartControllersTest
    {
        [Fact]
        public async Task CreatePurchaseChart_ckeckIfResultCorrect()
        {
            // Arrange
            var dbContextFactory = new DbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext("CreatePurchaseChart_ckeckIfResultCorrect");
            var purchaseChartController = new PurchaseChartControllers(dbContext);
            var purchaseChart = new CreatePurchaseChart
            {
                TotalPurchasePrice = 1000,
                Report = "purchased the new fall coffee collection",
                Date =DateTime.Now,
                EmployeeId = 0,
                BudgetId = 0
            };
            // Act
            var result = await purchaseChartController.CreatePurchaseChart(purchaseChart);
            // Assert
            var createdResult = Assert.IsType<OkObjectResult>(result);
           
            var model = Assert.IsType<PurchaseChart>(createdResult.Value);
            Assert.Equal(purchaseChart.TotalPurchasePrice, model.TotalPurchasePrice);
        }
        [Fact]
        public async Task GetPurchaseChartList_ckeckIfResultCorrect()
        {
            // Arrange
            var dbContextFactory = new DbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext("GetPurchaseChartList_ckeckIfResultCorrect");
            var purchaseChartController = new PurchaseChartControllers(dbContext);
            var purchaseChart = new CreatePurchaseChart
            {
                TotalPurchasePrice = 1000,
                Report = "purchased the new fall coffee collection",
                Date = DateTime.Now,
                EmployeeId = 0,
                BudgetId = 0
            };
            await purchaseChartController.CreatePurchaseChart(purchaseChart);
            // Act
            var result = await purchaseChartController.GetPurchaseChartList();
            // Assert
            var createdResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<List<PurchaseChart>>(createdResult.Value);
            Assert.Equal(1, model.Count);
        }
        [Fact]
        public async Task GetPurchaseChartById_ckeckIfResultCorrect()
        {
            // Arrange
            var dbContextFactory = new DbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext("GetPurchaseChartById_ckeckIfResultCorrect");
            var purchaseChartController = new PurchaseChartControllers(dbContext);
            var purchaseChart = new CreatePurchaseChart
            {
                TotalPurchasePrice = 1000,
                Report = "purchased the new fall coffee collection",
                Date = DateTime.Now,
                EmployeeId = 0,
                BudgetId = 0
            };
            var result = await purchaseChartController.CreatePurchaseChart(purchaseChart);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<PurchaseChart>(createdResult.Value);
            // Act
            var result2 = await purchaseChartController.GetPurchaseChartById(model.Id);
            // Assert
            var createdResult2 = Assert.IsType<OkObjectResult>(result2);
            var model2 = Assert.IsType<PurchaseChart>(createdResult2.Value);
            Assert.Equal(purchaseChart.TotalPurchasePrice, model2.TotalPurchasePrice);
        }
        [Fact]
        public async Task EditPurchaseChart_ckeckIfResultCorrect()
        {
            // Arrange
            var dbContextFactory = new DbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext("EditPurchaseChart_ckeckIfResultCorrect");
            var purchaseChartController = new PurchaseChartControllers(dbContext);
            var purchaseChart = new CreatePurchaseChart
            {
                TotalPurchasePrice = 1000,
                Report = "purchased the new fall coffee collection",
                Date = DateTime.Now,
                EmployeeId = 0,
                BudgetId = 0
            };
            var result = await purchaseChartController.CreatePurchaseChart(purchaseChart);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<PurchaseChart>(createdResult.Value);
            var editPurchaseChart = new EditPurchaseChart
            {
                Id = model.Id,
                TotalPurchasePrice = 2000,
                Report = "purchased the new fall coffee collection and the new winter collection",
                Date = DateTime.Now,
                EmployeeId = 0,
                BudgetId = 0
            };
            // Act
            var result2 = await purchaseChartController.EditPurchaseChart(editPurchaseChart);
            // Assert
            var createdResult2 = Assert.IsType<OkObjectResult>(result2);
            var model2 = Assert.IsType<PurchaseChart>(createdResult2.Value);
            Assert.Equal(editPurchaseChart.TotalPurchasePrice, model2.TotalPurchasePrice);
        }
        [Fact]
        public async Task DeletePurchaseChart_ckeckIfResultCorrect()
        {
            // Arrange
            var dbContextFactory = new DbContextFactory();
            var dbContext = dbContextFactory.CreateDbContext("DeletePurchaseChart_ckeckIfResultCorrect");
            var purchaseChartController = new PurchaseChartControllers(dbContext);
            var purchaseChart = new CreatePurchaseChart
            {
                TotalPurchasePrice = 1000,
                Report = "purchased the new fall coffee collection",
                Date = DateTime.Now,
                EmployeeId = 0,
                BudgetId = 0
            };
            var result = await purchaseChartController.CreatePurchaseChart(purchaseChart);
            var createdResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsType<PurchaseChart>(createdResult.Value);
            // Act
            var result2 = await purchaseChartController.DeletePurchaseChart(model.Id);
            // Assert
            var deletedResult = Assert.IsType<OkResult>(result2);
           
        }
       
    }
}
