using System;
using System.Collections.Generic;
using System.Text;

namespace AuraAPX.Core.Interfaces
{
	public interface IPasswordProvider
	{
		string GenerateSalt();
		string GenerateHash(string password, string salt);
	}
}
