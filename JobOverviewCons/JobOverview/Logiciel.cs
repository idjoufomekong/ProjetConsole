using System;
using System.Collections.Generic;

namespace JobOverview
{
	public class Logiciel
	{
		public string Nom { get; }
		public string Description { get; set; }
		public Dictionary<string, VersionLogiciel> Versions { get; set; }

		public Logiciel(string nom)
		{
			Nom = nom;
			Versions = new Dictionary<string, VersionLogiciel>();
		}
	}

	public class VersionLogiciel
	{
		public string NumVersion { get; }
		public int Millésime { get; }
		public DateTime DateDébut { get; }
		public DateTime? DatePublication { get; set; }

		public VersionLogiciel(string numVersion, int millésime, DateTime dateDeb, DateTime? datePub)
		{
			NumVersion = numVersion;
			Millésime = millésime;
			DateDébut = dateDeb;
			DatePublication = datePub;
		}
	}
}
