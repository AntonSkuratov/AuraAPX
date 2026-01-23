using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Entities
{
	public class Set
	{
		public Guid Id { get; set; }
		public int Number { get; set; }
		public int NumberRepetitions {  get; set; }
		public double WorkingWeightOrResistance { get; set; }
		public DateTime RestTime { get; set; }
		public Guid ExerciseId { get; set; }
		public Exercise? Exercise { get; set; }
	}
}
