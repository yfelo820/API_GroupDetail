using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API_GroupDetail.DB.Entities
{
	public class Subject : BaseEntity
	{
		public string Name { get; set; }
		public int SessionCount { get; set; }
		public int DifficultyCount { get; set; }
		public string Key { get; set; }
	}
}
