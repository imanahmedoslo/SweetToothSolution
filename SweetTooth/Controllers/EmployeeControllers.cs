using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeControllers:ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public EmployeeControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetEmployees()
        {
            var employees = await _context.Employees.ToListAsync();
            if (employees.Count == 0)
            {
                return NotFound();
            }
            return Ok(employees);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetEmployeeById(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpGet("EmployeeNumber")]
        public async Task<IActionResult> GetEmployeeByEmployeeNumber(int employeeNumber)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.EmployeeNumber == employeeNumber);
            if (employee == null)
            {
                return NotFound();
            }
            return Ok(employee);
        }
        [HttpPost]
        public async Task<IActionResult> CreateEmployee([FromBody] CreateEmployee employee)
        {
            Employee newEmployee = new Employee
            {
                UserName = employee.UserName,
                EmployeeNumber = employee.EmployeeNumber,
                Password = employee.Password,
                Role = employee.Role,
                MonthlyWage = employee.MonthlyWage
            };
            await _context.Employees.AddAsync(newEmployee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> EditEmployee([FromBody] EditEmployee employee)
        {
            var employeeToUpdate = await _context.Employees.Where(x => x.Id == employee.Id).FirstOrDefaultAsync();
            if (employeeToUpdate == null)
            {
                return NotFound();
            }
            employeeToUpdate.EmployeeNumber = employee.EmployeeNumber;
            employeeToUpdate.UserName = employee.UserName;
            employeeToUpdate.Password = employee.Password;
            employeeToUpdate.Role = employee.Role;
            employeeToUpdate.MonthlyWage = employee.MonthlyWage;
            await _context.SaveChangesAsync();
            return Ok(employeeToUpdate);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployee(int id)
        {
            var employee = await _context.Employees.FirstOrDefaultAsync(x => x.Id == id);
            if (employee == null)
            {
                return NotFound();
            }
            _context.Employees.Remove(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }


    }
}
public class CreateEmployee
{
    public int EmployeeNumber { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; }=string.Empty;
    public string Role { get; set; }= string.Empty;
    public int MonthlyWage { get; set; }
}
public class EditEmployee
{
    public int Id { get; set; }
    public int EmployeeNumber { get; set; }
    public string UserName { get; set; } = string.Empty;
    public string Password { get; set; } = string.Empty;
    public string Role { get; set; } = string.Empty;
    public int MonthlyWage { get; set; }
}

