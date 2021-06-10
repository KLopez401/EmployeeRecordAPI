using System.ComponentModel.DataAnnotations;

namespace EmployeeRecordAPI.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
    }
}
