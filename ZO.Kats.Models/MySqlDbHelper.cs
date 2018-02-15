// ****************************************************************************************************************** //
//	Domain		:	
//	Creator		:	KIMKIWON\xyz37(Kim Ki Won)
//	Create		:	2017년 12월 11일 월요일 18:05
//	Purpose		:	
// ------------------------------------------------------------------------------------------------------------------ //
//	Modifier	:	
//	Update		:	
//	Changes		:	
// ------------------------------------------------------------------------------------------------------------------ //
//	Comment		:	affectedRow 파라미터를 이용한 stored procedure는 아래 참고
/*
PROMPT CREATE OR REPLACE PROCEDURE sp_insert440
CREATE OR REPLACE PROCEDURE sp_insert440
(
	startTXNID 	IN NUMBER
	,startDT 	IN VARCHAR2
	,endDT 		IN VARCHAR2
	,affectedRow OUT NUMBER
)

IS
	vSQLERRM	VARCHAR2(255);
BEGIN

affectedRow := 0;

-- step 1.
INSERT INTO ssm_pcgut0440
(
	tx_id
)
SELECT
	NULL AS TX_ID
	FROM statView s
;

affectedRow := SQL%ROWCOUNT;
DBMS_OUTPUT.PUT_LINE('Insert ssm_pcgut0440: ' || SQL%ROWCOUNT);

COMMIT;

EXCEPTION
--	WHEN NO_DATA_FOUND THEN
--		RETURN 0;
	WHEN OTHERS THEN
		affectedRow := -1;

		ROLLBACK;

		vSQLERRM := SUBSTR(SQLERRM, 10, 100);
DBMS_OUTPUT.PUT_LINE('ERROR: ORA' || SQLCODE || vSQLERRM);
END;

 */
// ------------------------------------------------------------------------------------------------------------------ //
//	Reviewer	:	
//	Rev. Date	:	
//	Comment		:	
// ------------------------------------------------------------------------------------------------------------------ //
//	<copyright file="MySqlDbHelper.cs" company="(주)가치소프트">
//		Copyright (c) 2017. (주)가치소프트. All rights reserved.
//	</copyright>
// <summary></summary>
// ****************************************************************************************************************** //

using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace ZO.Kats.Dac
{
	/// <summary>
	/// Class MySql DbHelper.
	/// </summary>
	public class MySqlDbHelper
	{
		private const int DEFAULT_COMMAND_TIMEOUT = 120;

		/// <summary>
		/// Connection info
		/// </summary>
		[System.Diagnostics.DebuggerDisplay("Host:{Host}, Port:{Port}, Database:{Database}, UserId:{UserId}, Password:{Password}", Name = "ConnectionInfo")]
		public class ConnectionInfo
		{
			/// <summary>
			/// Initializes a new instance of the <see cref="ConnectionInfo" /> class.
			/// </summary>
			/// <param name="host">The host.</param>
			/// <param name="port">The port.</param>
			/// <param name="database">The database.</param>
			/// <param name="userId">The user identifier.</param>
			/// <param name="password">The password.</param>
			public ConnectionInfo(string host, string port, string database, string userId, string password)
			{
				Host = host;
				Port = port;
				Database = database;
				UserId = userId;
				Password = password;
			}

			/// <summary>
			/// Gets the host.
			/// </summary>
			public string Host { get; private set; }

			/// <summary>
			/// Gets the port.
			/// </summary>
			public string Port { get; private set; }

			/// <summary>
			/// Gets the TNS.
			/// </summary>
			public string Database { get; private set; }

			/// <summary>
			/// Gets the user identifier.
			/// </summary>
			public string UserId { get; private set; }
			/// <summary>
			/// Gets the password.
			/// </summary>
			public string Password { get; private set; }
		}

		#region Constants
		private const string OUT_PARAM_NAME = "affectedRow";
		#endregion

		/// <summary>
		/// Initializes a new instance of the <see cref="MySqlDbHelper" /> class.
		/// </summary>
		/// <param name="connectionInfo">The connection information.</param>
		public MySqlDbHelper(ConnectionInfo connectionInfo)
			: this(connectionInfo.Host, connectionInfo.Port, connectionInfo.Database, connectionInfo.UserId, connectionInfo.Password)
		{
		}

		/// <summary>
		/// Initializes a new instance of the <see cref="MySqlDbHelper" /> class.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="port">The port.</param>
		/// <param name="database">The database.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="password">The password.</param>
		public MySqlDbHelper(string host,
			string port,
			string database,
			string userId,
			string password)
		{
			Host = host;
			Port = port;
			Database = database;
			UserId = userId;
			Password = password;
			ConnectionString = GetConnectionString(host, port, database, userId, password);
		}

		/// <summary>
		/// Gets the host.
		/// </summary>
		public string Host { get; private set; }

		/// <summary>
		/// Gets the port.
		/// </summary>
		public string Port { get; private set; }

		/// <summary>
		/// Gets the database.
		/// </summary>
		public string Database { get; private set; }

		/// <summary>
		/// Gets the user identifier.
		/// </summary>
		public string UserId { get; private set; }
		/// <summary>
		/// Gets the password.
		/// </summary>
		public string Password { get; private set; }

		/// <summary>
		/// Gets the connection string.
		/// </summary>
		public string ConnectionString { get; private set; }

		/// <summary>
		/// Gets the connection string.
		/// </summary>
		/// <param name="host">The host.</param>
		/// <param name="port">The port.</param>
		/// <param name="tns">The TNS.</param>
		/// <param name="userId">The user identifier.</param>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public static string GetConnectionString(string host,
			string port,
			string database,
			string userId,
			string password)
		{
			return $"server = {host}; port = {port}; database = {database}; user id = {userId}; password = {password};persistsecurityinfo=True;allowuservariables=True";
		}

		/// <summary>
		/// Gets the connection string.
		/// </summary>
		/// <param name="connectionInfo">The connection information.</param>
		/// <returns></returns>
		public static string GetConnectionString(ConnectionInfo connectionInfo)
		{
			return GetConnectionString(connectionInfo.Host, connectionInfo.Port, connectionInfo.Database, connectionInfo.UserId, connectionInfo.Password);
		}

		private void InvokeCommand(Action<MySqlCommand> action, int commandTimeout)
		{
			using (var connection = new MySqlConnection(ConnectionString))
			{
				using (var command = new MySqlCommand())
				{
					command.CommandTimeout = commandTimeout;

					try
					{
						if (connection.State != ConnectionState.Open)
						{
							connection.Open();
						}

						command.Connection = connection;
						action(command);
					}
					finally
					{
						if (command != null)
						{
							command.Dispose();
						}

						if (connection != null)
						{
							connection.Close();
						}
					}
				}
			}
		}

		private async Task InvokeCommandAsync(Action<MySqlCommand> action, int commandTimeout)
		{
			using (var connection = new MySqlConnection(ConnectionString))
			{
				using (var command = new MySqlCommand())
				{
					command.CommandTimeout = commandTimeout;

					try
					{
						if (connection.State != ConnectionState.Open)
						{
							await connection.OpenAsync();
						}

						command.Connection = connection;
						action(command);
					}
					finally
					{
						if (command != null)
						{
							command.Dispose();
						}

						if (connection != null)
						{
							await connection.CloseAsync();
						}
					}
				}
			}
		}

		/// <summary>
		/// Invokes the command.
		/// </summary>
		/// <param name="connectionInfo">The connection information.</param>
		/// <param name="action">The action.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		public static void InvokeCommand(ConnectionInfo connectionInfo,
			Action<MySqlCommand> action,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			(new MySqlDbHelper(connectionInfo)).InvokeCommand(action, commandTimeout);
		}

		/// <summary>
		/// Gets the data table.
		/// </summary>
		/// <param name="commandText">The command text.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns></returns>
		public DataTable GetDataTable(string commandText, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			DataTable table = new DataTable();

			InvokeCommand(command =>
			{
				command.CommandText = commandText;
				command.CommandType = CommandType.Text;

				using (var da = new MySqlDataAdapter(command))
				{
					da.Fill(table);
				}
			}, commandTimeout);

			return table;
		}

		/// <summary>
		/// Gets the data table by stored procedure.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>
		/// DataTable.
		/// </returns>
		public DataTable GetDataTable(string procedureName,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT,
			params MySqlParameter[] parameters)
		{
			DataTable table = new DataTable();

			InvokeCommand(command =>
			{
				command.CommandText = procedureName;
				command.CommandType = CommandType.Text;

				if (parameters != null)
				{
					command.Parameters.AddRange(parameters);
				}

				MySqlDataReader reader = command.ExecuteReader();

				if (reader != null)
				{
					table.Load(reader);
				}
			}, commandTimeout);

			return table;
		}

		/// <summary>
		/// Gets the data table by stored procedure.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="parameters">The parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// DataTable.
		/// </returns>
		public DataTable GetDataTable(string procedureName,
			IDictionary<string, dynamic> parameters,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			var param = new MySqlParameter[0];

			if (parameters == null)
			{
				return GetDataTable(procedureName, commandTimeout, param);
			}

			param = parameters.ToDictionary().Select(x => new MySqlParameter
			{
				ParameterName = x.Key,
				Value = x.Value,
			}).ToArray();

			return GetDataTable(procedureName, commandTimeout, param);
		}

		/// <summary>
		/// Gets the scalar.
		/// </summary>
		/// <param name="commandText">The command text.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// dynamic.
		/// </returns>
		public object GetScalar(string commandText, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			object result = null;

			InvokeCommand(command =>
			{
				command.CommandText = commandText;
				command.CommandType = CommandType.Text;

				result = command.ExecuteScalar();
			}, commandTimeout);

			return result;
		}

		/// <summary>
		/// Executes the non query.
		/// </summary>
		/// <param name="commandText">The command text.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// System.Int32.
		/// </returns>
		public int ExecuteNonQuery(string commandText, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			int result = -1;

			InvokeCommand(command =>
			{
				command.CommandText = commandText;
				command.CommandType = CommandType.Text;

				result = command.ExecuteNonQuery();
			}, commandTimeout);

			return result;
		}

		/// <summary>
		/// Executes the non query by stored procedure.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>
		/// Insert, Update 성공시 -1을 Create Table 성공시 0 을 반환 합니다.
		/// </returns>
		public int ExecuteStoredProcedure(
			string procedureName,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT,
			params MySqlParameter[] parameters)
		{
			int result = 0;

			InvokeCommand(command =>
			{
				command.CommandText = procedureName;
				command.CommandType = CommandType.StoredProcedure;

				if (parameters != null)
				{
					command.Parameters.AddRange(parameters);
				}

				result = command.ExecuteNonQuery();
			}, commandTimeout);

			return result;
		}

		/// <summary>
		/// Executes the non query by stored procedure.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="parametersDictionary">The parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// Insert, Update 성공시 -1을 Create Table 성공시 0 을 반환 합니다.
		/// </returns>
		/// <exception cref="ArgumentNullException">parameters</exception>
		public int ExecuteStoredProcedure(
			string procedureName,
			object parametersDictionary,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			if (parametersDictionary == null)
			{
				throw new ArgumentNullException("parameters");
			}

			var affectedRow = 0;
			var param = parametersDictionary.ToDictionary().Select(x => new MySqlParameter
			{
				ParameterName = x.Key,
				Value = x.Value,
			}).ToList();

			// TODO: 추후 테스트 해봐야 한다.
			param.Add(new MySqlParameter(OUT_PARAM_NAME, MySqlDbType.Int32, affectedRow, ParameterDirection.Output, false, 10, 0, OUT_PARAM_NAME, DataRowVersion.Default, affectedRow));

			InvokeCommand(command =>
			{
				command.CommandText = procedureName;
				command.CommandType = CommandType.StoredProcedure;
				command.Parameters.AddRange(param.ToArray());

				command.ExecuteNonQuery();
				affectedRow = Convert.ToInt32(command.Parameters[param.Count - 1].Value.ToString());
			}, commandTimeout);

			return affectedRow;
		}

		/// <summary>
		/// Executes the transaction.
		/// </summary>
		/// <param name="commands">The commands.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// affected rows
		/// </returns>
		public int ExecuteTransaction(IEnumerable<string> commands, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			var affected = 0;

			using (var connection = new MySqlConnection(ConnectionString))
			{
				if (connection.State != ConnectionState.Open)
				{
					connection.Open();
				}

				using (var command = connection.CreateCommand())
				{
					MySqlTransaction transaction = null;

					try
					{

						transaction = connection.BeginTransaction(IsolationLevel.ReadCommitted);
						command.Transaction = transaction;

						foreach (string cmd in commands)
						{
							command.CommandTimeout = commandTimeout;
							command.CommandText = cmd;
							affected += command.ExecuteNonQuery();
						}

						transaction.Commit();
					}
					catch (Exception ex)
					{
						if (transaction != null)
						{
							transaction.Rollback();
						}

						throw ex;
					}
					finally
					{
						if (transaction != null)
						{
							transaction.Dispose();
						}

						if (command != null)
						{
							command.Dispose();
						}

						if (connection != null)
						{
							connection.Close();
						}
					}
				}
			}

			return affected;
		}

		/// <summary>
		/// Gets the data table asynchronous.
		/// </summary>
		/// <param name="commandText">The command text.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns></returns>
		public async Task<DataTable> GetDataTableAsync(string commandText, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			DataTable table = new DataTable();

			await InvokeCommandAsync(async command =>
			 {
				 command.CommandText = commandText;
				 command.CommandType = CommandType.Text;

				 using (var da = new MySqlDataAdapter(command))
				 {
					 await da.FillAsync(table);
				 }
			 }, commandTimeout);

			return table;
		}

		/// <summary>
		/// Gets the data table by stored procedure asynchronous.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>
		/// DataTable.
		/// </returns>
		public async Task<DataTable> GetDataTableAsync(string procedureName,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT,
			params MySqlParameter[] parameters)
		{
			return await Task.Run(() =>
			{
				return GetDataTable(procedureName, commandTimeout, parameters);
			});
		}

		/// <summary>
		/// Gets the data table by stored procedure.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="parameters">The parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// DataTable.
		/// </returns>
		public async Task<DataTable> GetDataTableAsync(string procedureName,
			IDictionary<string, dynamic> parameters,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			return await Task.Run(() =>
			{
				return GetDataTable(procedureName, parameters, commandTimeout);
			});
		}

		/// <summary>
		/// Gets the scalar asynchronous.
		/// </summary>
		/// <param name="commandText">The command text.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// dynamic.
		/// </returns>
		public async Task<object> GetScalarAsync(string commandText, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			return await Task.Run(() =>
			{
				return GetScalar(commandText, commandTimeout);
			});
		}

		/// <summary>
		/// Executes the non query asynchronous.
		/// </summary>
		/// <param name="commandText">The command text.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// System.Int32.
		/// </returns>
		public async Task<int> ExecuteNonQueryAsync(string commandText, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			int result = -1;

			await InvokeCommandAsync(command =>
			{
				command.CommandText = commandText;
				command.CommandType = CommandType.Text;

				result = command.ExecuteNonQuery();
			}, commandTimeout);

			return await Task.FromResult(result);
		}

		/// <summary>
		/// Executes the non query by stored procedure asynchronous.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <param name="parameters">The parameters.</param>
		/// <returns>
		/// Insert, Update 성공시 -1을 Create Table 성공시 0 을 반환 합니다.
		/// </returns>
		public async Task<int> ExecuteStoredProcedureAsync(
			string procedureName,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT,
			params MySqlParameter[] parameters)
		{
			return await Task.Run(() =>
			{
				return ExecuteStoredProcedure(procedureName, commandTimeout, parameters);
			});
		}

		/// <summary>
		/// Executes the non query by stored procedure asynchronous.
		/// </summary>
		/// <param name="procedureName">Name of the procedure.</param>
		/// <param name="parametersDictionary">The parameters.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// Insert, Update 성공시 -1을 Create Table 성공시 0 을 반환 합니다.
		/// </returns>
		/// <exception cref="ArgumentNullException">parameters</exception>
		public async Task<int> ExecuteStoredProcedureAsync(
			string procedureName,
			object parametersDictionary,
			int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			return await Task.Run(() =>
			{
				return ExecuteStoredProcedure(procedureName, parametersDictionary, commandTimeout);
			});
		}

		/// <summary>
		/// Executes the transaction asynchronous.
		/// </summary>
		/// <param name="commands">The commands.</param>
		/// <param name="commandTimeout">The command timeout.</param>
		/// <returns>
		/// affected rows
		/// </returns>
		public async Task<int> ExecuteTransactionAsync(IEnumerable<string> commands, int commandTimeout = DEFAULT_COMMAND_TIMEOUT)
		{
			return await Task.Run(() =>
			{
				return ExecuteTransaction(commands, commandTimeout);
			});
		}
	}
}
