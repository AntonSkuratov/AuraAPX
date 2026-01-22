using AuraAPX.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Storage.EntityConfigurations
{
	public class LocalLoginConfiguration : IEntityTypeConfiguration<LocalLogin>
	{
		public void Configure(EntityTypeBuilder<LocalLogin> builder)
		{
			builder.HasKey(x => x.Id);
			builder.HasAlternateKey(x => x.Login);

			builder.Property(x => x.Login)
				.IsRequired()
				.HasMaxLength(500);

			builder.Property(x => x.PasswordHash)
				.IsRequired();
		}
	}
}
