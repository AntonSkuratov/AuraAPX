using AuraAPX.Core.Entities;

namespace AuraAPX.API.Authentication.Services.Interfaces
{
	public interface IJwtAuthenticationService
	{
		Task<AccessTokenData> GetJwtAccessToken(string login, string password);
	}
}
