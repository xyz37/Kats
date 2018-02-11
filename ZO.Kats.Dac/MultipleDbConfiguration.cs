using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac
{
	/// <summary>
	/// Class MultipleDbConfiguration.
	/// </summary>
	/// <seealso cref="System.Data.Entity.DbConfiguration" />
	public partial class MultipleDbConfiguration : System.Data.Entity.DbConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MultipleDbConfiguration"/> class.
		/// </summary>
		public MultipleDbConfiguration()
		{
			SetProviderServices(MySql.Data.Entity.MySqlProviderInvariantName.ProviderName, new MySql.Data.MySqlClient.MySqlProviderServices());

			SetDatabaseInitializer<KatsContext>(new KatsContextInitializer());
			//SetDatabaseInitializer<TAContext>(new TAContextInitializer());
		}

		/// <summary>
		/// Gets my SQL connection.
		/// </summary>
		/// <param name="connectionString">The connection string.</param>
		/// <returns>DbConnection.</returns>
		public static System.Data.Common.DbConnection GetMySqlConnection(string connectionString)
		{
			var connectionFactory = new MySql.Data.Entity.MySqlConnectionFactory();

			return connectionFactory.CreateConnection(connectionString);
		}

		/// <summary>
		/// Gets my SQL connection.
		/// </summary>
		/// <param name="database">The database.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="password">The password.</param>
		/// <param name="server">The server.</param>
		/// <param name="port">The port.</param>
		/// <returns>System.Data.Common.DbConnection.</returns>
		public static System.Data.Common.DbConnection GetMySqlConnection(
			string database,
			string userId,
			string password,
			string server = "localhost",
			uint port = 3306)
		{
			var connectionFactory = new MySql.Data.Entity.MySqlConnectionFactory();
			var connectionString = MySql.Data.MySqlClient.MySqlDbContext.GetMySqlConnectionString(database, userId, password, server, port);

			return connectionFactory.CreateConnection(connectionString);
		}
	}
}
