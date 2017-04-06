using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverviewBis
{
    #region Enumeration
    /// <summary>
    /// Création d'un Type d'énuméré Flag afin de réaliser une association d'énumération pour les métiers (Concaténation Bit à Bit).
    /// </summary>
    [Flags]
    public enum ActivitésProd
    {
        Aucun = 0,
        DéfinitionBesoins = 1,
        ArchitectureFonctionnelle = 2,
        AnalyseFonctionnelle = 4,
        Design = 8,
        Infographie = 16,
        ArchitectureTechnique = 32,
        AnalyseTechnique = 64,
        Développement = 128,
        RédactionPlanTest = 256,
        Test = 512,
        GestionProjet = 1024
    }

    #endregion

    public class ActivitéAnnexe
    {
        #region Propriétés
        public string Code { get; }
        public string Libellé { get; }
        #endregion
        #region Constructeur
        public ActivitéAnnexe(string code, string libellé)
        {
            Code = code;
            Libellé = libellé;
        }
        #endregion
    }
    public class Metier
    {
        #region Propriétés
        public string Code { get;}
        public string Libellé { get; }
        public ActivitésProd Activités { get; }
        #endregion

        #region Constructeur
        public Metier(string code, string libellé, ActivitésProd activités)
        {
            Code = code;
            Libellé = libellé;
            Activités = activités;

        }
        #endregion
    }
}
