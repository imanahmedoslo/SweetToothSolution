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
        public bool Equals(Employee employee)
        {
            return UserName == employee.UserName && EmployeeNumber == employee.EmployeeNumber && Password == employee.Password && Role == employee.Role && MonthlyWage == employee.MonthlyWage;
        }
        public override bool Equals(object? obj)
        {
            if (obj != null)
            {
                return Equals(obj as Employee);

            }
            else
            {
                return false;
            }

        }
        public override int GetHashCode()
        {
            return HashCode.Combine(UserName, EmployeeNumber, Password, Role, MonthlyWage);
        }

    }
}
