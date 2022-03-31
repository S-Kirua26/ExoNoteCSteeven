using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            // Fichiers entrée
            string mngrPath = path + @"\Gestionnaires_1.txt";
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            // Fichiers sortie
            string sttsAcctPath = path + @"\StatutOpe_1.txt";
            string sttsTrxnPath = path + @"\StatutTra_1.txt";
            string mtrlPath = path + @"\Metrologie_1.txt";

            // Implémentation
            Banque banque = new Banque();
            banque.LireGestionnaires(mngrPath);
            banque.LireComptesTransaction(acctPath, trxnPath);
            banque.TraiterComptesTransaction();

            var date1 = new DateTime(2008, 5, 1);

            Compte compte = new Compte("", date1, 100, "");
            Transaction transaction = new Transaction("", date1, 0, "", "");
            Gestionnaire gestionnaire = new Gestionnaire("", "", 0);

            //OperationGestion operation = new OperationGestion("");
            //operation.ResultatOperation(compte.Comptes(acctPath), transaction.ChoixTransaction(trxnPath), gestionnaire.GestionComptes(mngrPath), banque.LireComptesTransaction(acctPath, trxnPath), sttsAcctPath);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
