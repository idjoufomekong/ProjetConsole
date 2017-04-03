using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    class Employé
    {
        


        #region Propriétés
        public int Nom { get; set; }
        public int Prenom { get; set; }
        #endregion

        #region constructeurs

        public Employé (string nom, string prenom, Activités Statut)
        {
            Nom = nom;
            Prenom = prenom;
            Metier = metier;


        }


        #endregion

    }
}
