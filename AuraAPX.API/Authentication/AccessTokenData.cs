namespace AuraAPX.API.Authentication
{
	public class AccessTokenData
	{
		public Guid UserId { get; set; }
		public string? Token { get; set; }
		public int Expires { get; set; }
	}
}
