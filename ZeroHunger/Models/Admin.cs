using System;
using System.ComponentModel.DataAnnotations;

namespace ZeroHunger.Models
{
	public class Admin
	{
		[Key]
        //public int adminId { get; set; }
        public string adminUsername { get; set; }
		public string adminPassword { get; set; }
        public string adminPhone { get; set; }
	}
}

