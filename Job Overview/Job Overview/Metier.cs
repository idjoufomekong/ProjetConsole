using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Job_Overview
{

    #region Enumeration
    /// <summary>
    /// Création d'un Type d'énuméré Flag afin de réaliser une association d'énumération pour les métiers (Concaténation Bit à Bit).
    /// </summary>
    [Flags]
    public enum Activités
    {
        Aucun,
        DBE = 0,
        ARF = 1,
        ANF = 2,
        DES = 4,
        INF = 8,
        ART = 16,
        ANT = 32,
        DEV = 64,
        RPT = 128,
        TES = 256,
        GDP = 512,
    }

    #endregion
    public class Metier
    {
        #region Champs privés
        private const Activités _ANA = (Activités.DBE | Activités.ARF | Activités.ANF);
        private const Activités _CDP = (Activités.ARF | Activités.ANF | Activités.ART | Activités.TES | Activités.GDP);
        private const Activités _DEV = (Activités.ANF | Activités.ART | Activités.ANT | Activités.DEV | Activités.TES);
        private const Activités _DES = (Activités.ANF | Activités.DES | Activités.INF);
        private const Activités _TES = (Activités.RPT | Activités.GDP);
        #endregion




        #region Propriétés      
        /// <summary>
        /// Le statut designe le type de métier de la personne c'est à dire ANA, CDP, DEV, DES et TES
        /// </summary>
        public Activités ANA { get { return _ANA; } }
        public Activités CDP { get { return _CDP; } }
        public Activités DEV { get { return _DEV; } }
        public Activités DES { get { return _DES; } }
        public Activités TES { get { return _TES; } }
        #endregion

        #region Constructeurs
        public Metier()
        {

        }
        #endregion


    }
}

