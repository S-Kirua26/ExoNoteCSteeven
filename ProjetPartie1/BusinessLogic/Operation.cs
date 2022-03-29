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
            string affichage = "";

            foreach (var item in dicoComptes)
            {
                Console.WriteLine($"Voici la liste des comptes : {item.Key} _ {item.Value}");
            }

            foreach (Transaction transaction in listTransa)
            {
                if (transaction.Montant < 0 || )
                {
                    affichage = transaction.IdTransaction + " :KO";
                    listeEtat.Add(affichage);
                }
                else if (transaction.Expediteur == "0" && transaction.Destinataire != "0")
                {
                    if (dicoComptes.ContainsKey(transaction.Destinataire)) // si le compte existe dans le dictionnaire de comptes
                    {
                        //double newSolde = dicoComptes[transaction.Destinataire] + transaction.Montant;
                        //dicoComptes[transaction.Destinataire] = newSolde;
                        dicoComptes[transaction.Destinataire] += transaction.Montant;
                        Console.WriteLine($"Format 0-1 : Ajout sur le compte réussi");
                        affichage = transaction.IdTransaction + " :OK";
                        listeEtat.Add(affichage);
                    }
                    else
                    {
                        affichage = transaction.IdTransaction + " :KO";
                        listeEtat.Add(affichage);
                    }
                }
                else if (transaction.Expediteur != "0" && transaction.Destinataire == "0")
                {
                    if (dicoComptes.ContainsKey(transaction.Expediteur)) 
                    {
                        dicoComptes[transaction.Expediteur] -= transaction.Montant;
                        Console.WriteLine($"Format 1-0 : Retrait sur le compte réussi");
                        affichage = transaction.IdTransaction + " :OK";
                        listeEtat.Add(affichage);
                    }
                    else
                    {
                        affichage = transaction.IdTransaction + " :KO";
                        listeEtat.Add(affichage);
                    }
                }
                else if (transaction.Expediteur != "0" && transaction.Destinataire != "0")
                {
                    if (dicoComptes.ContainsKey(transaction.Destinataire) && dicoComptes.ContainsKey(transaction.Expediteur))
                    {
                        if(dicoComptes[transaction.Expediteur] >= transaction.Montant)
                        {
                            dicoComptes[transaction.Destinataire] += transaction.Montant;
                            dicoComptes[transaction.Expediteur] -= transaction.Montant;
                            Console.WriteLine($"Format 1-1 : Ajout et retrait sur les comptes réussi");
                            affichage = transaction.IdTransaction + " :OK";
                            listeEtat.Add(affichage);
                        }
                        else
                        {
                            affichage = transaction.IdTransaction + " :KO";
                            listeEtat.Add(affichage);
                        }
                    }
                    else
                    {
                        affichage = transaction.IdTransaction + " :KO";
                        listeEtat.Add(affichage);
                    }
                }
                for (int i = 0; i < listTransa.Count; i++)
                {
                    if (listTransa[i].IdTransaction = transaction.IdTransaction)
                    {
                        Console.WriteLine("ça marche pas");
                    }
                }
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

        //private string Ecriture(string affichage, string sortie)
        //{

        //    return "OK";
        //}
    }
}
