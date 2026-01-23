using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Entities
{
	public class Workout
	{
		public Guid Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public DateTime StartTime { get; set; }
		public DateTime EndTime { get; set; }
		public Guid UserId { get; set; }
		public User? User { get; set; }
		public List<Exercise> Exercises { get; set; } = new();
	}
}
