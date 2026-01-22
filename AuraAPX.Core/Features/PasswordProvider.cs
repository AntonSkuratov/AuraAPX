using AuraAPX.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Features
{
	public class PasswordProvider : IPasswordProvider
	{
		private readonly int _securityLevel;
		public PasswordProvider(int securityLevel)
		{
			_securityLevel = securityLevel;
		}

		public string GenerateHash(string password)
		{
			return BCrypt.Net.BCrypt.HashPassword(password, _securityLevel);
		}

		public bool VerifyPassword(string password, string hash)
		{
			return BCrypt.Net.BCrypt.Verify(password, hash);
		}
	}
}
