using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.DTO
{
	public class ApplicantsDto
	{
        [Required(ErrorMessage = "Email is required")]
        public string email { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string appName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string appPhone { get; set; }

        [Required(ErrorMessage = "Address is required")]
        public string appAddress { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public string applyDate { get; set; } = DateTime.Now;
        [Required(ErrorMessage = "Date is required")]
        public string applyDate { get; set; }
    }
}

