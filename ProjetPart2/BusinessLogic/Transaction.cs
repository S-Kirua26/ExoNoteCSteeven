using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    class Transaction
    {
        public string IdTransaction { get; set; }
        public double Montant { get; set; }
        public DateTime DateEffet { get; set; }
        public string Expediteur { get; set; }
        public string Destinataire { get; set; }

        public List<Transaction> listeTransaction;
        public Transaction(string idTrans, DateTime dateEffet, double montant, string expediteur, string destinataire)
        {
            IdTransaction = idTrans;
            DateEffet = dateEffet;
            Montant = montant;
            Expediteur = expediteur;
            Destinataire = destinataire;
            listeTransaction = new List<Transaction>();
        }

        [Obsolete]
        public List<Transaction> ChoixTransaction(string ficTransaction)
        {

            using (StreamReader lectureTran = new StreamReader(ficTransaction))
            {
                while (!lectureTran.EndOfStream)
                {
                    string line = lectureTran.ReadLine();
                    string[] tableauLine2 = line.Split(';');

                    DateTime newDate = Convert.ToDateTime(tableauLine2[1]);

                    Transaction transaction = new Transaction(tableauLine2[0], newDate, double.Parse(tableauLine2[2]), tableauLine2[3], tableauLine2[4]);
                    listeTransaction.Add(transaction);
                }
                //foreach (var ligne in listeTransaction)
                //{
                //    Console.WriteLine($"Transaction : {ligne.IdTransaction} - {ligne.Montant}");
                //}
                return listeTransaction;
            }
        }
    }
}
