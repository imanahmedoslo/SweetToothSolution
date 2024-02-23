using Microsoft.AspNetCore.Mvc;
using Microsoft.Identity.Client;
using SweetTooth.Controllers;
using SweetTooth.Data.Models;
namespace SweetToothTests

{
    public class BudgetControllerTest
    {
        private DbContextFactory factory=new DbContextFactory();
        
        [Fact]
        public async Task CreateBudget_CheckIfValuesAreCorrect()
        {
            const string databaseName = "CreateBudget_CheckIfValuesAreCorrect";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            CreateBudget newBudget = new CreateBudget
            {
                TotalSum = 30000,
                ExpensesBudget = 20000,
                CharityBudget = 5000,
                WasteBudget = 5000,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(10),
                GoalEarnings = 50000
            };
        var result = await budgetController.CreateBudget(newBudget);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Budget>(actionResult.Value);
            var okResult = result as OkObjectResult;
            var budget = okResult?.Value as Budget;
            Assert.Equal(newBudget.TotalSum, budget?.TotalSum);

        }
        [Fact]
        public async Task GetBudgetHistory_CheckIfNotFoundReturned()
        {
            const string databaseName = "GetBudgetHistory_CheckIfNotFoundReturned";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            var result = await budgetController.GetBudgetHistory();
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetBudgetHistory_CheckIfResultCorrect()
        {
        const string databaseName = "GetBudgetHistory_CheckIfValuesAreCorrect";
        using var dbContext = factory.CreateDbContext(databaseName);
        var budgetController = new BudgetControllers(dbContext);
    CreateBudget newBudget = new CreateBudget
    {
            TotalSum = 30000,
            ExpensesBudget = 20000,
            CharityBudget = 5000,
            WasteBudget = 5000,
            DateFrom = DateTime.Now,
            DateTo = DateTime.Now.AddDays(10),
            GoalEarnings = 50000
        };
            var created = await budgetController.CreateBudget(newBudget);
            var result = await budgetController.GetBudgetHistory();
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<List<Budget>>(actionResult.Value);
            var okResult = result as OkObjectResult;
            var budget = okResult?.Value as List<Budget>;
            Assert.Equal(newBudget.TotalSum, budget[0].TotalSum);

        }
        [Fact]
        public async Task GetBudgetById_CheckIfNotFoundReturned()
        {
            const string databaseName = "GetBudgetById_CheckIfNotFoundReturned";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            var result = await budgetController.GetBudgetById(1);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetBudgetById_checkIfResultsAreCorret()
        {
            const string databaseName = "GetBudgetById_CheckIfNotFound";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            CreateBudget newBudget = new CreateBudget
            {
                TotalSum = 30000,
                ExpensesBudget = 20000,
                CharityBudget = 5000,
                WasteBudget = 5000,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(10),
                GoalEarnings = 50000
            };
            var result = await budgetController.CreateBudget(newBudget);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Budget>(actionResult.Value);
            var okResult = result as OkObjectResult;
            var budget = okResult?.Value as Budget;
            var result2 = await budgetController.GetBudgetById(budget.Id);
            var actionResult2 = Assert.IsType<OkObjectResult>(result2);
            var model2 = Assert.IsAssignableFrom<Budget>(actionResult2.Value);
            var okResult2 = result2 as OkObjectResult;
            var budget2 = okResult2?.Value as Budget;
            Assert.Equal(budget, budget2);

        }

        [Fact]
        public async Task GetBudgetByDate_CheckIfNotFound()
        {
            const string databaseName = "GetBudgetByDate_CheckIfValuesAreCorrect";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            var result = await budgetController.GetBudgetByDate(DateTime.Now, DateTime.Now.AddDays(10));
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task GetBudgetByDate_CheckIfValuesAreCorrect()
        {
            const string databaseName = "GetBudgetByDate_CheckIfValuesAreCorrect";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            CreateBudget newBudget = new CreateBudget
            {
                TotalSum = 30000,
                ExpensesBudget = 20000,
                CharityBudget = 5000,
                WasteBudget = 5000,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(10),
                GoalEarnings = 50000
            };
            var result = await budgetController.CreateBudget(newBudget);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Budget>(actionResult.Value);
            var okResult = result as OkObjectResult;
            var budget = okResult?.Value as Budget;
            var result2 = await budgetController.GetBudgetByDate(budget.DateFrom, budget.DateTo);
            var actionResult2 = Assert.IsType<OkObjectResult>(result2);
            var model2 = Assert.IsAssignableFrom<Budget>(actionResult2.Value);
            var okResult2 = result2 as OkObjectResult;
            var budget2 = okResult2?.Value as Budget;
            Assert.Equal(budget, budget2);
        }
        
        [Fact]
        public async Task EditBudget_CheckIfNotFound()
        {
            const string databaseName = "EditBudget_CheckIfValuesAreCorrect";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            EditBudget newBudget = new EditBudget
            {
                Id = 1,
                TotalSum = 30000,
                ExpensesBudget = 20000,
                CharityBudget = 5000,
                WasteBudget = 5000,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(10),
                GoalEarnings = 50000
            };
            var result = await budgetController.EditBudget(newBudget);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task EditBudget_CheckIfValuesAreCorrect()
        {
            const string databaseName = "EditBudget_CheckIfValuesAreCorrect";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            EditBudget newBudget = new EditBudget
            {
                Id = 1,
                TotalSum = 30000,
                ExpensesBudget = 20000,
                CharityBudget = 5000,
                WasteBudget = 5000,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(10),
                GoalEarnings = 50000
            };
            var result = await budgetController.EditBudget(newBudget);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Delete_CheckIfNotFound()
        {
            const string databaseName = "Delete_CheckIfNotFound";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            var result = await budgetController.Delete(1);
            var actionResult = Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task Delete_CheckIfValuesAreCorrect()
        {
            const string databaseName = "Delete_CheckIfValuesAreCorrect";
            using var dbContext = factory.CreateDbContext(databaseName);
            var budgetController = new BudgetControllers(dbContext);
            CreateBudget newBudget = new CreateBudget
            {
                TotalSum = 30000,
                ExpensesBudget = 20000,
                CharityBudget = 5000,
                WasteBudget = 5000,
                DateFrom = DateTime.Now,
                DateTo = DateTime.Now.AddDays(10),
                GoalEarnings = 50000
            };
            var result = await budgetController.CreateBudget(newBudget);
            var actionResult = Assert.IsType<OkObjectResult>(result);
            var model = Assert.IsAssignableFrom<Budget>(actionResult.Value);
            var okResult = result as OkObjectResult;
            var budget = okResult?.Value as Budget;
            var result2 = await budgetController.Delete(budget.Id);
            var actionResult2 = Assert.IsType<OkResult>(result2);
        }


    }
}