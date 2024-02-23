using SweetTooth.Data.Models.Enums;

namespace SweetTooth.Data.Models
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
        public List<string> Allergies { get; set; } = new List<string>();
        public int EmployeeId { get; set; }


        public virtual Employee? Employee { get; set; }
   
        public bool Equals(StaffMembersInfo staffMembersInfo)
        {
            return FullName == staffMembersInfo.FullName &&
                 Address == staffMembersInfo.Address && 
                PhoneNumber == staffMembersInfo.PhoneNumber
                && Email == staffMembersInfo.Email&&
                Gender == staffMembersInfo.Gender&& 
                Age == staffMembersInfo.Age&& 
                EmergencyContact == staffMembersInfo.EmergencyContact
                && TypeOfEmployment == staffMembersInfo.TypeOfEmployment
                && Allergies.SequenceEqual(staffMembersInfo.Allergies);

        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as StaffMembersInfo);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(FullName, Address, PhoneNumber, Email);
        }
    
    }

}