using AuraAPX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.EntityConfigurations
{
	public class SetConfiguration : IEntityTypeConfiguration<Set>
	{
		public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Set> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Number)
				.IsRequired()
				.ValueGeneratedOnAdd()
				.HasMaxLength(10000);

			builder.Property(x => x.NumberRepetitions)
				.HasMaxLength(100000);
		}
	}
}
