using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.DataAccessLayer.Entities.Core;

namespace Data.DataAccessLayer.Entities
{
    public class Employee : IEntity
    {
        [Key]
        public int EmployeeID { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]
        public string EmployeeLastName { get; set; }
        [Column(TypeName = "nvarchar(50)")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(50, ErrorMessage = "Maximum 50 characters only")]

        public string EmployeeFirstName { get; set; }
        [Column(TypeName = "nvarchar(30)")]
        [Required(ErrorMessage = "This Field is required.")]
        [DataType(DataType.PhoneNumber)]
        [RegularExpression(@"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$", ErrorMessage = "Entered phone format is not valid.")]

        public string EmployeePhone { get; set; }

        [Column(TypeName = "nvarchar(11)")]
        [Required(ErrorMessage = "This Field is required.")]
        [MaxLength(11, ErrorMessage = "Maximum 11 characters only")]
        public string EmployeeZip { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime Date { get; set; }

        [DisplayFormat(DataFormatString = "{0:MM/dd/yyyy}")]
        [DataType(DataType.Date)]
        public DateTime HireDate { get; set; }
    }
}
