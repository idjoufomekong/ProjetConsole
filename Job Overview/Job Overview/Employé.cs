using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    class Employé
    {
        #region Champs privés
        private string _nom;
        private string _prenom;
        private Activités _statut;
        #endregion



        #region Propriétés
        public string Nom { get; set; }
        public string Prenom { get; set; }
        /// <summary>
        /// Le statut correspond au métier de l'employé
        /// </summary>
        public Activités Statut { get; set; }
        #endregion

        #region constructeurs
        public Employé (string nom, string prenom, Activités Statut)
        {
            Nom = _nom;
            Prenom = _prenom;
            Statut = _statut;
        }
        #endregion

        #region Méthodes
        /// <summary>
        /// Méthode qui calcul de cumul de temps passés sur les taches annexes
        /// </summary>
        public void CalculCumulTA()
        {

        }

        /// <summary>
        /// Méthode afin de définir les activités annexes via une saisie utilisateur
        /// </summary>
        public void SaisieActiviteAnnexe()
        {

        }
        /// <summary>
        /// Méthode permettant d'ajouter une activité annexe à un employé
        /// </summary>
        public void AjouterActiviteAnnexe()
        {


        }
        #endregion
    }
}
