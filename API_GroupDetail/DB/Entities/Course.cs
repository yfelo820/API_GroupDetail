using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Entities
{
	public class Course : BaseEntity
	{
		[Required]
		public int Number { get; set; }
	}
}
