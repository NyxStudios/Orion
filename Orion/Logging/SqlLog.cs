﻿/*
TShock, a server mod for Terraria
Copyright (C) 2011-2015 Nyx Studios (fka. The TShock Team)

This program is free software: you can redistribute it and/or modify
it under the terms of the GNU General Public License as published by
the Free Software Foundation, either version 3 of the License, or
(at your option) any later version.

This program is distributed in the hope that it will be useful,
but WITHOUT ANY WARRANTY; without even the implied warranty of
MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
GNU General Public License for more details.

You should have received a copy of the GNU General Public License
along with this program.  If not, see <http://www.gnu.org/licenses/>.
*/

using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using MySql.Data.MySqlClient;
using Orion.Extensions;
using Orion.SQL;

namespace Orion.Logging
{
	/// <summary>
	/// Class inheriting ILog for writing logs to TShock's SQL database
	/// </summary>
	public class SqlLog : ILog, IDisposable
	{
		private readonly IDbConnection _database;
		private readonly ILog _backupLog;
		private readonly List<LogInfo> _failures;
		private bool _useTextLog;
		private readonly Orion _orion;

	    private class LogInfo
        {
            public string Timestamp { get; set; }
            public string Message { get; set; }
            public string Caller { get; set; }
            public LogLevel LogLevel { get; set; }

            public override string ToString()
            {
                return String.Format("Message: {0}: {1}: {2}",
                    Caller, LogLevel.ToString().ToUpper(), Message);
            }
        }

		/// <summary>
		/// Sets the database connection and the initial log level.
		/// </summary>
		/// <param name="orion">Orion</param>
		/// <param name="textlogFilepath">File path to a backup text log in case the SQL log fails</param>
		/// <param name="clearTextLog"></param>
		public SqlLog(Orion orion, string textlogFilepath, bool clearTextLog)
		{
			_orion = orion;
			_failures = new List<LogInfo>(orion.Config.MaxSqlLogFailureCount);

			_database = orion.Database;
			//FileName = String.Format("{0}://database", _database.GetSqlType());
			_backupLog = new Log(textlogFilepath);

			SqlTable table = new SqlTable("Logs",
				new SqlColumn("ID", MySqlDbType.Int32) { AutoIncrement = true, Primary = true },
				new SqlColumn("TimeStamp", MySqlDbType.Text),
				new SqlColumn("LogLevel", MySqlDbType.Int32),
				new SqlColumn("Caller", MySqlDbType.Text),
				new SqlColumn("Message", MySqlDbType.Text)
				);

			SqlTableCreator creator = new SqlTableCreator(_database,
				_database.GetSqlType() == SqlType.Sqlite
					? (IQueryBuilder)new SqliteQueryCreator()
					: new MysqlQueryCreator());
			creator.EnsureTableStructure(table);
		}

        public bool MayWriteType(LogLevel type)
        {
            return true;
        }

		/// <summary>
		/// Writes an error to the log file.
		/// </summary>
		/// <param name="message">The message to be written.</param>
		public void Error(string message)
		{
            Write(message, LogLevel.Error);
		}

		/// <summary>
		/// Writes an error to the log file.
		/// </summary>
		/// <param name="format">The format of the message to be written.</param>
		/// <param name="args">The format arguments.</param>
		public void Error(string format, params object[] args)
		{
			Error(String.Format(format, args));
		}

		/// <summary>
		/// Writes an error to the log file.
		/// </summary>
		/// <param name="message">The message to be written.</param>
		public void ConsoleError(string message)
		{
			Console.ForegroundColor = ConsoleColor.Red;
			Console.WriteLine(message);
			Console.ForegroundColor = ConsoleColor.Gray;
            Write(message, LogLevel.Error);
		}

		/// <summary>
		/// Writes an error to the log file.
		/// </summary>
		/// <param name="format">The format of the message to be written.</param>
		/// <param name="args">The format arguments.</param>
		public void ConsoleError(string format, params object[] args)
		{
			ConsoleError(String.Format(format, args));
		}

		/// <summary>
		/// Writes a warning to the log file.
		/// </summary>
		/// <param name="message">The message to be written.</param>
		public void Warn(string message)
		{
            Write(message, LogLevel.Warning);
		}

		/// <summary>
		/// Writes a warning to the log file.
		/// </summary>
		/// <param name="format">The format of the message to be written.</param>
		/// <param name="args">The format arguments.</param>
		public void Warn(string format, params object[] args)
		{
			Warn(String.Format(format, args));
		}

		/// <summary>
		/// Writes an informative string to the log file.
		/// </summary>
		/// <param name="message">The message to be written.</param>
		public void Info(string message)
		{
            Write(message, LogLevel.Info);
		}

		/// <summary>
		/// Writes an informative string to the log file.
		/// </summary>
		/// <param name="format">The format of the message to be written.</param>
		/// <param name="args">The format arguments.</param>
		public void Info(string format, params object[] args)
		{
			Info(String.Format(format, args));
		}

		/// <summary>
		/// Writes an informative string to the log file. Also outputs to the console.
		/// </summary>
		/// <param name="message">The message to be written.</param>
		public void ConsoleInfo(string message)
		{
			Console.ForegroundColor = ConsoleColor.Yellow;
			Console.WriteLine(message);
			Console.ForegroundColor = ConsoleColor.Gray;
            Write(message, LogLevel.Info);
		}

		/// <summary>
		/// Writes an informative string to the log file. Also outputs to the console.
		/// </summary>
		/// <param name="format">The format of the message to be written.</param>
		/// <param name="args">The format arguments.</param>
		public void ConsoleInfo(string format, params object[] args)
		{
			ConsoleInfo(String.Format(format, args));
		}

		/// <summary>
		/// Writes a debug string to the log file.
		/// </summary>
		/// <param name="message">The message to be written.</param>
		public void Debug(string message)
		{
            Write(message, LogLevel.Debug);
		}

		/// <summary>
		/// Writes a debug string to the log file.
		/// </summary>
		/// <param name="format">The format of the message to be written.</param>
		/// <param name="args">The format arguments.</param>
		public void Debug(string format, params object[] args)
		{
			Debug(String.Format(format, args));
		}

        public void Write(string message, LogLevel level)
		{
			if (!MayWriteType(level))
				return;

			string caller = "TShock";

			StackFrame frame = new StackTrace().GetFrame(2);
			if (frame != null)
			{
				MethodBase meth = frame.GetMethod();
				if (meth != null && meth.DeclaringType != null)
					caller = meth.DeclaringType.Name;
			}

			try
			{
				if (_useTextLog)
				{
					_backupLog.Write(message, level);
					return;
				}

				_database.Query("INSERT INTO Logs (TimeStamp, Caller, LogLevel, Message) VALUES (@0, @1, @2, @3)",
					DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss"), caller, (int)level, message);

				bool success = true;
				while (_failures.Count > 0 && success)
				{
					LogInfo info = _failures.First();

					try
					{
						_database.Query("INSERT INTO Logs (TimeStamp, Caller, LogLevel, Message) VALUES (@0, @1, @2, @3)",
							info.Timestamp, info.Caller, (int)info.LogLevel, info.Message);
					}
					catch (Exception ex)
					{
						success = false;
						_failures.Add(new LogInfo
						{
							Caller = "TShock",
                            LogLevel = LogLevel.Error,
							Message = String.Format("SQL Log insert query failed: {0}", ex),
							Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
						});
					}

					if (success)
						_failures.RemoveAt(0);
				}
			}
			catch (Exception ex)
			{
				_backupLog.ConsoleError("SQL Log insert query failed: {0}", ex);

				_failures.Add(new LogInfo
				{
					LogLevel = level,
					Message = message,
					Caller = caller,
					Timestamp = DateTime.UtcNow.ToString("yyyy-MM-dd HH:mm:ss")
				});
			}

			if (_failures.Count >= _orion.Config.MaxSqlLogFailureCount)
			{
				_useTextLog = true;
				_backupLog.ConsoleError("SQL Logging disabled due to errors. Reverting to text logging.");

				foreach (LogInfo logInfo in _failures)
				{
					_backupLog.Write(String.Format("SQL log failed at: {0}. {1}", logInfo.Timestamp, logInfo),
                        LogLevel.Error);
				}
				_failures.Clear();
			}
		}

		public void Dispose()
		{
			_backupLog.Dispose();
		}
	}
}