using System;

namespace JobOverview
{
	/// <summary>
	/// Activités de production (combinables)
	/// </summary>
	[Flags]
	public enum ActivitésProd
	{
		Aucune = 0,
		DéfinitionBesoins = 1,
		ArchitectureFonctionnelle = 2,
		AnalyseFonctionnelle = 4,
		Design = 8,
		Infographie = 16,
		ArchitectureTechnique = 32,
		AnalyseTechnique = 64,
		Développement = 128,
		RédactionPlanTest = 256,
		Test = 512,
		GestionProjet = 1024
	}

	/// <summary>
	/// Décrit une activité annexe
	/// </summary>
	public class ActivitéAnnexe
	{
		public string Code { get; }
		public string Libellé { get; }
		public ActivitéAnnexe(string code, string libellé)
		{
			Code = code;
			Libellé = libellé;
		}
	}

	/// <summary>
	/// Décrit un métier avec ses activités associées
	/// </summary>
	public class Métier
	{
		public string Code { get; }
		public string Libellé { get; }
		public ActivitésProd Activités { get; }

		public Métier(string code, string libellé, ActivitésProd  activités)
		{
			Code = code;
			Libellé = libellé;
			Activités = activités;
		}
	}
}
