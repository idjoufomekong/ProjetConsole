using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using JobOverview;

namespace TestJO
{
	/// <summary>
	/// Tests unitaires des méthodes de la classe Results
	/// </summary>
	[TestClass]
	public class TestResults
	{
		private static Results _res;

		[ClassInitialize()]
		public static void InitData(TestContext context)
		{
			_res = new Results(@"..\..\..\Data.txt");
		}

		[TestMethod]
		public void TestDuréesTravail()
		{
			int réalisé, restant;
			_res.DuréesTravail("2.00", "GL", out réalisé, out restant);
			Assert.AreEqual(58, réalisé);
			Assert.AreEqual(21, restant);

			_res.DuréesTravail("2.00", "MW", out réalisé, out restant);
			Assert.AreEqual(72, réalisé);
			Assert.AreEqual(11, restant);
		}

		[TestMethod]
		public void TestBilanVersion()
		{
			int diff, pourcentDiff;
			_res.BilanVersion("1.00", out diff, out pourcentDiff);
			Assert.AreEqual(3, diff);
			Assert.AreEqual(0, pourcentDiff);
		}

		[TestMethod]
		public void TestTravailRéaliséParActivité()
		{
			var dico = _res.TravailRéaliséParActivité("1.00");
			Assert.AreEqual(295, dico[ActivitésProd.AnalyseFonctionnelle]);
			Assert.AreEqual(95, dico[ActivitésProd.ArchitectureTechnique]);
			Assert.AreEqual(259, dico[ActivitésProd.Développement]);
			Assert.AreEqual(248, dico[ActivitésProd.Test]);
		}
	}
}
