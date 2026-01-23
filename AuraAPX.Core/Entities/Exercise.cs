using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace AuraAPX.Core.Entities
{
	public class Exercise
	{
		public Guid Id { get; set; }
		public string? Title { get; set; }
		public string? Description { get; set; }
		public Guid WorkoutId { get; set; }
		public Workout? Workout { get; set; }
		public List<Set> Sets { get; set; } = new();
	}
}
