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
        private Dictionary<string, Gestionnaire> _listeGestionnaires;
        private Dictionary<string, Compte> _listeComptes;
        private List<Transaction> _listeTransactions;
        private List<LigneFichier> _listeLigne;
        private List<string> _listEtat;

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
            _listeGestionnaires = new Dictionary<string, Gestionnaire>();
            _listeComptes = new Dictionary<string, Compte>();
            _listeLigne = new List<LigneFichier>();
            _listEtat = new List<string>();
        }

        internal void TraiterComptesTransaction()
        {
            //foreach (LigneFichier ligne in _listeLigne)
            //{
            //    //TODO: Vérifier SI Opération
            //    if (true)
            //    {
            //        Compte c = new Compte(ligne.Id, ligne.Date, ligne.Solde, ligne.Expediteur);
            //        _listeComptes.Add(ligne.Id, c);
            //    }
            //    //TODO: Vérifier SI Transaction
            //    else if (true)
            //    {
            //        Transaction t = new Transaction(ligne.Id, ligne.Date, ligne.Solde, ligne.Expediteur, ligne.Destinataire);
            //        _listeTransactions.Add(t);
            //    }
            //}
            foreach (LigneFichier ligne in _listeLigne)
            {
                if (ligne.Type == "1")
                {
                    if (!string.IsNullOrEmpty(ligne.Expediteur) && string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0) // Création de compte
                    {
                        foreach (var gstn in _listeGestionnaires)
                        {
                            if (gstn.Key == ligne.Expediteur)
                            {
                                Console.WriteLine(ligne.Id + "Compte créé");
                                Compte c = new Compte(ligne.Id, ligne.Date, ligne.Solde, gstn.Value.IdGestion);
                                _listeComptes.Add(ligne.Id,c);
                                _listEtat.Add($"{ligne.Id};OK");
                                break;
                            }
                        }
                    }
                    else if (string.IsNullOrEmpty(ligne.Expediteur) && !string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0) // Cloturation de compte
                    {
                        foreach (var g in _listeGestionnaires)
                        {
                            if (g.Key == ligne.Destinataire)
                            {
                                foreach (var element in _listeComptes)
                                {
                                    if (element.Key == ligne.Destinataire)
                                    {
                                        element.Value.DateClo = ligne.Date;
                                        //ListCompte.Remove(element);
                                        Console.WriteLine($"{element.Value.DateClo} - {ligne.Date}");
                                    }
                                }
                            }

                        }
                    }
                    else if (!string.IsNullOrEmpty(ligne.Expediteur) && !string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0)
                    {
                        if (_listeGestionnaires.ContainsKey(ligne.Expediteur) && _listeGestionnaires.ContainsKey(ligne.Destinataire))
                        {
                            Console.WriteLine($"Le type de gestionnaire est identique");

                        }
                    }
                    //else if (string.IsNullOrEmpty(ligne.Expediteur) && !string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0) // Cloturation de compte
                    //{
                    //    foreach (var element in ListCompte)
                    //    {
                    //        if (element.Id == ligne.Id)
                    //        {

                    //        }
                    //    }
                    //}
                    else
                    {
                        Console.WriteLine(ligne.Id + "compte erroné");
                        _listEtat.Add($"{ligne.Id};KO");
                    }
                }
            }

            foreach (var item in _listeComptes)
            {
                Console.WriteLine($"Id:{item.Value.Id} - DateOuv{item.Value.DateOuv} - DateClose{item.Value.DateClo} - Solde{item.Value.Solde} - IdGestion{item.Value.IdGestionnaire}");
            }
        }
        public void LireGestionnaires(string ficGestion)
        {
            using (StreamReader lecture = new StreamReader(ficGestion))
            {
                while (!lecture.EndOfStream)
                {
                    string line = lecture.ReadLine();

                    string[] tableauLine = line.Split(';');

                    //TODO: Vérifier que le gestionnaire  est valide avant ajout
                    if (true)
                    {
                        //Gestionnaire gestionnaire = new Gestionnaire(tableauLine[0], tableauLine[1], int.Parse(tableauLine[2]));
                        _listeGestionnaires.Add(tableauLine[0], new Gestionnaire(tableauLine[0], tableauLine[1], int.Parse(tableauLine[2])));

                    }
                }
            }
            //foreach (var element in ListeGestion)
            //{
            //    Console.WriteLine($"Gestionnaire : Id:{element.IdGestion} - Type:{element.TypeG} - nbtransa:{element.NbTransa}");
            //}
        } // Lecture du fichier Gestionnaire


        public void LireComptesTransaction(string ficComptes, string ficTransaction)
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

                    //if(!_listeComptes.ContainsKey(tableauLine[0]))
                    //{
                    //    Compte compte = new Compte(tableauLine[0],newDate,solde,tableauLine[3],tableauLine[4]);
                    //    _listeComptes.Add(tableauLine[0], compte);
                    //}
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


            //foreach (var element in _listeLigne)
            //{
            //    Console.WriteLine($"ligne : Id:{element.Id} - Date:{element.Date} - Solde:{element.Solde} - Expediteur:{element.Expediteur} - Destinataire:{element.Destinataire} - Type:{element.Type}");
            //}
        }// Lecture du fichier Comptes et fichier Transactions
    }
}

