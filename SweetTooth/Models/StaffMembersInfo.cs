using SweetTooth.Models.Enums;

namespace SweetTooth.Models
{
    public class StaffMembersInfo
    {
        public int Id { get; set; }
        public string FullName { get; set; } = string.Empty;    
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public GenderEnum Gender { get; set; } 
        public int Age { get; set; }
        public string EmergencyContact { get; set; } = string.Empty;
        public TypeOfEmploymentEnum TypeOfEmployment { get; set; } 
        public List <string> Allergies { get; set; } = new List<string>();
        public int EmployeeId { get; set; }

       
        public virtual Employee? Employee { get; set; }
    }
}