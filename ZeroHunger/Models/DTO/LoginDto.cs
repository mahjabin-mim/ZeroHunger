using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.DTO
{
	public class LoginDto
	{	
            [Required(ErrorMessage = "Username is required")]
            public string username { get; set; }

            [Required(ErrorMessage = "Password is required")]
            public string password { get; set; }
	}
}

