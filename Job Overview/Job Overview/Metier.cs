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
        Aucun = 0,
        DBE = 1,
        ARF = 2,
        ANF = 4,
        DES = 8,
        INF = 16,
        ART = 32,
        ANT = 64,
        DEV = 128,
        RPT = 256,
        TES = 512,
        GDP = 1024
    }

    #endregion
    public class Metier
    {

        /// <summary>
        /// On créé des metier qui sont un ensemble d'activités.
        /// </summary>
        #region Champs 
        public const Activités _ANA = (Activités.DBE | Activités.ARF | Activités.ANF);
        public const Activités _CDP = (Activités.ARF | Activités.ANF | Activités.ART | Activités.TES | Activités.GDP);
        public const Activités _DEV = (Activités.ANF | Activités.ART | Activités.ANT | Activités.DEV | Activités.TES);
        public const Activités _DES = (Activités.ANF | Activités.DES | Activités.INF);
        public const Activités _TES = (Activités.RPT | Activités.GDP);
        #endregion




        #region Propriétés      
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
        #region Méthodes publiques
        public string RetournerMétier(Activités activ)
        {
            if ((activ & _ANA) == _ANA)
                return string.Format("Analyste");
            else if ((activ & _CDP) == _CDP)
                return string.Format("Chef de projet");
            else if ((activ & _DEV) == _DEV)
                return string.Format("Développeur");
            else if ((activ & _DES) == _DES)
                return string.Format("Designer");
            else if ((activ & _TES) == _TES)
                return string.Format("Testeur");
            else return "";
        }

        public string RetournerActivités(string métier)
        {
            string s = string.Empty;
            if (métier.CompareTo("Analyste") == 0)
                return string.Format("Liste d'activités: {0}, {1}, {2}", Activités.DBE, Activités.ARF, Activités.ANF);
            else if (métier.CompareTo("Chef de projet") == 0)
                return string.Format("Liste d'activités: {0}, {1}, {2}, {3}, {4}", Activités.ART, Activités.ARF, Activités.ANF, Activités.TES, Activités.GDP);
            else if (métier.CompareTo("Développeur") == 0)
                return string.Format("Liste d'activités: {0}, {1}, {2}, {3}, {4}", Activités.ART, Activités.ANT, Activités.ANF, Activités.TES, Activités.DEV);
            else if (métier.CompareTo("Designer") == 0)
                return string.Format("Liste d'activités: {0}, {1}, {2}", Activités.DES, Activités.INF, Activités.ANF);
            else if (métier.CompareTo("Testeur") == 0)
                return string.Format("Liste d'activités: {0}, {1}", Activités.RPT, Activités.TES);
            else return s;
        }
        #endregion


    }
}

