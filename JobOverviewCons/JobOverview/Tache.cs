using System;
using System.Collections.Generic;

namespace JobOverview
{
	/// <summary>
	/// Classe ancêtre pour les tâches
	/// </summary>
	public class Tache
	{
		public int Numéro { get; protected set; }
		public string Libellé { get; }
		public Personne AffectéeA { get; }
		public string Description { get; set; }

		public Tache(int numéro, string libellé, Personne personne)
		{
			Numéro = numéro;
			Libellé = libellé;
			AffectéeA = personne;
		}
	}

	/// <summary>
	/// Tâche de production, faisant l'objet d'une planification
	/// </summary>
	public class TacheProduction : Tache
	{
		public VersionLogiciel VersionLogiciel { get; }
		public ActivitésProd Activité { get; }
		public DateTime DateDeb { get; set; }
		public int DuréePrévue { get; set; }
		public int DuréeRéalisée { get; set; }
		public int DuréeRestante { get; set; }

		public TacheProduction(int numéro, string libellé, Personne personne,
			ActivitésProd activité, VersionLogiciel version) :	base(numéro, libellé, personne)
		{
			VersionLogiciel = version;
			Activité = activité;
		}
	}

	/// <summary>
	/// Tâche annexe, ne faisant pas l'objet d'un suivi de production
	/// </summary>
	public class TacheAnnexe : Tache
	{
		private static int _numTache = 0;

		public ActivitéAnnexe Activité { get; }
		public Dictionary<DateTime, int> DuréesMensuelles { get; }

		public TacheAnnexe(string libellé, Personne personne, string codeActivité) :
			base(0, libellé, personne)
		{
			Numéro = _numTache++;
			DuréesMensuelles = new Dictionary<DateTime, int>();
		}
	}
}
