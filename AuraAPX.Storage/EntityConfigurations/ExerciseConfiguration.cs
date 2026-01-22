using AuraAPX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.EntityConfigurations
{
	public class ExerciseConfiguration : IEntityTypeConfiguration<Exercise>
	{
		public void Configure(EntityTypeBuilder<Exercise> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Title)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Description)
				.HasMaxLength(1000);
		}
	}
}
