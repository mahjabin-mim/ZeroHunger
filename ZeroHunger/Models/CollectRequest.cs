using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ZeroHunger.Models
{
	public class CollectRequest
	{
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int reqId { get; set; }

        public string foodType { get; set; }

        public string quantity { get; set; }

        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        //[DataType(DataType.Date)]
        //public DateTime reqPosted { get; set; } = DateTime.Now;
        public string reqPosted { get; set; } 

        public string maxPreservationTime { get; set; }

        //[ForeignKey("Employee")]
        public string empUsername { get; set; }

        [ForeignKey("Restaurant")]
        public string restUserName { get; set; }

        //[DefaultValue("Pending")]
        public string reqStarus { get; set; }

        //public Employee Employee { get; set; }
        public Restaurant Restaurant { get; set; }
	}
}

