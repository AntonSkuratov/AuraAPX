using AuraAPX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.EntityConfigurations
{
	public class UserParametersConfiguration : IEntityTypeConfiguration<UserParameters>
	{
		public void Configure(EntityTypeBuilder<UserParameters> builder)
		{
			builder.HasKey(x => x.Id);

			builder.Property(x => x.Gender)
				.HasMaxLength(7)
				.HasAnnotation("RegularExpression", "^(мужской|женский)$");

			builder.Property(x => x.Height)
				.HasMaxLength(250);

			builder.Property(x => x.Gender)
				.HasMaxLength(500);
		}
	}
}
