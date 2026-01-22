using AuraAPX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.EntityConfigurations
{
	public class WorkoutConfiguration : IEntityTypeConfiguration<Workout>
	{
		public void Configure(EntityTypeBuilder<Workout> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Description)
				.HasMaxLength(1000);

			builder.Property(x => x.StartTime)
				.HasDefaultValue(DateTime.UtcNow);
		}
	}
}
