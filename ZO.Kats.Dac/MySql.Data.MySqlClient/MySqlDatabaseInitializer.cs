/**********************************************************************************************************************/
/*	Domain		:	MySql.Data.MySqlClient.MySqlDatabaseInitializer`1
/*	Creator		:	KIM-KIWON\xyz37(Kim Ki Won)
/*	Create		:	Thursday, April 04, 2013 11:23 AM
/*	Purpose		:	
/*--------------------------------------------------------------------------------------------------------------------*/
/*	Modifier	:	
/*	Update		:	
/*	Changes		:	
/*--------------------------------------------------------------------------------------------------------------------*/
/*	Comment		:	http://www.nsilverbullet.net/2012/11/07/6-steps-to-get-entity-framework-5-working-with-mysql-5-5/
 *					http://brice-lambson.blogspot.kr/2012/05/using-entity-framework-code-first-with.html
 *					https://gist.github.com/3061139
 *					http://blog.oneunicorn.com/2012/02/27/code-first-migrations-making-__migrationhistory-not-a-system-table/
/*--------------------------------------------------------------------------------------------------------------------*/
/*	Reviewer	:	Kim Ki Won
/*	Rev. Date	:	
/**********************************************************************************************************************/

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Common;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Transactions;

namespace MySql.Data.MySqlClient
{
	/// <summary>
	/// Defines a method for the database initializer.
	/// </summary>
	/// <typeparam name="TContext">The type of the T context.
	/// This type parameter is contravariant. That is, you can use either the type you specified or any type that is less derived. 
	/// For more information about covariance and contravariance, see http://msdn.microsoft.com/en-us/library/dd799517(v=vs.103).aspx.
	/// </typeparam>
	public abstract class MySqlDatabaseInitializer<TContext> : IDatabaseInitializer<TContext>
		where TContext : DbContext
	{
		/// <summary>
		/// Executes the strategy to initialize the database for the given context.
		/// </summary>
		/// <param name="context">The context.</param>
		public abstract void InitializeDatabase(TContext context);

		/// <summary>
		/// Create MySql database.
		/// </summary>
		/// <param name="context">The context.</param>
		protected void CreateMySqlDatabase(TContext context)
		{
			try
			{
				context.Database.Create();
			}
			catch (MySql.Data.MySqlClient.MySqlException ex)
			{
				if (ex.HResult == -2147467259)
				{
					// You have an error in your SQL syntax; check the manual that corresponds to your MariaDB server version for the right syntax to use near 'Key)' at line 1
					// __migrationhistory 테이블이 생성이 안되는 경우
					CreateMigrationhistory(context);
				}
			}

			if (context.Database.Exists() == true)
			{
				Seed(context);      // No exception? Don't need a workaround
				context.SaveChanges();
			}
		}

		private bool CreateMigrationhistory(TContext context)
		{
			var result = false;
			var connection = (context.Database.Connection as MySqlConnection).Clone() as MySqlConnection;

			using (var command = connection.CreateCommand())
			{
				command.CommandText =
@"
create table if not exists `__MigrationHistory` (
  `MigrationId` nvarchar(150) not null,
  `ContextKey` nvarchar(300)  not null,
  `Model` longblob not null,
  `ProductVersion` nvarchar(32) not null,
  primary key (`MigrationId`)
) engine=InnoDb auto_increment=0;

INSERT INTO __MigrationHistory (
	MigrationId,
	ContextKey,
	Model,
	ProductVersion)
VALUES (
	@MigrationId,
	@ContextKey,
	@Model,
	@ProductVersion);
";
				command.Parameters.AddWithValue("@MigrationId", string.Format("{0}_{1}", DateTime.Now.ToString("yyyyMMddHHmmssf"), "InitialCreate"));
				command.Parameters.AddWithValue("@ContextKey", context.GetType().FullName);
				command.Parameters.AddWithValue("@Model", GetModel(context));
				command.Parameters.AddWithValue("@ProductVersion", GetProductVersion());

				connection.Open();

				try
				{
					result = command.ExecuteNonQuery() > 0;
				}
				catch
				{
				}
				finally
				{
					connection.Close();
				}
			}

			return result;
		}

		private byte[] GetModel(TContext context)
		{
			using (var memoryStream = new MemoryStream())
			{
				using (var gzipStream = new System.IO.Compression.GZipStream(memoryStream, System.IO.Compression.CompressionMode.Compress))
				using (var xmlWriter = System.Xml.XmlWriter.Create(gzipStream, new System.Xml.XmlWriterSettings
				{
					Indent = true
				}))
				{
					EdmxWriter.WriteEdmx(context, xmlWriter);
				}
				return memoryStream.ToArray();
			}
		}

		private string GetProductVersion()
		{
			return typeof(DbContext).Assembly
				.GetCustomAttributes(false)
				.OfType<System.Reflection.AssemblyInformationalVersionAttribute>()
				.Single()
				.InformationalVersion;
		}

		/// <summary>
		/// When overridden adds data to the context for seeding. The default implementation does nothing.
		/// </summary>
		/// <param name="context">The context to seed.</param>
		protected virtual void Seed(TContext context)
		{
		}
	}
}

