using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetPart2
{
    class Gestionnaire
    {
        public string IdGestion { get; set; }

        public string TypeG { get; set; }

        public int NbTransa { get; set; }

        //public double Total { get; set; }

        public Dictionary<string,Compte> ListeCompte { get; set; }

        public List<Gestionnaire> ListeGestion;

        public Gestionnaire(string idGestion, string typeGestion, int nbTransa)
        {
            IdGestion = idGestion;
            TypeG = typeGestion;
            NbTransa = nbTransa;
            ListeGestion = new List<Gestionnaire>();
        }

        public List<Gestionnaire> GestionComptes(string ficGestion)
        {
            using (StreamReader lecture = new StreamReader(ficGestion))
            {
                while (!lecture.EndOfStream)
                {
                    string line = lecture.ReadLine();

                    string[] tableauLine = line.Split(';');
                    Gestionnaire gestionnaire = new Gestionnaire(tableauLine[0], tableauLine[1], int.Parse(tableauLine[2]));
                    ListeGestion.Add(gestionnaire);
                }
            }
            foreach (var element in ListeGestion)
            {
                Console.WriteLine($"ligne : Id:{element.IdGestion} - Type:{element.TypeG} - nbtransa:{element.NbTransa}");
            }
            return ListeGestion;
        }
    }  
}
