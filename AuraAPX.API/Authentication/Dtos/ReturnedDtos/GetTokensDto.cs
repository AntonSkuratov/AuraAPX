namespace AuraAPX.API.Authentication.Dtos.ReturnedDtos
{
	public record GetTokensDto
		(
		Guid UserId,
		AccessTokenData AccessToken,
		RefreshTokenData RefreshToken
		);
}
