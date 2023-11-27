using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.DTO
{
	public class EmployeeDto
	{
        [Required(ErrorMessage = "Email is required")]
        public string empUserName { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string empPassword { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string empName { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string empPhone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string empAddress { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public string applyDate { get; set; } = DateTime.Now;
        //[Required(ErrorMessage = "Date is required")]
        //public string joinningDate { get; set; }

        //[Required(ErrorMessage = "Date is required")]
        //public string completedReq { get; set; }
    }
}

