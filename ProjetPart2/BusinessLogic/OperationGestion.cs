using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{    
    class OperationGestion
    {
        public string Sortie { get; set; }

        //public List<Compte> ListCompte;
        public List<string> ListEtat;
        public OperationGestion(string sortie)
        {
            Sortie = sortie;
            //ListCompte = new List<Compte>();
            ListEtat = new List<string>();
        }

        //public string ResultatOperation(Dictionary<string, Compte> dicoComptes, List<Transaction> listTransa, List<Gestionnaire> listeGst, List<LigneFichier> listFic, string sortie)
        //{
        //    DateTime dateCession = DateTime.MinValue;

        //    foreach (var ligne in listFic)
        //    {
        //        if(ligne.Type == "1")
        //        {
        //            if (!string.IsNullOrEmpty(ligne.Expediteur) && string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0) // Création de compte
        //            {
        //                foreach (var gstn in listeGst)
        //                {
        //                    if (gstn.IdGestion.Equals(ligne.Expediteur))
        //                    {
        //                        Console.WriteLine(ligne.Id + "Compte créé");
        //                        Compte c = new Compte(ligne.Id, ligne.Date, dateCession, ligne.Solde, ligne.Expediteur, ligne.Destinataire, gstn.IdGestion);
        //                        ListCompte.Add(c);
        //                        ListEtat.Add($"{ligne.Id};OK");
        //                        break;
        //                    }
        //                }
        //            }
        //            else if (string.IsNullOrEmpty(ligne.Expediteur) && !string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0) // Cloturation de compte
        //            {
        //                foreach (var g in listeGst)
        //                {
        //                    if(g.IdGestion.Equals(ligne.Destinataire))
        //                    {
        //                        foreach (var element in ListCompte)
        //                        {
        //                            if (element.Id == ligne.Destinataire)
        //                            {
        //                                element.DateClo = ligne.Date;
        //                                //ListCompte.Remove(element);
        //                                Console.WriteLine($"{element.DateClo} - {ligne.Date}");
        //                            }
        //                        }
        //                    }
                            
        //                }                       
        //            }
        //            //else if (string.IsNullOrEmpty(ligne.Expediteur) && !string.IsNullOrEmpty(ligne.Destinataire) && ligne.Solde >= 0) // Cloturation de compte
        //            //{
        //            //    foreach (var element in ListCompte)
        //            //    {
        //            //        if (element.Id == ligne.Id)
        //            //        {

        //            //        }
        //            //    }
        //            //}
        //            else
        //            {
        //                Console.WriteLine(ligne.Id + "compte erroné");
        //                ListEtat.Add($"{ligne.Id};KO");
        //            }
        //        }

        //    }

        //    foreach (var item in ListCompte)
        //    {
        //        Console.WriteLine($"Id:{item.Id} - DateOuv:{item.DateOuv} - DateClo:{item.DateClo}");
        //    }

        //    using (StreamWriter ficSortie = new StreamWriter(sortie))
        //    {
        //        foreach (var etat in ListEtat)
        //        {
        //            ficSortie.WriteLine(etat);
        //        }
        //    }

        //    return "KO";
        //}
    }
}
