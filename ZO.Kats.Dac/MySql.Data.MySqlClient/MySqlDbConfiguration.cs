using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySql.Data.MySqlClient
{
	/// <summary>
	/// Class MySqlDbConfiguration.
	/// </summary>
	public partial class MySqlDbConfiguration : System.Data.Entity.DbConfiguration
	{
		/// <summary>
		/// Initializes a new instance of the <see cref="MySqlDbConfiguration"/> class.
		/// </summary>
		public MySqlDbConfiguration()
		{
			SetExecutionStrategy(Entity.MySqlProviderInvariantName.ProviderName, () => new Entity.MySqlExecutionStrategy());
			SetDefaultConnectionFactory(new MySql.Data.MySqlClient.MySqlConnectionFactory("MySql.Data.MySqlClient"));

			//SetSqlGenerator("MySql.Data.MySqlClient", new MySql.Data.Entity.MySqlMigrationSqlGenerator()); //it will generate MySql commands instead of SqlServer commands.
			//SetHistoryContextFactory("MySql.Data.MySqlClient", (conn, schema) => new MySqlHistoryContext(conn, schema)); //here s the thing.
		}
	}
}
