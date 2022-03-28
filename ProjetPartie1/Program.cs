using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPartie1
{
    class Program
    {
        static void Main(string[] args)
        {
            string path = Directory.GetCurrentDirectory();
            string acctPath = path + @"\Comptes_1.txt";
            string trxnPath = path + @"\Transactions_1.txt";
            string sttsPath = path + @"\Statut_1.txt";

            //TODO: Votre implémentation

            // Keep the console window open
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}
