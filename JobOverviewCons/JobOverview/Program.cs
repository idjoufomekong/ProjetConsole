using System;
using System.Collections.Generic;

namespace JobOverview
{
	class Program
	{
		static void Main(string[] args)
		{
			// Saisie puis affichage des activités annexes
			SortedDictionary<string, ActivitéAnnexe> dicAcivitésAnnexes = SaisirActivités();
			Console.Clear();
			Console.WriteLine("Liste des activités annexes :");
			foreach (var a in dicAcivitésAnnexes)
				Console.WriteLine("{0} : {1}", a.Key, a.Value.Libellé);

			// Affichage de quelques résultats de suivi de production
			Console.WriteLine();
			Console.WriteLine("Réultats du suivi de production");
			try
			{
				var res = new Results(@"..\..\..\Data.txt");

				int réalisé, restant;
				string pers = "GL";
				res.DuréesTravail("2.00", pers, out réalisé, out restant);

				Console.WriteLine("Sur la version {0}, {1} a fait {2}j, et il lui en reste {3}",
					2018, pers, réalisé, restant);

				var travail = res.TravailRéaliséParActivité("1.00");
				Console.WriteLine();
				Console.WriteLine("Travail réalisé sur la version 1.00 par activité :");
				foreach (var kvp in travail)
					Console.WriteLine(" - {0} : {1}j", kvp.Key, kvp.Value);

			}
			catch (System.IO.FileNotFoundException)
			{
				Console.WriteLine("Fichier de données Data.txt introuvable");
			}

			Console.ReadKey();
		}

		/// <summary>
		/// Saisie des activités annexes
		/// </summary>
		/// <returns>Dictionnaire des activités triées par code</returns>
		private static SortedDictionary<string, ActivitéAnnexe> SaisirActivités()
		{
			// Saisie de la liste des activités annexes
			var dicAcivitésAnnexes = new SortedDictionary<string, ActivitéAnnexe>();
			Console.WriteLine("Saisie de la listes d'activités annexes");
			Console.WriteLine();
			ConsoleKeyInfo ki;
			do
			{
				Console.WriteLine("Code ?");
				string code = Console.ReadLine();
				Console.WriteLine("Libellé ?");
				string libellé = Console.ReadLine();
				try
				{
					if (string.IsNullOrEmpty(code))
						throw new ArgumentException();
					dicAcivitésAnnexes.Add(code, new ActivitéAnnexe(code, libellé));
				}
				catch (ArgumentException)
				{
					Console.WriteLine("Le code doit être renseigné et unique");
				}
				Console.WriteLine("Appuyer sur Echap pour arrêter ou une autre touche pour continuer...");
				ki = Console.ReadKey(true);
			}
			while (ki.Key != ConsoleKey.Escape);
			return dicAcivitésAnnexes;
		}
	}
}
