using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac
{
	class Program
	{
		[STAThread]
		static void Main()
		{
			var server = ConfigurationManager.AppSettings["Database"];

			using (var db = KatsContext.Create(server: server, forceDatabaseInitialize: true))
			{
			}

			Console.WriteLine("아무키나 누르세요");
			Console.ReadLine();
		}
	}
}
