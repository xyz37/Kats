using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZO.Kats.Common.Interfaces
{
	public interface ITTS
	{
		void TtsNormal(string text);

		void TtsQuick(string text);
	}
}
