using Alqotr.EmpRegister.Validation;
using System.ComponentModel.DataAnnotations;

namespace Alqotr.EmpRegister.DAL
{
    public class Employee
    {
        [Key]
        public int EmployeeId { get; set; }

        [Required(ErrorMessage = "Employee Name is required")]
        [StringLength(100, ErrorMessage = "Employee Name cannot exceed 100 characters")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Job Number is required")]
        [StringLength(50, ErrorMessage = "Job Number cannot exceed 50 characters")]
        public string JobNumber { get; set; }

        [Required(ErrorMessage = "Mobile Number is required")]
        [Phone(ErrorMessage = "Invalid phone number format")]
        public string MobileNumber { get; set; }

        [Required(ErrorMessage = "Address is required")]
        [StringLength(250, ErrorMessage = "Address cannot exceed 250 characters")]
        public string Address { get; set; }

        public string Notes { get; set; }   

        // Navigation Property for LeaveApplications
        public ICollection<LeaveApplication> LeaveApplications { get; set; }
    }

    public class VacationType
    {
        public int VacationTypeId { get; set; }

        [Required(ErrorMessage = "Vacation Type Name is required")]
        [StringLength(100, ErrorMessage = "Vacation Type Name cannot exceed 100 characters")]
        public string TypeName { get; set; }
    }

    public class LeaveApplication
    {
        [Key]
        public int LeaveApplicationId { get; set; }

        [Required(ErrorMessage = "Employee is required")]
        public int EmployeeId { get; set; }
        public Employee Employee { get; set; }

        [Required(ErrorMessage = "Vacation Type is required")]
        public int VacationTypeId { get; set; }
        public VacationType VacationType { get; set; }

        [Required(ErrorMessage = "Reason is required")]
        [StringLength(500, ErrorMessage = "Reason cannot exceed 500 characters")]
        public string Reason { get; set; }

        [Required(ErrorMessage = "From Date is required")]
        [DataType(DataType.Date)]
        public DateTime FromDate { get; set; }

        [Required(ErrorMessage = "To Date is required")]
        [DataType(DataType.Date)]
        [DateGreaterThan("FromDate", ErrorMessage = "To Date must be greater than From Date")]
        public DateTime ToDate { get; set; }

        public string Notes { get; set; }
    }
    public class EmployeeLeaveReport
    {
        public string EmployeeName { get; set; }
        public string JobNumber { get; set; }
        public string MobileNumber { get; set; }
        public int LeaveCount { get; set; }
        public DateTime LastLeaveDate { get; set; } = DateTime.MinValue;
        public string OtherLeaveTypes { get; set; }
    }

}
