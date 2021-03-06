﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    public class Employé
    {
        #region Champs privés
        private string _nom;
        private string _prenom;
        private Activités _statut;
        private string _code;
        private string _métier;
        private int _CumulTempsTA;
        #endregion



        #region Propriétés
        public string Nom { get; }
        public string Prenom { get; }
        /// <summary>
        /// Le statut correspond aux activités de l'employé
        /// </summary>
        public Activités Statut { get; set; }
        public string Métier { get; }
        public string Code
        {
            get
            {
                return _code;
            }
            set
            {
                string a = _nom;
                //string b = _prenom;
                //char[] c = a.ToCharArray();
                //char[] d = b.ToCharArray();
                //a = d[0].ToString() + c[0].ToString();
                _code = a;
            }
        }

        #endregion

        #region constructeurs
        public Employé(string nom, string prenom, Activités statut)
        {
            Nom = nom;
            Prenom = prenom;
            Statut = statut;
            _code = Code;
        }

        public Employé(string code, string nom, string prenom, Activités statut)
        {
            Nom = nom;
            Prenom = prenom;
            Statut = statut;
            Code = code;
        }
        public Employé(string code, string nom, string prenom, string métier)
        {
            Nom = nom;
            Prenom = prenom;
            Métier = métier;
            Code = code;
        }



        #endregion

        #region Méthodes publiques
        /// <summary>
        /// Méthode qui calcul de cumul de temps passés sur les taches annexes
        /// </summary>
        public void CalculCumulTA()
        {
            List<TacheAnnexe> e1 = new List<TacheAnnexe>();

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
