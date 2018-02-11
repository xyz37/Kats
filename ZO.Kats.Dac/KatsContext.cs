using System;
using System.Linq;
using System.Data.Entity;
using System.Collections.Generic;
using MySql.Data.MySqlClient;
using System.Configuration;
using ZO.Kats.Common;
using ZO.Kats.Dac.Entities;

namespace ZO.Kats.Dac
{
	/// <summary>
	/// 
	/// </summary>
	/// <seealso cref="MySql.Data.MySqlClient.MySqlDbContext" />
	[DbConfigurationType(typeof(MultipleDbConfiguration))]
	public partial class KatsContext : MySqlDbContext
	{
		private const string KatsContext_NAME = "KatsContext";

		#region Constructor
		/// <summary>
		/// KatsContext class의 새 인스턴스를 초기화 합니다.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="password">The password.</param>
		/// <param name="server">The server.</param>
		/// <param name="port">The port.</param>
		/// <param name="forceDatabaseInitialize">if set to <c>true</c> [force database initialize].</param>
		public KatsContext(
			string database,
			string userId,
			string password,
			string server = "localhost",
			uint port = 3306,
			bool forceDatabaseInitialize = false)
			//: base(database, userId, password, server, port)        // MySqlDbContext 가 생성자 일 경우에
			//: base(MultipleDbConfiguration.GetMySqlConnection(ConfigurationManager.ConnectionStrings[KatsContext_NAME].ConnectionString), true)
			//: base(ConfigurationManager.ConnectionStrings[KatsContext_NAME].ConnectionString)
			: base(MultipleDbConfiguration.GetMySqlConnection(database, userId, password, server, port), true)
		{
			if (forceDatabaseInitialize == true)
			{
				Database.Initialize(forceDatabaseInitialize);
			}
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="KatsContext"/> class.
		/// </summary>
		public KatsContext()
			: base(ConfigurationManager.ConnectionStrings[KatsContext_NAME].ConnectionString)
		{
			Database.Initialize(true);
		}

		/// <summary>
		/// 새로운 CRContext Instance를 생성 합니다.
		/// </summary>
		/// <param name="autoDetectChangesEnabled"><seealso cref="System.Data.Entity.Infrastructure.DbChangeTracker.DetectChanges" /> 메서드가 <see cref="System.Data.Entity.DbContext" />
		/// 및 관련 클래스의 메서드에 의해 자동으로 호출되는지 여부를 나타내는 값을 가져오거나 설정합니다.
		/// <remarks>데이터 추적이 필요하지 않은 Read 작업 등에서는 false로 하면 성능이 향상 됩니다.</remarks></param>
		/// <param name="proxyCreationEnabled">Proxy creation enabled.(virtual 선언한 멤버가 나오게 하려면 Proxy와 Lazy load을 true로 해야 한다.</param>
		/// <param name="lazyLoadingEnabled">The lazy loading enabled.</param>
		/// <param name="validateOnSaveEnabled">Validate on save enabled</param>
		/// <param name="server">The server.</param>
		/// <param name="port">The port.</param>
		/// <returns>CRContext.</returns>
		public static KatsContext Create(
			bool autoDetectChangesEnabled = true,
			bool proxyCreationEnabled = false,
			bool lazyLoadingEnabled = false,
			bool validateOnSaveEnabled = false,
			string server = "localhost",
			uint port = Constants.DB_PORT,
			bool forceDatabaseInitialize = false)
		{
			var context = new KatsContext(Constants.DB_NAME, Constants.DB_USER_ID, Constants.DB_USER_PASSWORD, server, port, forceDatabaseInitialize);

			context.Configuration.AutoDetectChangesEnabled = autoDetectChangesEnabled;
			context.Configuration.ProxyCreationEnabled = proxyCreationEnabled;
			context.Configuration.LazyLoadingEnabled = lazyLoadingEnabled;
			context.Configuration.ValidateOnSaveEnabled = validateOnSaveEnabled;

			return context;
		}

		private static string GetConnectionString(string server, uint port = Constants.DB_PORT)
		{
			return MySql.Data.MySqlClient.MySqlDbContext.GetMySqlConnectionString(
					   Constants.DB_NAME,
					   Constants.DB_USER_ID,
					   Constants.DB_USER_PASSWORD,
					   server,
					   port);
		}

		private static void ChangeConnectionString(string name, string connectionString)
		{
			const string CONNECTION_STRING_NAME = "connectionStrings";
			var config = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
			var connectionStringsSection = (ConnectionStringsSection)config.GetSection(CONNECTION_STRING_NAME);

			connectionStringsSection.ConnectionStrings[name].ConnectionString = connectionString;
			config.Save();

			ConfigurationManager.RefreshSection(CONNECTION_STRING_NAME);
		}

		/// <summary>
		/// Changes the connection string.
		/// </summary>
		/// <param name="server">The server.</param>
		/// <param name="port">The port.</param>
		public static void ChangeConnectionString(string server, uint port = Constants.DB_PORT)
		{
			var connectionString = KatsContext.GetConnectionString(server, port);

			ChangeConnectionString(KatsContext_NAME, connectionString);
		}
		#endregion

	}
}
