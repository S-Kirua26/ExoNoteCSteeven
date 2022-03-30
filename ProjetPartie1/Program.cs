//using CompteBancaire;
using CompteBancaire.BusinessLogic;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CompteBancaire
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";


            Banque banque = new Banque();
            Transaction transaction = new Transaction("", 100, "", "");

            Operation operation = new Operation("");
            operation.ResultatOperation(banque.ComptesTransaction(acctPath), transaction.ChoixTransaction(trxnPath), sttsPath);


            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        
        }
    }
}
