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
    class TacheProduction: Tache
    {
        #region Propriétés
        public int NumTâche { get; }
        public int NomTâche { get; }
        #endregion
    }
}
