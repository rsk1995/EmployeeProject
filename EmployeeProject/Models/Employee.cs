using System.ComponentModel.DataAnnotations;

namespace EmployeeProject.Models
{
    public class Employee
    {
        [Key]
        public int EmpID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Project { get; set; }
        public string Designation { get; set; }
        public string Email { get; set; }

    }
}
