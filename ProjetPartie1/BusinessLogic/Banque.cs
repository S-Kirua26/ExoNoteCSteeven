using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace CompteBancaire
{
	public class Banque
	{
		/// <summary>
		/// Maximum Retrait du compte
		/// </summary>
		public const double maxRetrait = 1000;

		/// <summary>
		/// Dictionnaire des comptes
		/// </summary>
		public Dictionary<int, double> _listeComptes;

        public Banque()
        {
			_listeComptes = new Dictionary<int, double>();
        }

		public Dictionary<int, double> ComptesTransaction(string ficComptes, string ficTransaction)
		{

			using (StreamReader lecture = new StreamReader(ficComptes))
			{
				while (!lecture.EndOfStream)
				{

					string line = lecture.ReadLine();

					string[] tableauLine = line.Split(';');

					string idCompte = tableauLine[0];
					int intCompte;
					int.TryParse(idCompte, out intCompte);

					string solde = tableauLine[1].Replace('.', ',');
					double doubleS;
					double.TryParse(solde, out doubleS);

					_listeComptes.Add(intCompte, doubleS);

				}
				//foreach (var item in _listeComptes)
				//{
				//	Console.WriteLine($"Voici la liste des transactions : {item.Key} _ {item.Value}");
				//}
				return _listeComptes;
			}
		}
    }
}

