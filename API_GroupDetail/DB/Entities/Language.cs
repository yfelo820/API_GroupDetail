using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Entities
{
	public class Language : BaseEntity
	{
		[Required]
		public string Name { get; set; }

		[Required]
		public string Code { get; set; }
	}
}
