using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Entities
{
	public class LocalLogin
	{
		public Guid Id { get; set; }
		public string? Login { get; set; }
		public string? PasswordHash { get; set; }
		public string? Salt { get; set; }
		public int UserId { get; set; }
		public User? User { get; set; }
	}
}
