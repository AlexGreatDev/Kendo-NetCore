using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Core.Common.DTOs.Employee
{
    public class EmployeeDto 
    {
        public int EmployeeID { get; set; }

      
        [DisplayName("Last Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]
        public string EmployeeLastName { get; set; }

        
        [DisplayName("First Name")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]

        public string EmployeeFirstName { get; set; }

        
        [DisplayName("Employee Phone")]
        [Required(ErrorMessage = "This Field is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        public string EmployeePhone { get; set; }

        
        [DisplayName("EmployeeZip")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters only")]
        public string EmployeeZip { get; set; }


        [DisplayName("Create Date")]
        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        [DisplayName("Hire Date")]
        public DateTime HireDate { get; set; }
    }
}
