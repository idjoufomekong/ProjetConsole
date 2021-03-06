﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    public class DAL
    {
        #region Propriétés
        public Logiciel Logi { get; }
        public Dictionary<string,Metier> Métiers { get; }
        public Dictionary<string,Personne> Personnes { get; }
        public List<Tache> Tâches { get; }
        #endregion

        #region Constructeur
        public DAL(string fichier)
        {
            //Entrée logiciel
            Logi = new Logiciel("GERONIMO");
            Logi.Versions.Add("1.00", new Version("1.00",2017,new DateTime(16,1,2), new DateTime(17,1,8)));
            Logi.Versions.Add("2.00", new Version("2.00", 2018, new DateTime(16, 12, 28), null));

            //Entrée métiers
            Métiers = new Dictionary<string, Metier>();
            Métiers.Add("ANA",new Metier("ANA","Analyste",ActivitésProd.DéfinitionBesoins| ActivitésProd.ArchitectureFonctionnelle | 
                ActivitésProd.AnalyseFonctionnelle));
            Métiers.Add("CDP",new Metier("CDP", "Chef de projet", ActivitésProd.ArchitectureTechnique | ActivitésProd.ArchitectureFonctionnelle |
                ActivitésProd.AnalyseFonctionnelle| ActivitésProd.Test | ActivitésProd.GestionProjet));
            Métiers.Add("DEV",new Metier("DEV", "Développeur", ActivitésProd.Test | ActivitésProd.Développement |
                ActivitésProd.AnalyseFonctionnelle | ActivitésProd.ArchitectureTechnique | ActivitésProd.AnalyseTechnique));
            Métiers.Add("DES",new Metier("DES", "Designer", ActivitésProd.Design | ActivitésProd.Infographie |
                ActivitésProd.AnalyseFonctionnelle));
            Métiers.Add("TES",new Metier("TES", "Testeur", ActivitésProd.RédactionPlanTest | ActivitésProd.Design));

            //Entrée liste des personnes
            Personnes = new Dictionary<string, Personne>();
            Personnes.Add("GL", new Personne("GL","LECLERCQ","Geneviève",Métiers["ANA"]));
            Personnes.Add("AF", new Personne("AF", "FERRAND", "Angèle", Métiers["ANA"]));
            Personnes.Add("BN", new Personne("BN", "NORMAND", "Balthazar", Métiers["CDP"]));
            Personnes.Add("RF", new Personne("RF", "FISHER", "Raymond", Métiers["DEV"]));
            Personnes.Add("LB", new Personne("LB", "BUTLER", "Lucien", Métiers["DEV"]));
            Personnes.Add("RB", new Personne("RB", "BEAUMONT", "Roseline", Métiers["DEV"]));
            Personnes.Add("MW", new Personne("MW", "WEBER", "Marguerite", Métiers["DES"]));
            Personnes.Add("HK", new Personne("HK", "KLEIN", "Hilaire", Métiers["TES"]));
            Personnes.Add("NP", new Personne("NP", "PALMER", "Nino", Métiers["TES"]));

            //Chargement des tâches dans un tableau de chaînes
            Tâches = new List<Tache>();
            string[] ligne = File.ReadAllLines(fichier);
            for(int i=1; i<ligne.Length; i++)
            {
                Tache t = AnalyserLigne(ligne[i]);
                Tâches.Add(t);
            }

        }
        #endregion

        #region Méthodes privées
        private Tache AnalyserLigne(string ligne)
        {
            string[] tab = ligne.Split('\t');

            int numTache = Int16.Parse(tab[0]);
            string vers = tab[1];
            Personne pers = Personnes[tab[2]];
            ActivitésProd activité = ActivitéDeCode(tab[3]);
            string libTache = tab[4];

            var tache = new TâcheProduction(numTache,libTache,pers,activité,Logi.Versions[vers]);
            tache.DateDébut = DateTime.Parse(tab[5]);
            tache.DuréePrévue = int.Parse(tab[6]);
            tache.DuréeRéalisée = int.Parse(tab[7]);
            tache.DuréeRestante = int.Parse(tab[8]);

            return tache;

        }

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
            else return ActivitésProd.Aucun;
        }

        #endregion
    }


}
