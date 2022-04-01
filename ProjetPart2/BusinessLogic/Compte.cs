using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    public class Compte
    {
        public string Id { get; set; }
        public DateTime DateOuv { get; set; }

        public DateTime DateClo { get; set; }
        public double Solde { get; set; }

        //public string Entree { get; set; }
        //public string Sortie { get; set; }

        public string IdGestionnaire { get; set; }

        private Dictionary<string, Compte> _listeComptes;

        public Compte(string id, DateTime dateCrea, double solde, string idGestion)
        {
            Id = id;
            DateOuv = dateCrea;
            DateClo = DateTime.MinValue;
            Solde = solde;
            //Entree = entree;
            //Sortie = sortie;
            IdGestionnaire = idGestion;

            _listeComptes = new Dictionary<string, Compte>();
        }

        [Obsolete]
        public Dictionary<string, Compte> Comptes(string sortieFic)
        {
            using (StreamReader lecture = new StreamReader(sortieFic))
            {
                while (!lecture.EndOfStream)
                {

                    string line = lecture.ReadLine();

                    string[] tableauLine = line.Split(';');

                    double soldeCompte;
                    double.TryParse(tableauLine[2].Replace('.', ','), out soldeCompte);

                    DateTime newDate = Convert.ToDateTime(tableauLine[1]);

                    Compte newCompte = new Compte(tableauLine[0], newDate, soldeCompte, "");

                    if (!_listeComptes.ContainsKey(tableauLine[0]) && soldeCompte >= 0) // si le compte auquel on veut ajouter ne se trouve pas dans le dictionnaire de comptes, on rempli le dictionnaire
                    {
                        _listeComptes.Add(tableauLine[0], newCompte);
                    }
                }
                //foreach (var ligne in _listeComptes)
                //{
                //    Console.WriteLine($"Dictionnaire de comptes : Id:{ligne.Key}");
                //}
                return _listeComptes;
            }
        }

    }
}