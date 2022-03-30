using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    class Banque
    {

        /// <summary>
        /// Maximum Retrait du compte
        /// </summary>
        public const double maxRetrait = 1000;

        /// <summary>
        /// Dictionnaire des comptes
        /// </summary>
        private Dictionary<string, Compte> _listeComptes;
        private List<LigneFichier> _listeLigne;

        //public Transaction(string idCompte, double dateCrea, string solde, string destinataire)
        //{
        //    IdCompte = idCompte;
        //    DateCrea = dateCrea;
        //    Solde = solde;
        //    Destinataire = destinataire;
        //    listeTransaction = new List<Transaction>();
        //}

        public Banque()
        {
            _listeComptes = new Dictionary<string, Compte>();
            _listeLigne = new List<LigneFichier>();
        }

        public List<LigneFichier> ComptesTransaction(string ficComptes, string ficTransaction)
        {

            using (StreamReader lecture = new StreamReader(ficComptes))
            {
                while (!lecture.EndOfStream)
                {
                    string line = lecture.ReadLine();

                    string[] tableauLine = line.Split(';');

                    double solde;
                    double.TryParse(tableauLine[2].Replace('.', ','), out solde);

                    DateTime newDate = Convert.ToDateTime(tableauLine[1]);

                    _listeLigne.Add(new LigneFichier
                    {
                        Id = tableauLine[0],
                        Date = newDate,
                        Solde = solde,
                        Expediteur = tableauLine[3],
                        Destinataire = tableauLine[4],
                        Type = "1"
                    }); 
                }
            }

            using (StreamReader lecture = new StreamReader(ficTransaction))
            {
                while (!lecture.EndOfStream)
                {
                    string line = lecture.ReadLine();

                    string[] tableauLine = line.Split(';');

                    double solde;
                    double.TryParse(tableauLine[2].Replace('.', ','), out solde);

                    DateTime newDate = Convert.ToDateTime(tableauLine[1]);

                    _listeLigne.Add(new LigneFichier
                    {
                        Id = tableauLine[0],
                        Date = newDate,
                        Solde = solde,
                        Expediteur = tableauLine[3],
                        Destinataire = tableauLine[4],
                        Type = "2"
                    });
                }               
                //return _listeComptes;
            }
            _listeLigne = _listeLigne.OrderBy(x => x.Date).ToList();

            Console.WriteLine("------------------------------------------------------------------");
            foreach (var element in _listeLigne)
            {
                Console.WriteLine($"ligne : Id:{element.Id} - Date:{element.Date} - Solde:{element.Solde} - Expediteur:{element.Expediteur} - Destinataire:{element.Destinataire} - Type:{element.Type}");
            }
            return _listeLigne;
        }
    }
}

