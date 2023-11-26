using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models.DTO
{
	public class AddRequestDto
	{
        [Required(ErrorMessage = "Food type is required")]
        public string foodType { get; set; }

        [Required(ErrorMessage = "Quantity is required")]
        public string quantity { get; set; }

        [Required(ErrorMessage = "Date is required")]
        public string reqPosted { get; set; }

        [Required(ErrorMessage = "Max preservation time is required")]
        public string maxPreservationTime { get; set; }

        //public string empUsername { get; set; }

        //public string restUserName { get; set; }
        //public bool ReqStarus { get; set; }

    }
}

