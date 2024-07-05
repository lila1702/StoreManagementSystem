using System.ComponentModel.DataAnnotations;
using WebAPI_StoreManagement.Enums;

namespace WebAPI_StoreManagement.Models
{
    public class StaffModel
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DepartmentEnum Department { get; set; }
        public bool Active { get; set; }
        public ShiftsEnum Shift { get; set; }
        public DateTime CreationDate { get; set; } = DateTime.UtcNow;
        public DateTime ModificationDate { get; set; } = DateTime.UtcNow;
    }
}
