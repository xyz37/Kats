using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ZO.Kats.Common.Interfaces;

namespace ZO.Kats.Launcher
{
	partial class MainForm : ITTS
	{
		private bool TTSEnabled { get; set; }

		private static Microsoft.Speech.Synthesis.SpeechSynthesizer _speechSynthesizer;
		private static Microsoft.Speech.Synthesis.PromptBuilder _prormptBuilder;

		public void TtsNormal(string text)
		{
			if (TTSEnabled == false)
			{
				return;
			}

			_prormptBuilder.ClearContent();
			_prormptBuilder.AppendText(text);
			_speechSynthesizer.SpeakAsync(_prormptBuilder);
		}

		void ITTS.TtsQuick(string text)
		{
			_speechSynthesizer.Rate = 4;
			TtsNormal(text);
			_speechSynthesizer.Rate = 2;
		}
	}
}
