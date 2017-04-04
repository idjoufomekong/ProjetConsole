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
        public void CalculDureeTravailRealise()
        {
            
        }

        /// <summary>
        /// Calcul de la duree restant de travail en retranchant la durée qui est prévue à celle deja passée sur le projet 
        /// </summary>
        public void CalculDureeRestante()
        {
            //TODO retrouver dans le tableau les différentes durées
            //TimeSpan dureeTravailRealise = Convert.ToDateTime(_dureeTravailRealise.ToString());
            int _dureeRestante = _duréePrévue - _dureeTravailRealise;

        }
        public void CalculNombreJour()
        {
            int _nombreJours = DuréePrévue - _dureeTravailRealise;
            // Calcul du pourcentage d'avancement du projet. si le pourcentage > 100 alors il y a du retard.
            int PourcentageAvanceRetard = (_dureeTravailRealise * 100 / DuréePrévue);
        }

        public void CalculDureeTotal()
        {

            //TODO utiliser les durée de travail par activités fournie dans le tableau pour déterminer les différentes durées de travail par activité
            int _dureeTravailTotal = _dureeDBE + _dureeARF + _dureeANF + _dureeDES + _dureeINF + _dureeART + _dureeANT + _dureeDEV + _dureeRPT + _dureeTES + _dureeGDP;



        }
        #endregion
    }
}
