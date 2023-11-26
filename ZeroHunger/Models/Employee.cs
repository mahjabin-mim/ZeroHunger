using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace ZeroHunger.Models
{
	public class Employee
	{
        [Key]
        //public int empId { get; set; }
        //[Index(IsUnique = true)]
        [Required]
        public string empUserName { get; set; }

        public string empPassword { get; set; }

        public string empName { get; set; }

        //[ForeignKey("Applicants")]
        public string email { get; set; }

        public string empPhone { get; set; }

        public string empAddress { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime joinningDate { get; set; } = DateTime.Now;
        public string joinningDate { get; set; }

        public int completedReq { get; set; }

        //public Applicants Applicants { get; set; }

        //public ICollection<CollectRequest> CollectRequest { get; set; }
	}
}

