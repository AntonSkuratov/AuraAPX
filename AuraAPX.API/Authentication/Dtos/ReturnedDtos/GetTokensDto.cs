namespace AuraAPX.API.Authentication.Dtos.ReturnedDtos
{
	public record GetTokensDto
		(
		AccessTokenData AccessToken,
		RefreshTokenData RefreshToken
		);
}
