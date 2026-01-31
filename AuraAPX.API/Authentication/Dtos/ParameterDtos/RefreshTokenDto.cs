namespace AuraAPX.API.Authentication.Dtos.ParameterDtos
{
	public record RefreshTokenDto
		(
		Guid UserId,
		string RefreshToken
		);
}
