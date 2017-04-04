using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Job_Overview;

namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TesterDuréeRéaliséeVersion1()
        {
            Result res1 = new Result();
            int nbrJour, nbrJour2, pourcentage1, pourcentage2;
            double pourcentage1Retard, pourcentage2Retard;
            res1.CalculNombreJour(out nbrJour, out nbrJour2, out pourcentage1, out pourcentage2, out pourcentage1Retard, out pourcentage2Retard);
            Assert.AreEqual(-3,nbrJour);

        }
        [TestMethod]
        public void TesterPourcentageRéaliséeVersion1()
        {
            Result res1 = new Result();
            int nbrJour, nbrJour2, pourcentage1, pourcentage2;
            double pourcentage1Retard, pourcentage2Retard;
            res1.CalculNombreJour(out nbrJour, out nbrJour2, out pourcentage1, out pourcentage2, out pourcentage1Retard, out pourcentage2Retard);
            Assert.AreEqual(0, pourcentage1Retard, 0.01);

        }
    }
}
