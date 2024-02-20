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
        public async Task<IActionResult> CreateEmployee([FromBody] Employee employee)
        {
            await _context.Employees.AddAsync(employee);
            await _context.SaveChangesAsync();
            return Ok(employee);
        }
        [HttpPut]
        public async Task<IActionResult> EditEmployee([FromBody] Employee employee)
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
