using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Dac
{
	internal sealed class KatsContextDbConfiguration : MySql.Data.MySqlClient.MySqlDbConfiguration
	{
		public KatsContextDbConfiguration()
		{
			SetDatabaseInitializer<KatsContext>(new KatsContextInitializer());
		}
	}
}
