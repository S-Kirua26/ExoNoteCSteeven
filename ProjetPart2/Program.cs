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
            banque.ComptesTransaction(acctPath, trxnPath);
            Gestionnaire gestionnaire = new Gestionnaire("","",0);
            gestionnaire.GestionComptes(mngrPath);

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
