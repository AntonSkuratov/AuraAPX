using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Entities
{
	public class User
	{
		public Guid Id { get; set; }
		public string? Name { get; set; }
		public string? Surname { get; set; }
		public string? Email { get; set; }	
		public DateTime DateBirth { get; set; }
		public UserParameters? UserParameters { get; set; }
		public LocalLogin? LocalLogin { get; set; }
		public List<Workout> Workouts { get; set; } = new();
	}
}
