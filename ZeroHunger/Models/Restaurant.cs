using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZeroHunger.Models
{
	public class Restaurant
	{
        [Key]
        //public int restId { get; set; }
        [Required]
        //[Index(IsUnique = true)]
        public string restUserName { get; set; }

        public string restPassword { get; set; }

        public string restName { get; set; }

        public string restPhone { get; set; }

        public string restLocation { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime registratineDate { get; set; } = DateTime.Now;
        public string registratineDate { get; set; }

        public ICollection<CollectRequest> CollectRequest { get; set; }
	}
}

