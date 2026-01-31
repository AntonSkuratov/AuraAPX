using AuraAPX.API.Authentication;
using AuraAPX.API.Authentication.Services.Interfaces;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Security.Cryptography;

namespace AuraAPX.API.Infrastructure.Services
{
	public class RedisRefreshTokenService : IRefreshTokenService
	{
		private readonly RedisConfiguration _redis;
		public RedisRefreshTokenService(IOptions<RedisConfiguration> redis)
		{
			_redis = redis.Value;
		}

		public RefreshTokenData CreateRefreshToken(Guid userId)
		{
			var connection = ConnectionMultiplexer.Connect(_redis.ConnectionString!);
			var db = connection.GetDatabase();
			var refreshToken = GenerateRefreshToken();
			var refreshTokenTtlDays = TimeSpan.FromDays(_redis.RefreshTokenTtlDays);

			db.StringSet(userId.ToString(), refreshToken, refreshTokenTtlDays);

			return new RefreshTokenData
			{
				Token = refreshToken,
				RefreshTokenTtlDays = _redis.RefreshTokenTtlDays
			};
		}

		private string GenerateRefreshToken()
		{
			var randomBytes = new byte[64];
			using var rng = RandomNumberGenerator.Create();
			rng.GetBytes(randomBytes);
			return Convert.ToBase64String(randomBytes);
		}
	}
}
