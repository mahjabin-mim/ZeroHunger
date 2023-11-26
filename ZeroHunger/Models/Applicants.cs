using System;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace ZeroHunger.Models
{
	public class Applicants
	{
        [Key]
        //public int applicantId { get; set; }
        //[Index(IsUnique = true)]
        [Required]
        [EmailAddress]
        public string email { get; set; }

        public string appName { get; set; }

        public string appPhone { get; set; }

        public string appAddress { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public string applyDate { get; set; } = DateTime.Now;
        public string applyDate { get; set; }

        public bool appStatus { get; set; }

        //public Employee Employee { get; set; } 
	}
}

