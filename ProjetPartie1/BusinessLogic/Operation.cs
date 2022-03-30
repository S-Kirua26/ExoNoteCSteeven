using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire.BusinessLogic
{
    class Operation
    {
        public string Sortie { get; set; }
        public List<string> listeEtat;

        public Operation(string sortie)
        {
            Sortie = sortie;
            listeEtat = new List<string>();
        }

        public string ResultatOperation(Dictionary<string, double> dicoComptes, List<Transaction> listTransa, string sortie)
        {
            List<string> listeDoublon = new List<string>();

            Console.WriteLine($"Voici la liste des comptes :");
            foreach (var item in dicoComptes)
            {
                Console.WriteLine($"{item.Key} _ {item.Value}");
            }

            foreach (Transaction transaction in listTransa)
            {
                if (!listeDoublon.Any(id => id.Equals(transaction.IdTransaction))) // si un identifiant de transaction se trouve déjà dans ma liste de doublons
                {
                    if (transaction.Montant <= 0)
                    {
                        listeEtat.Add(transaction.IdTransaction + ";KO");
                    }
                    else if (transaction.Expediteur == "0" && transaction.Destinataire != "0")
                    {
                        if (dicoComptes.ContainsKey(transaction.Destinataire)) // si le compte existe dans le dictionnaire de comptes
                        {
                            //double newSolde = dicoComptes[transaction.Destinataire] + transaction.Montant;
                            //dicoComptes[transaction.Destinataire] = newSolde;
                            dicoComptes[transaction.Destinataire] += transaction.Montant;
                            Console.WriteLine($"Format 0-1 : Ajout sur le compte réussi");
                            listeEtat.Add(transaction.IdTransaction + ";OK");
                        }
                        else
                        {
                            listeEtat.Add(transaction.IdTransaction + ";KO");
                        }
                    }
                    else if (transaction.Expediteur != "0" && transaction.Destinataire == "0")
                    {
                        if (dicoComptes.ContainsKey(transaction.Expediteur))
                        {
                            dicoComptes[transaction.Expediteur] -= transaction.Montant;
                            Console.WriteLine($"Format 1-0 : Retrait sur le compte réussi");
                            listeEtat.Add(transaction.IdTransaction + ";OK");
                        }
                        else
                        {
                            listeEtat.Add(transaction.IdTransaction + ";KO");
                        }
                    }
                    else if (transaction.Expediteur != "0" && transaction.Destinataire != "0")
                    {
                        if (dicoComptes.ContainsKey(transaction.Destinataire) && dicoComptes.ContainsKey(transaction.Expediteur)) // si l'identifiant du destinataire et de l'expediteur se trouve dans le dictionnaire
                        {
                            if (dicoComptes[transaction.Expediteur] >= transaction.Montant) // si le solde de l'expediteur est superieiur au montant
                            {
                                dicoComptes[transaction.Destinataire] += transaction.Montant;
                                dicoComptes[transaction.Expediteur] -= transaction.Montant;
                                Console.WriteLine($"Format 1-1 : Ajout et retrait sur les comptes réussi");
                                listeEtat.Add(transaction.IdTransaction + ";OK");
                            }
                            else
                            {
                                listeEtat.Add(transaction.IdTransaction + ";KO");
                            }
                        }
                        else
                        {
                            listeEtat.Add(transaction.IdTransaction + ";KO");
                        }
                    }
                }
                else
                {
                    listeEtat.Add($"{transaction.IdTransaction};KO");
                }

                listeDoublon.Add(transaction.IdTransaction);
            }


            using (StreamWriter ficSortie = new StreamWriter(sortie))
            {
                foreach (var etat in listeEtat)
                {
                    ficSortie.WriteLine(etat);
                }
            }

            foreach (var item in dicoComptes)
            {
                Console.WriteLine($"Voici la liste des comptes : {item.Key} _ {item.Value}");
            }
            return "KO";
        }
    }
}
