using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    internal class LigneFichier
    {
        public string Id { get; set; }

        public DateTime Date { get; set; }

        public double Solde { get; set; }

        public string Expediteur { get; set; }

        public string Destinataire { get; set; }

        public string Type { get; set; } 

    }
}