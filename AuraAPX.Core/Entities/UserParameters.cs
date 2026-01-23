using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Entities
{
	public class UserParameters
	{
		public Guid Id { get; set; }
		public string? Gender { get; set; }
		public int Height { get; set; }
		public int Weight { get; set; }
		public Guid UserId { get; set; }
		public User? User { get; set; }
	}
}
