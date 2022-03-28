using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire
{
	
	class Transaction
	{
		public string IdTransaction{ get; set; }
		public double Montant { get; set; }
		public string Expediteur { get; set; }
		public string Destinataire { get; set; }
			
		public List<Transaction> listeTransaction;
		public Transaction(string idTrans, double montant, string expediteur, string destinataire)
		{
			IdTransaction = idTrans;
			Montant = montant;
			Expediteur = expediteur;
			Destinataire = destinataire;
			listeTransaction = new List<Transaction>();		
		}
			public List<Transaction> ChoixTransaction(string ficTransaction)
		{

			using (StreamReader lectureTran = new StreamReader(ficTransaction))
			{
				while (!lectureTran.EndOfStream)
				{
					string line = lectureTran.ReadLine();
					//Console.WriteLine(line);
					string[] tableauLine2 = line.Split(';');

					Transaction transaction = new Transaction(tableauLine2[0], double.Parse(tableauLine2[1]), tableauLine2[2], tableauLine2[3]);
					listeTransaction.Add(transaction);
					

				}
                //foreach (var item in listeTransaction)
                //{
                //    Console.WriteLine($"Voici la liste des transactions : {item.IdTransaction} - {item.Montant} - {item.Expediteur} - {item.Destinataire}");
                //}
                return listeTransaction;
               
            }
        }
	}
}
