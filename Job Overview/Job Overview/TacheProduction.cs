using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{
    /// <summary>
    /// Cette classe gère les tâches liées aux activités de production
    /// </summary>
    public class TacheProduction : Tache
    {
        #region Propriétés
        public int NumTâche { get; }
        public string NomTâche { get; }
        public DateTime DateDebut { get; set; }
        public int DureePrevue { get; set; }
        public int DureeRealise { get; set; }
        public int DureeRestante { get; set; }
        public string CodeEmployé { get; set; }

        #endregion

        #region constructeur
        public TacheProduction(int b, string a) : base(a, b)
        {


        }
        #endregion

        #region Méthodes publiques
        public string ModificationDureeRestante(int valeur)
        {
            DureeRestante = valeur;
          return String.Format("La nouvelle durée restante est de  : {0}", DureeRestante);
        }
        #endregion
    }
}
