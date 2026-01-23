using AuraAPX.Application.Services;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Features;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using AuraAPX.Storage;
using AuraAPX.Storage.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	});
builder.Services.AddOpenApi();

builder.Services.AddTransient<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddTransient<IWorkoutService, WorkoutService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();
builder.Services.AddTransient<IPasswordProvider>(passwordProvider =>
	{
		return new PasswordProvider(Convert.ToInt32(builder.Configuration.GetSection("Security").GetSection("SecurityLevel").Value));
	});

builder.Services.AddSingleton<DatabaseContext>(options =>
	{
		return new DatabaseContext(builder.Configuration.GetSection("ConnectionString").Value!);
	});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
	app.MapOpenApi();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
