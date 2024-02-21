using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SweetTooth.Data;
using SweetTooth.Data.Models;
using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StaffMembersInfoControllers : ControllerBase
    {
        private readonly SweetToothDbContext _context;
        public StaffMembersInfoControllers(SweetToothDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> GetStaffMembersInfo()
        {
            var staffMembersInfo = await _context.StaffMembersInfos.ToListAsync();
            if (staffMembersInfo.Count == 0)
            {
                return NotFound();
            }
            return Ok(staffMembersInfo);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetStaffMembersInfoById(int id)
        {
            var staffMembersInfo = await _context.StaffMembersInfos.FirstOrDefaultAsync(x => x.Id == id);
            if (staffMembersInfo == null)
            {
                return NotFound();
            }
            return Ok(staffMembersInfo);
        }
        [HttpGet("EmployeeNumber")]
        public async Task<IActionResult> GetStaffMembersInfoByEmployeeNumber(int employeeNumber)
        {
            var staffMembersInfo = await _context.Employees.Where(x=>x.EmployeeNumber== employeeNumber).Include(x=>x.StaffMembersInfo).FirstOrDefaultAsync();
            if (staffMembersInfo == null)
            {
                return NotFound();
            }
            return Ok(staffMembersInfo);
        }
        [HttpPost]
        public async Task<IActionResult> CreateStaffMembersInfo([FromBody] CreateStaffMembersInfo staffMembersInfo)
        {
            StaffMembersInfo newInfo = new StaffMembersInfo
            {
                FullName = staffMembersInfo.FullName,
                Address = staffMembersInfo.Address,
                PhoneNumber = staffMembersInfo.PhoneNumber,
                Email = staffMembersInfo.Email,
                Gender=(GenderEnum)staffMembersInfo.Gender,
                Age=staffMembersInfo.Age,
                EmergencyContact=staffMembersInfo.EmergencyContact,
                TypeOfEmployment=(TypeOfEmploymentEnum)staffMembersInfo.TypeOfEmployment,



            };
          Employee? employee=  await _context.Employees.FirstOrDefaultAsync(x => x.Id == staffMembersInfo.EmployeeId);
            if (employee == null)
            {
                return NotFound();
            }
            employee.StaffMembersInfo = newInfo;
            await _context.SaveChangesAsync();
            return Ok(staffMembersInfo);
        }
        [HttpPut]
        public async Task<IActionResult> EditStaffMembersInfo([FromBody] EditStaffMembersInfo staffMembersInfo)
        {
            var staffMembersInfoToUpdate = await _context.StaffMembersInfos.Where(x => x.EmployeeId == staffMembersInfo.EmployeeId).FirstOrDefaultAsync();
            if (staffMembersInfoToUpdate == null)
            {
                return NotFound();
            }
            staffMembersInfoToUpdate.FullName = staffMembersInfo.FullName;
            staffMembersInfoToUpdate.Address = staffMembersInfo.Address;
            staffMembersInfoToUpdate.PhoneNumber = staffMembersInfo.PhoneNumber;
            staffMembersInfoToUpdate.Email = staffMembersInfo.Email;
            staffMembersInfoToUpdate.Address = staffMembersInfo.Address;
            staffMembersInfoToUpdate.Gender = (GenderEnum)staffMembersInfo.Gender;
            staffMembersInfoToUpdate.Allergies = staffMembersInfo.Allergies;
            staffMembersInfoToUpdate.EmergencyContact = staffMembersInfo.EmergencyContact;
            staffMembersInfoToUpdate.Age = staffMembersInfo.Age;
            staffMembersInfoToUpdate.TypeOfEmployment = (TypeOfEmploymentEnum)staffMembersInfo.TypeOfEmployment;
            await _context.SaveChangesAsync();
            return Ok(staffMembersInfoToUpdate);

        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStaffMembersInfo(int id)
        {
            var staffMembersInfo = await _context.StaffMembersInfos.FirstOrDefaultAsync(x => x.Id == id);
            if (staffMembersInfo == null)
            {
                return NotFound();
            }
            _context.StaffMembersInfos.Remove(staffMembersInfo);
            await _context.SaveChangesAsync();
            return Ok();
        }
    }
}

public class CreateStaffMembersInfo
{

    public int EmployeeId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Gender { get; set; }
    public int Age { get; set; }
    public string EmergencyContact { get; set; } = string.Empty;
    public int TypeOfEmployment { get; set; }
    public List<string> Allergies { get; set; } = new List<string>();
}
public class EditStaffMembersInfo
{
    public int EmployeeId { get; set; }
    public string FullName { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int Gender { get; set; }
    public int Age { get; set; }
    public string EmergencyContact { get; set; } = string.Empty;
    public int TypeOfEmployment { get; set; }
    public List<string> Allergies { get; set; } = new List<string>();


}