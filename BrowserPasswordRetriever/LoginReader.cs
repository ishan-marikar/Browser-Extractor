namespace BrowserPasswordRetriever
{
	using System;
	using System.Collections.Generic;
	using System.IO;
	using System.Security.Cryptography;
	using System.Text;
	using Mono.Data.Sqlite;

	public class LoginReader
	{
		#region Public Methods and Operators

		public static List<Credentials> GetChromePasswords()
		{
			var credentials = new List<Credentials>();
			SqliteConnection connection = CreateConnection(Chrome.GetPasswordsFile());
			try
			{
				connection.Open();
				const string Sql = "SELECT * FROM logins";
				using (var command = new SqliteCommand(Sql, connection))
				{
					using (SqliteDataReader reader = command.ExecuteReader())
					{
						while (reader.Read())
						{
							string password = Chrome.Decrypt(reader["password_value"] as byte[]);
							credentials.Add(
								new Credentials
									{
										Site = reader["signon_realm"] as string,
										Username = reader["username_value"] as string,
										Password = password,
										Browser = "Google Chrome"
									});
						}
					}
				}
				
			}
			catch (Exception ex)
			{
				throw ex;
			}
			finally
			{
				connection.Close();
			}

			return credentials;
		}

		#endregion

		#region Methods

		private static SqliteConnection CreateConnection(string fileName)
		{
			string connectionString = string.Format("Data Source={0};", fileName);
			var connection = new SqliteConnection(connectionString);
			return connection;
		}


		#endregion
	}
}