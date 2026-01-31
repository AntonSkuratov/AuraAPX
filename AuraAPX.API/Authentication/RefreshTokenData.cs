namespace AuraAPX.API.Authentication
{
	public class RefreshTokenData
	{
		public string? Token { get; set; }
		public int RefreshTokenTtlDays { get; set; }
	}
}
