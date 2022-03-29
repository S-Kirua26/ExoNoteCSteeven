﻿using System;
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
            List<string> listeDoublon = new List<string>();

            Console.WriteLine($"Voici la liste des comptes :");
            foreach (var item in dicoComptes)
            {
                Console.WriteLine($"{item.Key} _ {item.Value}");
            }

            foreach (Transaction transaction in listTransa)
            {
                //for (int i = 0; i < listTransa.Count; i++)
                //{
                //    if (listTransa[i].IdTransaction == transaction.IdTransaction)
                //    {
                //        affichage = transaction.IdTransaction + " :KO";
                //        listeEtat.Add(affichage);
                //        Console.WriteLine($"La transcation {transaction.IdTransaction} est en double");
                //    }
                //}
                //for (int i = 1; i < listeDoublon.Count; i++)
                //{
                //    if (listeDoublon[i] == transaction.IdTransaction)
                //    {
                //        affichage = transaction.IdTransaction + " :KO";
                //        listeEtat.Add(affichage);
                //        Console.WriteLine($"La transaction {transaction.IdTransaction} est en double");
                //    }
                //}

                if (!listeDoublon.Any(id => id.Equals(transaction.IdTransaction)))
                {
                    if (transaction.Montant < 0)
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
                        if (dicoComptes.ContainsKey(transaction.Destinataire) && dicoComptes.ContainsKey(transaction.Expediteur))
                        {
                            if (dicoComptes[transaction.Expediteur] >= transaction.Montant)
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

        //private string Ecriture(string affichage, string sortie)
        //{

        //    return "OK";
        //}
    }
}
