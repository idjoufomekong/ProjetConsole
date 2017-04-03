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
    class Metier
    {
        static void MetierActivite()
        {
            var ANA = new Employé(Activités.DBE | Activités.ARF | Activités.ANF);
            var CDP = new Employé(Activités.ARF | Activités.ANF | Activités.ART | Activités.TES | Activités.GDP);
            var DEV = new Employé(Activités.ANF | Activités.ART | Activités.ANT | Activités.DEV | Activités.TES);
            var DES = new Employé(Activités.ANF | Activités.DES | Activités.INF);
            var TES = new Employé(Activités.RPT | Activités.GDP);

        }

    }
}
