using System;
using System.Collections.Generic;
using System.IO;

namespace JobOverview
{
	/// <summary>
	/// Fournit les données de l'application
	/// Certaines sont en dur, d'autres sont chargées depuis un fichier texte
	/// </summary>
	public class DAL
	{
		#region Propriétés
		public Logiciel Logi { get; }
		public Dictionary<string, Métier> Métiers { get; }
		public Dictionary<string, Personne> Personnes { get; }
		public List<Tache> Taches { get; }
		#endregion

		#region Constructeur
		public DAL(string fichier)
		{
			// Création des versions
			Logi = new Logiciel("Genomica");
			Logi.Versions.Add("1.00", new VersionLogiciel("1.00", 2017,
					new DateTime(2016, 1, 2), new DateTime(2017, 1, 8)));
			Logi.Versions.Add("2.00", new VersionLogiciel("2.00", 2018,
				new DateTime(2016, 12, 28), null));

			// Céation des métiers
			Métiers = new Dictionary<string, Métier>();
			Métiers.Add("ANA", new Métier("ANA", "Analyste",
				ActivitésProd.DéfinitionBesoins |
				ActivitésProd.ArchitectureFonctionnelle |
				ActivitésProd.AnalyseFonctionnelle));
			Métiers.Add("CDP", new Métier("CDP", "Chef de projet",
				ActivitésProd.ArchitectureFonctionnelle |
				ActivitésProd.ArchitectureTechnique |
				ActivitésProd.AnalyseFonctionnelle |
				ActivitésProd.Test |
				ActivitésProd.GestionProjet));
			Métiers.Add("DEV", new Métier("DEV", "Développeur",
				ActivitésProd.AnalyseFonctionnelle |
				ActivitésProd.ArchitectureTechnique |
				ActivitésProd.AnalyseTechnique |
				ActivitésProd.Développement |
				ActivitésProd.Test));
			Métiers.Add("DES", new Métier("DES", "Ddesigner",
				ActivitésProd.AnalyseFonctionnelle |
				ActivitésProd.Design |
				ActivitésProd.Infographie));
			Métiers.Add("TES", new Métier("TES", "Test",
				ActivitésProd.RédactionPlanTest |
				ActivitésProd.Test));

			// Création des personnes
			Personnes = new Dictionary<string, Personne>();
			Personnes.Add("GL", new Personne("GL", "Geneviève", "Leclercq", Métiers["ANA"]));
			Personnes.Add("AF", new Personne("AF", "Angèle", "Ferrand", Métiers["ANA"]));
			Personnes.Add("BN", new Personne("BN", "Balthazar", "Normand", Métiers["CDP"]));
			Personnes.Add("RF", new Personne("RF", "Raymond", "Fisher", Métiers["DEV"]));
			Personnes.Add("LB", new Personne("LB", "Lucien", "Butler", Métiers["DEV"]));
			Personnes.Add("RB", new Personne("RB", "Roseline", "Beaumont", Métiers["DEV"]));
			Personnes.Add("MW", new Personne("MW", "Marguerite", "Weber", Métiers["DES"]));
			Personnes.Add("HK", new Personne("HK", "Hilaire", "Klein", Métiers["TES"]));
			Personnes.Add("NP", new Personne("NP", "Nino", "Palmer", Métiers["TES"]));

			// Chargement des tâches dans un tableau de chaînes
			Taches = new List<Tache>();
			string[] lignes = File.ReadAllLines(fichier);
			for (int l = 1; l < lignes.Length; l++)
			{
				Tache t = AnalyserLigne(lignes[l]);
				Taches.Add(t);
			}
		}
		#endregion

		#region Méthodes privées
		// Créé et renvoie un objet Tache à partir d'une ligne de fichier
		private Tache AnalyserLigne(string ligne)
		{
			string[] valeurs = ligne.Split('\t');

			int numTache = Int16.Parse(valeurs[0]);
			string vers = valeurs[1];
			Personne pers = Personnes[valeurs[2]];
			ActivitésProd acti = ActivitéDeCode(valeurs[3]);
			string libTache = valeurs[4];

			var t = new TacheProduction(numTache, libTache, pers, acti, Logi.Versions[vers]);
			t.DateDeb = DateTime.Parse(valeurs[5]);
			t.DuréePrévue = int.Parse(valeurs[6]);
			t.DuréeRéalisée = int.Parse(valeurs[7]);
			t.DuréeRestante = int.Parse(valeurs[8]);

			return t;
		}

		// Renvoie l'activité correspondant au code passé en paramètre
		private ActivitésProd ActivitéDeCode(string code)
		{
			if (code == "DBE") return ActivitésProd.DéfinitionBesoins;
			else if (code == "ARF") return ActivitésProd.ArchitectureFonctionnelle;
			else if (code == "ANF") return ActivitésProd.AnalyseFonctionnelle;
			else if (code == "DES") return ActivitésProd.Design;
			else if (code == "INF") return ActivitésProd.Infographie;
			else if (code == "ART") return ActivitésProd.ArchitectureTechnique;
			else if (code == "ANT") return ActivitésProd.AnalyseTechnique;
			else if (code == "DEV") return ActivitésProd.Développement;
			else if (code == "RPT") return ActivitésProd.RédactionPlanTest;
			else if (code == "TES") return ActivitésProd.Test;
			else if (code == "GDP") return ActivitésProd.GestionProjet;
			else return ActivitésProd.Aucune;
		}
		#endregion
	}
}
