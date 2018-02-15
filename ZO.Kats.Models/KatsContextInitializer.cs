using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZO.Kats.Dac.Entities;
using System.Data.Entity;
using ZO.Kats.Dac.Configurations;
using System.Drawing;

namespace ZO.Kats.Dac
{
	internal class KatsContextInitializer : MySql.Data.MySqlClient.DropCreateMySqlDatabaseIfModelChanges<KatsContext>
	{
		protected override void Seed(KatsContext db)
		{
			base.Seed(db);


		}
	}
}
