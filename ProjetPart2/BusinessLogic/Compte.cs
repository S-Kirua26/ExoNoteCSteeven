using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    public class Compte
    {
        public string Id { get; set; }
        public DateTime DateOuv { get; set; }
        public DateTime DateClo { get; set; }
        public string Solde { get; set; }
        public string Gestionnaire { get; set; }

    }
}