using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JobOverview
{
	/// <summary>
	/// Décrit une personne avec son métier
	/// </summary>
	public class Personne
	{
		public string Id { get; }
		public string Nom { get; }
		public string Prénom { get; }
		public Métier Métier { get; }

		public Personne(string id, string nom, string prénom, Métier métier)
		{
			Id = id;
			Nom = nom;
			Prénom = prénom;
			Métier = métier;
		}
	}
}
