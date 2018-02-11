using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GS.Common.Exceptions;
using GS.Common.Extensions;
using GS.Common.Utility.Log;
using ZO.Kats.Dac.Entities;
using System.Configuration;
using GS.Common.Configuration;

namespace ZO.Kats.Launcher
{
	static class Program
	{
		private const string CONFIG_SECTION_NAME = "KIS";
		private const string CONFIG_FILENAME = "IPO";

		private static LogLevelManager Log
		{
			get;
			set;
		}

		/// <summary>
		/// 해당 응용 프로그램의 주 진입점입니다.
		/// </summary>
		[STAThread]
		static int Main()
		{
			if (GS.Common.Utility.Utilities.ExistInProcess("K-Packet 통합 관리 시스템") == true)
			{
				return -99;
			}

			Log = LogLevelManager.GetInstance(ConfigurationManager.AppSettings["logLevelPath"]);
			Log.InsertDateTime = true;
			Log.MakeDateFolder = true;

			AppDomain.CurrentDomain.UnhandledException += CurrentDomain_UnhadledException;
			Application.SetUnhandledExceptionMode(UnhandledExceptionMode.CatchException);
			Application.ThreadException += Application_ThreadException;

			Application.EnableVisualStyles();
			Application.SetCompatibleTextRenderingDefault(false);

			AppSettingsHelper.Initialize(CONFIG_SECTION_NAME, CONFIG_FILENAME);

			//if (CheckConfig() == true)
			{
				Application.Run(new MainForm());
			}

			return 0;
		}

		private static void CurrentDomain_UnhadledException(object sender, UnhandledExceptionEventArgs e)
		{
			var exception = e.ExceptionObject as Exception;
			var message = string.Empty;
			var stackTrace = string.Empty;

			if (exception != null)
			{
				var stack = new System.Diagnostics.StackTrace(exception, true);

				message = exception.GetFlattenInnerMessage();
				stackTrace = stack.ToString();
			}

			Log.Fatal("* CurrentDomain_UnhadledException:{0}\r\n{1}", message, stackTrace);

			//if (ExceptionHandler.DoUnhandledException(exception) == DialogResult.Abort)
			//{
			//	// Application.ThreadException은 해당 Exception을 처리하여 다음으로 진행하는데
			//	// CurrentDomain.UnhandledException은 종료 후에도 해당 Exception이 지속되어서 문제 발생
			//	// 다음으로 진행하는 버튼은 제거한다.
			//	System.Diagnostics.Process.GetCurrentProcess().Kill();
			//}
		}

		private static void Application_ThreadException(object sender, System.Threading.ThreadExceptionEventArgs e)
		{
			var message = e.Exception.GetFlattenInnerMessage();
			var stack = new System.Diagnostics.StackTrace(e.Exception, true);

			Log.Fatal("* Application_ThreadException:{0}\r\n{1}", message, stack.ToString());

			//if (ExceptionHandler.DoApplicationThreadException(e.Exception) == DialogResult.Abort)
			//{
			//	Application.Exit();
			//}
		}
	}
}
