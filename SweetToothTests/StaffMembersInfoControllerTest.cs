using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.Resources;
using SweetTooth.Controllers;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SweetToothTests
{
    public class StaffMembersInfoControllerTest
    {

        private DbContextFactory factory = new DbContextFactory();

        [Fact]
        public async Task CreateStaffMemberInfo_checkIfResultsCorrect()
        {
            var databaseName = "CreateStaffMemberInfo_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new StaffMembersInfoControllers(database);
            var context2= new EmployeeControllers(database);
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
            int empId= await database.Employees.Where(x => x.UserName == employee.UserName).Select(x => x.Id).FirstOrDefaultAsync();

            CreateStaffMembersInfo info = new CreateStaffMembersInfo
            {
                EmployeeId= empId,
                FullName = "testName",
                Address = "testAddress",
                PhoneNumber = "testNumber",
                Email = "testEmail",
                Gender = (int)GenderEnum.Female,
                Age = 20,
                EmergencyContact = "testContact",
                TypeOfEmployment = (int)TypeOfEmploymentEnum.FullTime,
                Allergies=new List<string>(),
            };
            StaffMembersInfo newInfo = new StaffMembersInfo
            {
                Id=0,
                FullName = info.FullName,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber,
                Email = info.Email,
                Gender = (GenderEnum)info.Gender,
                Age = info.Age,
                EmergencyContact = info.EmergencyContact,
                TypeOfEmployment = (TypeOfEmploymentEnum)info.TypeOfEmployment,
                EmployeeId= empId,
                Allergies=info.Allergies
            };

            // Act
            await context.CreateStaffMembersInfo(info);
            var result = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == info.Email);

            // Assert
            Assert.Equal(newInfo, result);
        }
        [Fact]
        public async Task EditStaffMemberInfo_checkIfResultsCorrect()
        {
            var databaseName = "EditStaffMemberInfo_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new StaffMembersInfoControllers(database);
            var context2 = new EmployeeControllers(database);
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
            await context2.CreateEmployee(employee);
            int empId = await database.Employees.Where(x => x.UserName == employee.UserName).Select(x => x.Id).FirstOrDefaultAsync();
            CreateStaffMembersInfo info = new CreateStaffMembersInfo
            {
                EmployeeId= empId,
                FullName = "testName",
                Address = "testAddress",
                PhoneNumber = "testNumber",
                Email = "testEmail",
                Gender = (int)GenderEnum.Female,
                Age = 20,
                EmergencyContact = "testContact",
                TypeOfEmployment = (int)TypeOfEmploymentEnum.FullTime,
                Allergies=new List<string>(),
            };

            // Act
           

            StaffMembersInfo newInfo = new StaffMembersInfo
            {
                Id = 0,
                FullName = info.FullName,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber,
                Email = info.Email,
                Gender = (GenderEnum)info.Gender,
                Age = info.Age,
                EmergencyContact = info.EmergencyContact,
                TypeOfEmployment = (TypeOfEmploymentEnum)info.TypeOfEmployment,
                EmployeeId = empId,
                Allergies = info.Allergies
            };
            await context.CreateStaffMembersInfo(info);
            var result = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == info.Email);
            EditStaffMembersInfo editInfo = new EditStaffMembersInfo
            {
                EmployeeId = empId,
                FullName = "testName2",
                Address = "testAddress2",
                PhoneNumber = "testNumber2",
                Email = "testEmail2",
                Gender = (int)GenderEnum.Male,
                Age = 30,
                EmergencyContact = "testContact2",
                TypeOfEmployment = (int)TypeOfEmploymentEnum.PartTime,
                Allergies = new List<string>()
            };
            StaffMembersInfo newInfo2 = new StaffMembersInfo
            {
                Id = 0,
                FullName = editInfo.FullName,
                Address = editInfo.Address,
                PhoneNumber = editInfo.PhoneNumber,
                Email = editInfo.Email,
                Gender = (GenderEnum)editInfo.Gender,
                Age = editInfo.Age,
                EmergencyContact = editInfo.EmergencyContact,
                TypeOfEmployment = (TypeOfEmploymentEnum)editInfo.TypeOfEmployment,
                EmployeeId = empId,
                Allergies = editInfo.Allergies
            };
            await context.EditStaffMembersInfo(editInfo);
            var result2 = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == editInfo.Email);
            Assert.NotNull(result2);
            Assert.Equal(newInfo2, result2);
}
        [Fact]
        public async Task DeleteStaffMemberInfo_checkIfResultsCorrect()
        {
            var databaseName = "DeleteStaffMemberInfo_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new StaffMembersInfoControllers(database);
            var context2 = new EmployeeControllers(database);
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
            await context2.CreateEmployee(employee);
            int empId = await database.Employees.Where(x => x.UserName == employee.UserName).Select(x => x.Id).FirstOrDefaultAsync();
            CreateStaffMembersInfo info = new CreateStaffMembersInfo
            {
                EmployeeId = empId,
                FullName = "testName",
                Address = "testAddress",
                PhoneNumber = "testNumber",
                Email = "testEmail",
                Gender = (int)GenderEnum.Male,
                Age = 20,
                EmergencyContact = "testContact",
                TypeOfEmployment = (int)TypeOfEmploymentEnum.FullTime,
                Allergies = new List<string>(),
            };
            StaffMembersInfo newInfo = new StaffMembersInfo
            {
                Id = 0,
                FullName = info.FullName,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber,
                Email = info.Email,
                Gender = (GenderEnum)info.Gender,
                Age = 20,
                EmergencyContact = info.EmergencyContact,
                TypeOfEmployment = (TypeOfEmploymentEnum)info.TypeOfEmployment,
                EmployeeId = empId,
                Allergies = info.Allergies
            };
            await context.CreateStaffMembersInfo(info);
            var result = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == info.Email);
            Assert.NotNull(result);
            await context.DeleteStaffMembersInfo(result.Id);
            var result2 = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == info.Email);
            Assert.Null(result2);
        }
        [Fact]
        public async Task GetStaffMemberInfo_checkIfResultsCorrect()
        {
            var databaseName = "GetStaffMemberInfo_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new StaffMembersInfoControllers(database);
            var context2 = new EmployeeControllers(database);
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
            await context2.CreateEmployee(employee);
            int empId = await database.Employees.Where(x => x.UserName == employee.UserName).Select(x => x.Id).FirstOrDefaultAsync();
            CreateStaffMembersInfo info = new CreateStaffMembersInfo
            {
                EmployeeId = empId,
                FullName = "testName",
                Address = "testAddress",
                PhoneNumber = "testNumber",
                Email = "testEmail",
                Gender = (int)GenderEnum.Female,
                Age = 20,
                EmergencyContact = "testContact",
                TypeOfEmployment = (int)TypeOfEmploymentEnum.FullTime,
                Allergies = new List<string>(),
            };
            StaffMembersInfo newInfo = new StaffMembersInfo
            {
                Id = 0,
                FullName = info.FullName,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber,
                Email = info.Email,
                Gender = (GenderEnum)info.Gender,
                Age = info.Age,
                EmergencyContact = info.EmergencyContact,
                TypeOfEmployment = (TypeOfEmploymentEnum)info.TypeOfEmployment,
                EmployeeId = empId,
                Allergies = info.Allergies
            };
            await context.CreateStaffMembersInfo(info);
            var result = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == info.Email);
            Assert.NotNull(result);
            var result2 = await context.GetStaffMembersInfo();
            var okResult = result2 as OkObjectResult;
            List<StaffMembersInfo> resultlist = okResult.Value as List<StaffMembersInfo>;

            List<StaffMembersInfo> list = new List<StaffMembersInfo>();
            list.Add(newInfo);
            Assert.NotNull(result2);

            Assert.Equal(list, resultlist);
        }
        [Fact]
        public async Task GetStaffMemberInfoById_checkIfResultsCorrect()
        {
            var databaseName = "GetStaffMemberInfoById_checkIfResultsCorrect";
            var database = factory.CreateDbContext(databaseName);
            var context = new StaffMembersInfoControllers(database);
            var context2 = new EmployeeControllers(database);
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
            await context2.CreateEmployee(employee);
            int empId = await database.Employees.Where(x => x.UserName == employee.UserName).Select(x => x.Id).FirstOrDefaultAsync();
            CreateStaffMembersInfo info = new CreateStaffMembersInfo
            {
                EmployeeId = empId,
                FullName = "testName",
                Address = "testAddress",
                PhoneNumber = "testNumber",
                Email = "testEmail",
                Gender = (int)GenderEnum.Female,
                Age = 20,
                EmergencyContact = "testContact",
                TypeOfEmployment = (int)TypeOfEmploymentEnum.FullTime,
                Allergies = new List<string>(),
            };
            StaffMembersInfo newInfo = new StaffMembersInfo
            {
                Id = 0,
                FullName = info.FullName,
                Address = info.Address,
                PhoneNumber = info.PhoneNumber,
                Email = info.Email,
                Gender = (GenderEnum)info.Gender,
                Age = info.Age,
                EmergencyContact = info.EmergencyContact,
                TypeOfEmployment = (TypeOfEmploymentEnum)info.TypeOfEmployment,
                EmployeeId = empId,
                Allergies = info.Allergies
            };
            await context.CreateStaffMembersInfo(info);
            var result = await database.StaffMembersInfos.FirstOrDefaultAsync(x => x.Email == info.Email);
            Assert.NotNull(result);
            var result2 = await context.GetStaffMembersInfoById(result.Id);
            var okResult = result2 as OkObjectResult;
            StaffMembersInfo resultInfo = okResult.Value as StaffMembersInfo;
            Assert.NotNull(result2);
            Assert.Equal(newInfo, resultInfo);
        }

    }
   


    }
