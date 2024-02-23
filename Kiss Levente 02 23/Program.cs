using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Management.Instrumentation;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Kiss_Levente_02_23
{
	internal class Program
	{
		static void Main(string[] args)
		{
			StreamReader sr = new StreamReader(@"taborok.txt");
			List<Tabor> lista = new List<Tabor>();
			while (!sr.EndOfStream)
			{
				lista.Add(new Tabor(sr.ReadLine()));
			}

			//2.
			Console.WriteLine($"2. feladat \nAz adatsorok száma: {lista.Count}\nAz először rögzített tábor témája: {lista[0].tema}\nAz utoljára rögzített tábor témája: {lista[lista.Count-1].tema}");

            //3.
            Console.WriteLine("3. feladat");
			int zenedb = 0;
            foreach (var tabor in lista)
			{
				if (tabor.tema == "zenei")
				{
                    Console.WriteLine($"Zenei tábor kezdődik {tabor.elsoHo}. hó {tabor.elsoNap}. napján.");
					zenedb++;
                }
				
			}
			if (zenedb == 0)
			{
				Console.WriteLine("Nem volt zenei tábor.");
			}

			//4. 
			int max = 0;
			foreach (var tabor in lista)
			{
				if (tabor.diakok.Count()>max)
				{
					max = tabor.diakok.Count();
				}
			}

			foreach (var tabor in lista)
			{
				if (tabor.diakok.Count()==max)
				{
                    Console.WriteLine($"4. feladat\nLegnépszerűbbek:\n{tabor.elsoHo} {tabor.elsoNap} {tabor.tema}");
                }
			}

			//6. 
			Console.WriteLine("6. feladat");
            Console.Write("Hó: ");
			int ho = Convert.ToInt32(Console.ReadLine());
            Console.Write("Nap:");
			int nap = Convert.ToInt32(Console.ReadLine());

			int db = 0;
			
            foreach (var tabor in lista)
            {
				int kezdetNap = Sorszam(tabor.elsoHo, tabor.elsoNap);
				int vegeNap = Sorszam(tabor.utolsoHo, tabor.utolsoNap);
				int inputNap = Sorszam(ho, nap);
				if (inputNap>= kezdetNap && inputNap <= vegeNap)
				{
					db++;
				}
            }

			Console.WriteLine($"Ekkor éppen {db} tábor tart.");

			//7
			List<Tabor> lista1 = new List<Tabor>();
            Console.WriteLine("7. feladat");
            Console.Write("Adja meg egy tanuló betűjelét: ");
			string betu = Console.ReadLine();
            foreach (var tabor in lista)
            {
				if (tabor.diakok.Contains(betu))
				{
					lista1.Add(tabor);
				}
			}

			StreamWriter sw = new StreamWriter("egytanulo.txt");

			foreach (var tabor in lista1.OrderBy(t => Sorszam(t.elsoHo, t.elsoNap)))
			{
				sw.WriteLine($"{tabor.elsoHo}.{tabor.elsoNap}-{tabor.utolsoHo}.{tabor.utolsoNap}. {tabor.tema}");
			}

			bool resztvesz = true;
			foreach (var tabor in lista1)
			{
				int elso = Sorszam(tabor.elsoHo, tabor.elsoNap);

			}
			

			sw.Close();


			Console.ReadKey();
        }
		//5.
		public static int Sorszam(int honap, int nap)
		{
			int adottNap = 0;
			int juniusiNapok = 15;
			int juliusiNapok = 31;
			int augusztusiNapok = 31;

			if (honap == 6)	
			{
				adottNap = nap - juniusiNapok;
			}
			if (honap ==7)
			{
				int kulonbseg = juliusiNapok - nap;
				adottNap = juniusiNapok + juliusiNapok -kulonbseg;
			}

			if (honap ==8)
			{
				int kulonbseg = augusztusiNapok - nap;
				adottNap = juniusiNapok + juliusiNapok + augusztusiNapok - kulonbseg;
			}

			return adottNap;
		}
	}
}
