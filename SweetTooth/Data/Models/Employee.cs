namespace SweetTooth.Data.Models
{
    public class Employee
    {
        public int Id { get; set; }
        public string UserName { get; set; } = string.Empty;
        public int EmployeeNumber { get; set; }
        public string Password { get; set; } = string.Empty;
        public string Role { get; set; } = string.Empty;
        public int MonthlyWage { get; set; }

        // Navigation properties
        public StaffMembersInfo? StaffMembersInfo { get; set; }
        public ICollection<DailyClosingChart>? DailyClosingChart { get; set; }
        public ICollection<PurchaseChart>? PurchaseChart { get; set; }
        public Employee(string userName, int employeeNumber, string password, string role, int monthlyWage)
        {

            UserName = userName;
            EmployeeNumber = employeeNumber;
            Password = password;
            Role = role;
            MonthlyWage = monthlyWage;

        }
        public Employee()
        {

        }
    }
}
