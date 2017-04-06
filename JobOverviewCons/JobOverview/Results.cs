using System.Collections.Generic;
using System.Linq;

namespace JobOverview
{
	/// <summary>
	/// Fournit les méthodes d'exploitation des données brutes
	/// </summary>
	public class Results
	{
		private DAL _data;
		public Results(string fichier)
		{
			_data = new DAL(fichier);
		}

		// Durées de travail réalisée et restante d’une personne sur une version
		public void DuréesTravail(string version, string pers, out int réalisé, out int restant)
		{
			var taches = _data.Taches.OfType<TacheProduction>().
				Where(T => T.VersionLogiciel.NumVersion == version &&
				T.AffectéeA.Id == pers);

			réalisé = taches.Sum(T => T.DuréeRéalisée);
			restant = taches.Sum(T => T.DuréeRestante);
		}

		// Nombre de jours et pourcentage d’avance ou de retard sur une version
		public void BilanVersion(string version, out int diff, out int pourcentDif)
		{
			var taches = _data.Taches.OfType<TacheProduction>().
				Where(T => T.VersionLogiciel.NumVersion == version);

			int réalisé = taches.Sum(T => T.DuréeRéalisée);
			int prévu = taches.Sum(T => T.DuréePrévue);

			diff = réalisé - prévu;
			pourcentDif = diff / prévu * 100;
		}

		// Durées totales de travail réalisées sur la production d’une version, pour chaque activité
		public Dictionary<ActivitésProd, int> TravailRéaliséParActivité(string version)
		{
			var res = new Dictionary<ActivitésProd, int>();
			var activités = _data.Taches.OfType<TacheProduction>().Select(T => T.Activité).Distinct();

			foreach (var a in activités)
			{
				int durée = _data.Taches.OfType<TacheProduction>().
					Where(T => T.VersionLogiciel.NumVersion == version &&
					T.Activité == a).Sum(T => T.DuréeRéalisée);

				res.Add(a, durée);
			}

			return res;
		}
	}
}
