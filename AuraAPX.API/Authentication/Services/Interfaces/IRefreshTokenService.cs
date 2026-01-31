namespace AuraAPX.API.Authentication.Services.Interfaces
{
	public interface IRefreshTokenService
	{
		RefreshTokenData CreateRefreshToken(Guid userId);
	}
}
