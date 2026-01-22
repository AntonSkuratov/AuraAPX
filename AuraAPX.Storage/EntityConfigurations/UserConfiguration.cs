using System;
using System.Collections.Generic;
using System.Text;
using AuraAPX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AuraAPX.Storage.EntityConfigurations
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
		public void Configure(EntityTypeBuilder<User> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasAlternateKey(x => x.Email);

			builder.Property(x => x.Name)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Surname)
				.IsRequired()
				.HasMaxLength(100);

			builder.Property(x => x.Email)
				.HasAnnotation("RegularExpression", @"^[^@]+@[^@]+$")
				.HasMaxLength(500);
		}
	}
}
