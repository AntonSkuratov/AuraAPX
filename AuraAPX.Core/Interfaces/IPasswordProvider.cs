using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Interfaces
{
	public interface IPasswordProvider
	{
		string GenerateHash(string password);
		bool VerifyPassword(string password, string hash);
	}
}
