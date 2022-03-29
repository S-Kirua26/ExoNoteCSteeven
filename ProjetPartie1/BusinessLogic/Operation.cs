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

        public Operation(string sortie)
        {
            Sortie = sortie;
        }

        public string ResultatOperation(Dictionary<string, double> dicoComptes, List<Transaction> listTransa, string sortie)
        {
            //foreach (var item in dicoComptes)
            //{
            //    Console.WriteLine($"Voici la liste des comptes : {item.Key} _ {item.Value}");
            //}

            //foreach (var item in listTransa)
            //{
            //    Console.WriteLine($"Voici la liste des transactions : {item.IdTransaction} - {item.Montant} - {item.Expediteur} - {item.Destinataire}");
            //}

            foreach (Transaction transaction in listTransa)
            {
                if (transaction.Montant < 0)
                {
                    return "KO";
                }
                else if (transaction.Expediteur == "0" && transaction.Destinataire != "0")
                {
                    if (dicoComptes.ContainsKey(transaction.Destinataire))
                    {
                        //double newSolde = dicoComptes[transaction.Destinataire] + transaction.Montant;
                        //dicoComptes[transaction.Destinataire] = newSolde;
                        dicoComptes[transaction.Destinataire] += transaction.Montant;
                        Console.WriteLine($"Ajout sur le compte réussi");
                    }
                }
                else if (transaction.Expediteur != "0" && transaction.Destinataire == "0")
                {
                    if (dicoComptes.ContainsKey(transaction.Expediteur))
                    {
                        dicoComptes[transaction.Expediteur] -= transaction.Montant;
                        Console.WriteLine($"retrait sur le compte réussi");
                    }
                }
                //else if (transaction.Expediteur != "0" && transaction.Destinataire != "0")
                //{
                //    foreach (var compte in dicoComptes)
                //    {
                //        if (compte.Key == transaction.Expediteur)
                //        {
                //            if (transaction.Montant > compte.Value)
                //            {
                //                return "KO";
                //            }
                //            double newSolde = compte.Value - transaction.Montant;
                //            //dicoComptes[compte.Key] = newSolde;
                //            Console.WriteLine($"Retrait sur le compte réussi");

                //        }
                //    }

                //    foreach (var compte in dicoComptes)
                //    {
                //        if (compte.Key == transaction.Destinataire)
                //        {
                //            double newSolde = compte.Value + transaction.Montant;
                //            //dicoComptes[compte.Key] = newSolde;
                //            Console.WriteLine($"Ajout sur le compte réussi");
                //        }
                //    }
                //    return "KO";
                //}
            }

            return "KO";
        }

        public string Ecriture(string affichage, string sortie)
        {
            using (StreamWriter ficSortie = new StreamWriter(sortie))
            {
                //sortie.WriteLine(affichage);
            }
            return "OK";
        }
    }
}
