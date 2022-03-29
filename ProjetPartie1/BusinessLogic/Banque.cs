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
        public Dictionary<string, double> _listeComptes;

        public Banque()
        {
            _listeComptes = new Dictionary<string, double>();
        }

        public Dictionary<string, double> ComptesTransaction(string ficComptes)
        {

            using (StreamReader lecture = new StreamReader(ficComptes))
            {
                while (!lecture.EndOfStream)
                {
                    string line = lecture.ReadLine();

                    string[] tableauLine = line.Split(';');

                    //string idCompte = tableauLine[0];
                    //int intCompte;
                    //int.TryParse(idCompte, out intCompte);

                    double solde;
                    double.TryParse(tableauLine[1].Replace('.', ','), out solde);

                    if (!_listeComptes.ContainsKey(tableauLine[0]) && solde >= 0) // si le compte auquel on veut ajouter ne se trouve pas dans le dictionnaire de comptes, on rempli le dictionnaire
                    {
                        _listeComptes.Add(tableauLine[0], solde);
                    }
                }
                //foreach (var item in _listeComptes)
                //{
                //    Console.WriteLine($"Voici la liste des comptes : {item.Key} _ {item.Value}");
                //}
                return _listeComptes;
            }
        }
    }
}

