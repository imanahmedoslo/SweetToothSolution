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
        public async Task<IActionResult> CreateStaffMembersInfo([FromBody] StaffMembersInfo staffMembersInfo)
        {
            await _context.Employees.FirstOrDefaultAsync(x => x.Id == staffMembersInfo.EmployeeId);
            await _context.SaveChangesAsync();
            return Ok(staffMembersInfo);
        }
        [HttpPut]
        public async Task<IActionResult> EditStaffMembersInfo([FromBody] StaffMembersInfo staffMembersInfo)
        {
            var staffMembersInfoToUpdate = await _context.StaffMembersInfos.Where(x => x.Id == staffMembersInfo.Id).FirstOrDefaultAsync();
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
            await _context.SaveChangesAsync();
            return Ok(staffMembersInfoToUpdate);

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
    public TypeOfEmploymentEnum TypeOfEmployment { get; set; }
    public List<string> Allergies { get; set; } = new List<string>();


}