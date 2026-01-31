namespace AuraAPX.API.Infrastructure
{
	public class RedisConfiguration
	{
		public string? ConnectionString { get; set; }
		public string? InstanceName { get; set; }
		public int RefreshTokenTtlDays { get; set; }
	}
}
