using AuraAPX.API.Authentication;
using AuraAPX.API.Authentication.Services;
using AuraAPX.API.Authentication.Services.Interfaces;
using AuraAPX.API.Infrastructure;
using AuraAPX.API.Infrastructure.Services;
using AuraAPX.API.Infrastructure.Validation;
using AuraAPX.Application.Services;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Features;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using AuraAPX.Storage;
using AuraAPX.Storage.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.EntityFrameworkCore.Scaffolding.Metadata;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var jwtSettings = builder.Configuration.GetSection("Auth").GetSection("JwtAccessTokenSettings").Get<JwtAccessTokenSettings>();


builder.Services.Configure<RedisConfiguration>(builder.Configuration.GetSection("Redis"));
builder.Services.Configure<JwtAccessTokenSettings>(builder.Configuration.GetSection("Auth").GetSection("JwtAccessTokenSettings"));
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
	.AddJwtBearer(options =>
	{
		options.TokenValidationParameters = new TokenValidationParameters
		{
			ValidateIssuer = true,
			ValidIssuer = jwtSettings!.Issuer,
			ValidateAudience = true,
			ValidAudience = jwtSettings.Audience,
			ValidateLifetime = true,
			IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key!)),
			ValidateIssuerSigningKey = true,
			ClockSkew = TimeSpan.Zero
		};
	});

builder.Services.AddControllers()
	.AddJsonOptions(options =>
	{
		options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
		options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
	});


builder.Services.AddOpenApi();

builder.Services.AddValidatorsFromAssemblyContaining<UserValidator>();

builder.Services.AddTransient<IRefreshTokenService, RedisRefreshTokenService>();
builder.Services.AddTransient<IJwtAuthenticationService, JwtAuthenticationService>();
builder.Services.AddTransient<IExerciseRepository, ExerciseRepository>();
builder.Services.AddTransient<IExerciseService, ExerciseService>();
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
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
