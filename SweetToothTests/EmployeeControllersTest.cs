using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SweetTooth.Controllers;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;

namespace SweetToothTests
{
    public class EmployeeControllersTest
    {
        private DbContextFactory factory = new DbContextFactory();

        [Fact]
        public async Task CreateEmployee_checkIfResultsCorrect()
        {
            var databaseName = "CreateEmployee_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new EmployeeControllers(database);
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
            await context.CreateEmployee(employee);
            var result = await database.Employees.FirstOrDefaultAsync(x => x.EmployeeNumber == employee.EmployeeNumber);

            // Assert
            Assert.Equal(newEmployee, result);
        }
        [Fact]
        public async Task GetEmployeeByEmployeeNumber_checkIfResultsCorrect()
        {
            var databaseName = "GetEmployeeByEmployeeNumber_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new EmployeeControllers(database);
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
            await database.Employees.AddAsync(newEmployee);
            await database.SaveChangesAsync();

            // Act
            var result = await context.GetEmployeeByEmployeeNumber(employee.EmployeeNumber);
            Assert.IsType<OkObjectResult>(result);
            var employeeObject= (result as OkObjectResult).Value as Employee;

            // Assert
            Assert.Equal(newEmployee, employeeObject);
        }
        [Fact]
        public async Task GetEmployeeById_checkIfResultsCorrect()
        {
            var databaseName = "GetEmployeeById_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new EmployeeControllers(database);
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
            await database.Employees.AddAsync(newEmployee);
            await database.SaveChangesAsync();

            // Act
            var result = await context.GetEmployeeById(newEmployee.Id);
            Assert.IsType<OkObjectResult>(result);
            var employeeObject = (result as OkObjectResult).Value as Employee;
            Assert.Equal(newEmployee, employeeObject);
        }
        [Fact]
        public async Task GetEmployees_checkIfResultsCorrect()
        {
            var databaseName = "GetEmployees_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new EmployeeControllers(database);
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
            List<Employee> Allemployees = new List<Employee> { newEmployee };
            await database.Employees.AddAsync(newEmployee);
            await database.SaveChangesAsync();

            // Act
            var result = await context.GetEmployees();
            Assert.IsType<OkObjectResult>(result);
            var employees = (result as OkObjectResult).Value as List<Employee>;

            // Assert
            Assert.Equal(Allemployees, employees);
        }
        [Fact]
        public async Task EditEmployee_checkIfResultsCorrect()
        {
            var databaseName = "EditEmployee_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new EmployeeControllers(database);
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
            await database.Employees.AddAsync(newEmployee);
            await database.SaveChangesAsync();
            EditEmployee editEmployee = new EditEmployee
            {
                Id = newEmployee.Id,
                UserName = "EditedTestUser",
                EmployeeNumber = 321,
                Password = "EditedTestPassword",
                Role = "EditedTestRole",
                MonthlyWage = 2000
            };
            Employee editedEmployee = new Employee
            {
                Id = newEmployee.Id,
                UserName = editEmployee.UserName,
                EmployeeNumber = editEmployee.EmployeeNumber,
                Password = editEmployee.Password,
                Role = editEmployee.Role,
                MonthlyWage = editEmployee.MonthlyWage
            };

            // Act
            await context.EditEmployee(editEmployee);
            var result = await database.Employees.FirstOrDefaultAsync(x => x.Id == editEmployee.Id);

            // Assert
           Assert.Equal(editedEmployee, result);
        }
        [Fact]
        public async Task EditEmployee_checkIfNotFound()
        {
            var databaseName = "EditEmployee_checkIfNotFound";
            var database = factory.CreateDbContext(databaseName);
            var context = new EmployeeControllers(database);
            EditEmployee editEmployee = new EditEmployee
            {
                Id = 1,
                UserName = "EditedTestUser",
                EmployeeNumber = 321,
                Password = "EditedTestPassword",
                Role = "EditedTestRole",
                MonthlyWage = 2000
            };

            // Act
            var result = await context.EditEmployee(editEmployee);

            // Assert
            Assert.IsType<NotFoundResult>(result);
        }
        [Fact]
        public async Task DeleteEmployee_CheckIfResultCorrect()
        {
           
            var databaseName = "DeleteEmployee_CheckIfResultCorrect";
                       var database = factory.CreateDbContext(databaseName);
                       var context = new EmployeeControllers(database);
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
                       await database.Employees.AddAsync(newEmployee);
                       await database.SaveChangesAsync();
            
                      
                     var result = await context.DeleteEmployee(newEmployee.Id);
                     var Deletedemployee = await database.Employees.FirstOrDefaultAsync(x => x.Id == newEmployee.Id);
                     Assert.IsType<OkObjectResult>(result);
                     Assert.Null(Deletedemployee);

        }
    }
}
