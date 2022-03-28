﻿//using CompteBancaire;
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
            banque.ComptesTransaction(acctPath, trxnPath);

            Transaction transaction = new Transaction("1", 100, "2", "3");
            transaction.ChoixTransaction(trxnPath);




            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}