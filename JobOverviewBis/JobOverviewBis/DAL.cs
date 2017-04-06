using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    public class DAL
    {
        #region Propriétés
        public Logiciel Logi { get; }
        public List<Metier> Métiers { get; }
        public List<Personne> Personnes { get; }
        public List<Tache> Tâches { get; }
        #endregion

        #region Constructeur
        public DAL()
        {
            //Entrée logiciel
            Logi = new Logiciel("GERONIMO");
            Logi.Versions.Add("1.00", new Version("1.00",2017,new DateTime(16,1,2), new DateTime(17,1,8)));
            Logi.Versions.Add("2.00", new Version("2.00", 2018, new DateTime(16, 12, 28), null));

            //Entrée métiers
            Métiers = new List<Metier>();
            Métiers.Add(new Metier("ANA","Analyste",ActivitésProd.DBE| ActivitésProd.ARF | 
                ActivitésProd.ANF));
            Métiers.Add(new Metier("CDP", "Chef de projet", ActivitésProd.ART | ActivitésProd.ARF |
                ActivitésProd.ANF| ActivitésProd.TES | ActivitésProd.GDP));
            Métiers.Add(new Metier("DEV", "Développeur", ActivitésProd.TES | ActivitésProd.DEV |
                ActivitésProd.ANF | ActivitésProd.ART | ActivitésProd.ANT));
            Métiers.Add(new Metier("DES", "Designer", ActivitésProd.DES | ActivitésProd.INF |
                ActivitésProd.ANF));
            Métiers.Add(new Metier("TES", "Testeur", ActivitésProd.RPT | ActivitésProd.DES));

            //Entrée liste des personnes
            Personnes = new List<Personne>();
            Personnes.Add(new Personne("GL","LECLERCQ","Geneviève",Métiers["ANA"]);
        }
        #endregion
    }


}
