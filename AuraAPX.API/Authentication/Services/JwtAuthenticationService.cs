using AuraAPX.API.Authentication.Services.Interfaces;
using AuraAPX.Application.Services.Interfaces;
using AuraAPX.Core.Entities;
using AuraAPX.Core.Interfaces;
using AuraAPX.Core.Interfaces.EntityInterfaces;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AuraAPX.API.Authentication.Services
{
	public class JwtAuthenticationService : IJwtAuthenticationService
	{
		private readonly IUserService _userService;
		private readonly IPasswordProvider _passwordProvider;
		private readonly JwtAccessSettings _jwtSettings;

		public JwtAuthenticationService(IUserService userService, IPasswordProvider passwordProvider, IOptions<JwtAccessSettings> jwtSettings)
		{
			_userService = userService;
			_passwordProvider = passwordProvider;
			_jwtSettings= jwtSettings.Value;
		}


		public async Task<string> GetJwtAccessToken(string login, string password)
		{
			var user = await _userService.GetUserByCredentials(login, password);

			var claims = new List<Claim>
			{
				new Claim("Email", user.Email!),
				new Claim("Login", user.LocalLogin!.Login!),
				new Claim("Guid-Id", user.Id.ToString()),
			};

			var token = new JwtSecurityToken(
				issuer: _jwtSettings.Issuer,
				audience: _jwtSettings.Audience,
				claims: claims,
				expires: DateTime.Now.AddMinutes(_jwtSettings.Expires),
				signingCredentials: new SigningCredentials(
					new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!)), SecurityAlgorithms.HmacSha256));
			var accessToken = new JwtSecurityTokenHandler().WriteToken(token);

			return accessToken;
		}
	}
}
