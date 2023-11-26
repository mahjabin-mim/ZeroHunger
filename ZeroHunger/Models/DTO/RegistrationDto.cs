using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.DTO
{
	public class RegistrationDto
	{
        [Required(ErrorMessage = "Username is required")]
        public string RestUserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        public string RestPassword { get; set; }

        [Required(ErrorMessage = "Name is required")]
        public string RestName { get; set; }

        [Required(ErrorMessage = "Phone is required")]
        public string RestPhone { get; set; }

        [Required(ErrorMessage = "Location is required")]
        public string RestLocation { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string RegistrationDate { get; set; }
    }
}

