using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    class Result
    {
        #region MyRegion

        private int _numTâche;
        private DateTime _dateDébut;
        private DateTime _dateFin;
        private int _duréePrévue;
        private int _dureeTravailRealise;
        private DateTime _dureeRestante;
        private int _nombreJours;
        private int PourcentageAvanceRetard;
        int _dureeTravailTotal;
        int _dureeDBE;
        int _dureeARF;
        int _dureeANF;
        int _dureeDES;
        int _dureeINF;
        int _dureeART;
        int _dureeANT;
        int _dureeDEV;
        int _dureeRPT;
        int _dureeTES;
        int _dureeGDP;
        #endregion

        #region Propriétés
        public int NumTâche { get; set; }
        public int DateDébut { get; set; }
        public int DateFin { get; set; }
        public int DuréePrévue { get; set; }


        #endregion

        #region Constructeurs

        #endregion

        #region Méthodes privées

        #endregion
        #region Méthodes publiques
        /// <summary>
        /// Calcul de la duree du travail realise en retranchant la date de fin de travail à celle du début
        /// </summary>
        public void CalculDureeTravailRealise(string initial, out int réalisé1, out int restant1, out int réalisé2, out int restant2)
        {

            Dal v = new Dal();
            v.ChargerDonnées();
            List<DonnéesTâcheProd> m = v.Data;

            var selection = m.Select(c => c.Personne == initial);
            var personne1 = m.Where(c => c.Personne == initial && c.Version == "1.00"); // On recupère une liste de personnes 
            //correspondant aux initales saisies par l'utilisateur et on selectionne la version 1.00
            réalisé1 = personne1.Sum(c => c.DuréeRéalisée); //Somme de la durée de travail réalisé par la personne
            restant1 = personne1.Sum(c => c.DuréeRestante); //Somme de la durée de travail restante par la personne
         
            var personne2 = m.Where(c => c.Personne == initial && c.Version == "2.00"); // On recupère une liste de personnes 
            //correspondant aux initales saisies par l'utilisateur et on selectionne la version 1.00
            réalisé2 = personne2.Sum(c => c.DuréeRéalisée); //Somme de la durée de travail réalisé par la personne
            restant2 = personne2.Sum(c => c.DuréeRestante); //Somme de la durée de travail restante par la personne



        }

        /// <summary>
        /// Calcul de la duree restant de travail en retranchant la durée qui est prévue à celle deja passée sur le projet 
        /// </summary>
 
        public void CalculNombreJour( out int nbrJour, out int nbrJour2, out int pourcentage1, out int pourcentage2, out double pourcentage1Retard, out double pourcentage2Retard)
        {


            Dal v = new Dal();
            v.ChargerDonnées();
            List<DonnéesTâcheProd> m = v.Data;
           //On cherche dans la version 1 la durée du travail réalisé et la durée restante
            var personne1 = m.Where(c => c.Version == "1.00"); 
            var réalisé = personne1.Sum(c => c.DuréeRéalisée); 
            var prévue = personne1.Sum(c => c.DuréePrévue);

            nbrJour = prévue - réalisé;
            //on calcul le pourcentage de retard ou d'avancement pour la version 2.00
            pourcentage1 = réalisé * 100 / prévue;
            pourcentage1Retard = (réalisé-prévue) * 100 / prévue;


            //On cherche dans la version 2 la durée du travail réalisé et la durée restante
            var personne2 = m.Where(c => c.Version == "2.00");
            var réalisé2 = personne2.Sum(c => c.DuréeRéalisée);
            //on calcul le pourcentage de retard ou d'avancement pour la version 2.00
            var prévue2 = personne2.Sum(c => c.DuréePrévue);

            nbrJour2 = prévue2 - réalisé2;
            pourcentage2 = réalisé2 * 100 / prévue2;
            pourcentage2Retard = (réalisé2 - prévue2) * 100 / prévue2;

        }
        /// <summary>
        /// Durée totale  de travail réalisés sur la production de la version 1 pour chaque activité
        /// </summary>
        public string CalculDureeTotal1()
        {
            string s = string.Empty;
            Dal v = new Dal();
            v.ChargerDonnées();
            List<DonnéesTâcheProd> m = v.Data;
            Dictionary<string, int> version1 = new Dictionary<string, int>();
            
            var selection = m.Select(c => c.Activité).Distinct();
            foreach(var a in selection)
            {
                var durée = m.Where(c => c.Activité == a && c.Version == "1.00").Sum(c => c.DuréeRéalisée);
                version1.Add(a, durée);
          
            }
            foreach (var a in version1)
            {
               s = s + string.Format("\nL'activité {0} a mis {1} j", a.Key, a.Value);
            }
            return s;
           
        }

        public string CalculDureeTotal2()
        {
            string s = string.Empty;
            Dal v = new Dal();
            v.ChargerDonnées();
            List<DonnéesTâcheProd> m = v.Data;
            Dictionary<string, int> version2 = new Dictionary<string, int>();


            var selection = m.Select(c => c.Activité).Distinct();
            foreach (var a in selection)
            {
                var durée = m.Where(c => c.Activité == a && c.Version == "2.00").Sum(c => c.DuréeRéalisée);
                version2.Add(a, durée);
            }
            foreach (var a in version2)
            {
                s = s + string.Format("\nL'activité {0} a mis {1} j", a.Key, a.Value);
            }
            return s;

        }
        #endregion
    }
}
