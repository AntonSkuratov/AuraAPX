using AuraAPX.Core.Entities;
using AuraAPX.Storage.EntityConfigurations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Security;
using System.Text;

namespace AuraAPX.Storage
{
	public class DatabaseContext : DbContext
	{
		private readonly string _connectionString;
		public DatabaseContext(string connectionString)
		{
			_connectionString = connectionString;
			Database.EnsureCreated();
		}

		public DbSet<User> Users { get; set; } = null!;
		public DbSet<LocalLogin> LocalLogins { get; set; } = null!;
		public DbSet<UserParameters> UserParameters { get; set; } = null!;
		public DbSet<Workout> Workouts { get; set; } = null!;
		public DbSet<Exercise> Exercises { get; set; } = null!;
		public DbSet<Set> Sets { get; set; } = null!;


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseNpgsql(_connectionString);
		}


		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.ApplyConfiguration(new UserConfiguration());
			modelBuilder.ApplyConfiguration(new LocalLoginConfiguration());
			modelBuilder.ApplyConfiguration(new UserParametersConfiguration());
			modelBuilder.ApplyConfiguration(new WorkoutConfiguration());
			modelBuilder.ApplyConfiguration(new ExerciseConfiguration());
			modelBuilder.ApplyConfiguration(new SetConfiguration());
		}
	}
}
