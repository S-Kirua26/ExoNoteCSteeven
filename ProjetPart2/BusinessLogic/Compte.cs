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
        //public DateTime DateClo { get; set; }
        public double Solde { get; set; }
        public string Entree { get; set; }

        public string Sortie { get; set; }

        public List<Compte> ListeCompte;

        public Compte(string id, DateTime datecrea, double solde, string entree, string sortie)
        {
            Id = id;
            DateOuv = datecrea;
            Solde = solde;
            Entree = entree;
            Sortie = sortie;

            ListeCompte = new List<Compte>();
        }

        public List<Compte> Comptes(List<LigneFichier> listeFichier)
        {
            return ListeCompte;
        }
    }
}