using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kiss_Levente_02_23
{
	internal class Tabor
	{
		public int elsoHo;
		public int elsoNap;
		public int utolsoHo;
		public int utolsoNap;
		public string diakok;
		public string tema;

		public Tabor(string s)
		{
			var v = s.Split('\t');
			elsoHo = int.Parse(v[0]);
			elsoNap = int.Parse(v[1]);
			utolsoHo = int.Parse(v[2]);
			utolsoNap = int.Parse(v[3]);
			diakok = v[4];
			tema = v[5];
		}		
	}
}
