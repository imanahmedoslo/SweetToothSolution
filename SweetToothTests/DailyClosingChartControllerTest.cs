using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetTooth.Controllers;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace SweetToothTests
{
    public class DailyClosingChartControllerTest
    {
        private DbContextFactory factory = new DbContextFactory();
        public async  Task<int> getEmployeeId()
        {
            
             var databaseName2 = "CreateEmployee_checkIfResultsCorrect";

            var database2 = factory.CreateDbContext(databaseName2);
            var context2 = new EmployeeControllers(database2);
            CreateEmployee employee = new CreateEmployee
            {
                UserName = "TestUser",
                EmployeeNumber = 123,
                Password = "TestPassword",
                Role = "TestRole",
                MonthlyWage = 1000
            };
            Employee newEmployee = new Employee
            {
                Id = 0,
                UserName = employee.UserName,
                EmployeeNumber = employee.EmployeeNumber,
                Password = employee.Password,
                Role = employee.Role,
                MonthlyWage = employee.MonthlyWage
            };

            // Act
            await context2.CreateEmployee(employee);
            var result = await database2.Employees.FirstOrDefaultAsync(x => x.EmployeeNumber == employee.EmployeeNumber);
            return result.Id;
        }
        public async Task<int>GetBudgetId()
        {
            var databaseName = "CreateEmployee_checkIfResultsCorrect";

            var database = factory.CreateDbContext(databaseName);
            var context = new BudgetControllers(database);
            CreateBudget budget = new CreateBudget
            {
              TotalSum=1000,
              ExpensesBudget=800,
              CharityBudget=100,
              WasteBudget=100,
              DateFrom=DateTime.Now,
              DateTo=DateTime.Now.AddDays(10),
              GoalEarnings=4000,   
    };

            Budget newBudget = new Budget
            {
              TotalSum=budget.TotalSum,
              ExpensesBudget=budget.ExpensesBudget,
              CharityBudget=budget.CharityBudget,
              WasteBudget=budget.WasteBudget,
              DateFrom=budget.DateFrom,
              DateTo=budget.DateTo,
              GoalEarnings=budget.GoalEarnings
            };
            await context.CreateBudget(budget);
            var result = await database.Budgets.FirstOrDefaultAsync(x => x.DateFrom == budget.DateFrom&&x.DateTo==budget.DateTo);
            return result.Id;
        }

        [Fact]
        public async Task GetClosingChartsList_ReturnsListOfDailyClosingCharts()
        {
            // Arrange
            int employeeId = await getEmployeeId();
            int bugetId= await GetBudgetId();
            var databaseName = "CreateEmployee_checkIfResultsCorrect";

            var database = factory.CreateDbContext(databaseName);
            var controller = new DailyClosingChartControllers(database);
            DailyClosingChart chart = new DailyClosingChart
            {
                Date = DateTime.Now,
                TotalCharity = 100,
                TotalEarnings = 1000,
                TotalWaste = 100,
                ClosingReport = "Good",
                TotallBills = 100,
                EmployeeId = employeeId,
                BudgetId = bugetId
            };
            await database.DailyClosingCharts.AddAsync(chart);
            await database.SaveChangesAsync();
            // Act
            var result = await controller.GetClosingChartsList();
            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<DailyClosingChart>>(viewResult.Value);
            Assert.NotNull(model);
        }
        [Fact]
        public async Task GetClosingChartById_ReturnsDailyClosingChart()
        {
            // Arrange
            int employeeId = await getEmployeeId();
            int bugetId= await GetBudgetId();
            var databaseName = "CreateEmployee_checkIfResultsCorrect";

            var database = factory.CreateDbContext(databaseName);
            
            var controller = new DailyClosingChartControllers(database);
            DailyClosingChart chart = new DailyClosingChart
            {
                Date = DateTime.Now,
                TotalCharity = 100,
                TotalEarnings = 1000,
                TotalWaste = 100,
                ClosingReport = "Good",
                TotallBills = 100,
                EmployeeId = employeeId,
                BudgetId = bugetId
            };
            await database.DailyClosingCharts.AddAsync(chart);
            await database.SaveChangesAsync();
            // Act
            var result = await controller.GetClosingChartById(1);
            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<DailyClosingChart>(viewResult.Value);
            Assert.NotNull(model);
        }
        [Fact]
        public async Task CreateClosingChart_ReturnsDailyClosingChart()
        {
            // Arrange
            int employeeId = await getEmployeeId();
            int budgetId = await GetBudgetId();
            var databaseName = "CreateEmployee_checkIfResultsCorrect";

            var database = factory.CreateDbContext(databaseName);
            var controller = new DailyClosingChartControllers(database);
            var dailyClosingChart = new CreateClosingChart
            {
                Date = DateTime.Now,
                TotalCharity = 100,
                TotalEarnings = 1000,
                TotalWaste = 100,
                ClosingReport = "Good",
                TotallBills = 100,
                EmployeeId = employeeId,
                BudgetId = budgetId
            };
            // Act
            var result = await controller.CreateClosingChart(dailyClosingChart);
            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<CreateClosingChart>(viewResult.Value);
            Assert.NotNull(model);
        }
        [Fact]
        public async Task EditClosingChart_ReturnsDailyClosingChart()
        {
            // Arrange
            int employeeId = await getEmployeeId();
            int budgetId = await GetBudgetId();
            var databaseName = "CreateEmployee_checkIfResultsCorrect";

            var database = factory.CreateDbContext(databaseName);
            var controller = new DailyClosingChartControllers(database);

            // Create a chart to edit
            var originalChart = new DailyClosingChart
            {
                Date = DateTime.Now.AddDays(-1), // Use different date for original
                TotalCharity = 50, // Use different value for original
                TotalEarnings = 500, // Use different value for original
                TotalWaste = 50, // Use different value for original
                ClosingReport = "Initial",
                TotallBills = 50,
                EmployeeId = employeeId,
                BudgetId = budgetId
            };
            await database.DailyClosingCharts.AddAsync(originalChart);
            await database.SaveChangesAsync();

            var editChart = new EditClosingChart
            {
                Id = originalChart.Id, // Use the Id of the chart we just added
                Date = DateTime.Now,
                TotalCharity = 100,
                TotalEarnings = 1000,
                TotalWaste = 100,
                ClosingReport = "Good",
                TotallBills = 100,
                EmployeeId = employeeId,
                BudgetId = budgetId
            };

            // Act
            var result = await controller.EditClosingChart(editChart);

            // Assert
            var viewResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<EditClosingChart>(viewResult.Value);
            Assert.NotNull(model);
            // You might also want to assert that the properties were indeed updated.
        }
        [Fact]
        public async Task DeleteClosingChart_ReturnsOkResult()
        {
            // Arrange
            var databaseName = "CreateEmployee_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var controller = new DailyClosingChartControllers(database);

            // Create a chart to delete
            var chartToDelete = new DailyClosingChart
            {
                Date = DateTime.Now,
                TotalCharity = 100,
                TotalEarnings = 1000,
                TotalWaste = 100,
                ClosingReport = "ToBeDeleted",
                TotallBills = 100,
                EmployeeId = await getEmployeeId(),
                BudgetId = await GetBudgetId()
            };
            await database.DailyClosingCharts.AddAsync(chartToDelete);
            await database.SaveChangesAsync();

            // Act
            var result = await controller.DeleteClosingChart(chartToDelete.Id);

            // Assert
            var viewResult = Assert.IsType<OkResult>(result);
            var deletedChart = await database.DailyClosingCharts.FirstOrDefaultAsync(x => x.Id == chartToDelete.Id);
            Assert.Null(deletedChart); // Verify that the chart is indeed deleted
        }




    }
}

